using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CurrencyApi.Models;
using CurrencyApi.Utilities;
using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CurrencyApi.Workers
{
    public class CurrencyWorkerService : BackgroundService
    {
        private bool _isFirstRun = true;
        private string goldOunceCode = "XAU/USD";
        private DateTime _cacheFirstRunDate;

        private readonly IMemoryCache _cache;
        public CurrencyWorkerService(IMemoryCache cache)
        {
            _cache = cache;
            _cacheFirstRunDate = DateTime.Now;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    
                    var currencyPairs = new Dictionary<string, CurrencyPairNameValue>();
                    var timer = new Stopwatch();
                    timer.Start();
                    //var currencyIds = GetCurrencyIds();
                    var currencyIds = new List<string> { "12", "17", "3" };
                    var isCurrency = _cache.TryGetValue("Currencies", out currencyPairs);
                    if (!isCurrency)
                    {
                        currencyPairs = new Dictionary<string, CurrencyPairNameValue>();
                    }

                    if (_cacheFirstRunDate.AddHours(3) <= DateTime.Now)
                    {
                        currencyPairs[goldOunceCode] = GetFirstGoldPrices();
                        currencyPairs[goldOunceCode] = GetGoldLastPrice();
                        GetOpeningPrice();
                        _cacheFirstRunDate = DateTime.Now;
                    }

                    foreach (var id in currencyIds)
                    {
                        var client = new RestClient(string.Format("{0}{1}", "https://www.investing.com/currencies/Service/ChangeCurrency?session_uniq_id=8e76f31a89daa6aab3e3eb57a7a182ef&currencies=", id));
                        client.Timeout = -1;
                        var request = new RestRequest(Method.GET);
                        request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
                        request.AddHeader("Sec-Fetch-Dest", "empty");
                        request.AddHeader("X-Requested-With", "XMLHttpRequest");
                        request.AddHeader("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36");
                        request.AddHeader("Cookie", "adBlockerNewUserDomains=1587290521");
                        IRestResponse response = client.Execute(request);

                        var json = JObject.Parse(response.Content);
                        var html = json.SelectToken("HTML").Value<string>();

                        HtmlDocument pageDocument = new HtmlDocument
                        {

                            OptionFixNestedTags = true,
                            OptionCheckSyntax = true,
                            OptionAutoCloseOnEnd = true
                        };
                        pageDocument.LoadHtml(html);
                        var rows = pageDocument.DocumentNode.SelectNodes("(//table[@id='cr1']//tbody/tr)");

                        foreach (var row in rows)
                        {
                            var doc = new HtmlDocument();
                            var inner = row.InnerHtml;
                            doc.LoadHtml(inner);
                            var code = doc.DocumentNode.SelectSingleNode("//td[2]").InnerText;
                            var fxId = doc.DocumentNode.SelectSingleNode("//td[2]//span").GetAttributeValue("data-id", "null");
                            var rate = doc.DocumentNode.SelectSingleNode("//td[4]").InnerText;

                            if (isCurrency)
                            {
                                var fx = new CurrencyPairNameValue();
                                currencyPairs.TryGetValue(code, out fx);
                                fx.Values.AddLast(new CurrencyValue
                                {
                                    DateTime = DateTime.Now,
                                    Value = Convert.ToDecimal(rate, new CultureInfo("en-US"))
                                });
                                if (fx.Values.Count > 3)
                                {
                                    fx.Values.Remove(fx.Values.First.Next);
                                }
                            }
                            else
                            {

                                var firstValue = new CurrencyPairNameValue
                                {
                                    FxId = fxId,
                                    Code = code,
                                    Values = new LinkedList<CurrencyValue>()

                                };
                                firstValue.Values.AddLast(new CurrencyValue
                                {
                                    DateTime = DateTime.Now,
                                    Value = Convert.ToDecimal(rate, new CultureInfo("en-US"))
                                });
                                if (!currencyPairs.ContainsKey(code))
                                {
                                    currencyPairs.Add(code, firstValue);
                                }
                            }
                        }

                    }

                    timer.Stop();
                    //Console.Out.WriteLine(timer.ElapsedMilliseconds);
                    if (_isFirstRun)
                    {
                        currencyPairs.Add(goldOunceCode, GetFirstGoldPrices());
                    }
                    else
                    {
                        currencyPairs[goldOunceCode] = GetGoldLastPrice();
                    }

                    _cache.Set("Currencies", currencyPairs);
                    if (_isFirstRun) GetOpeningPrice();
                    await Task.Delay(5000, stoppingToken);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GetOpeningPrice()
        {
            var openingPricePermitList = new List<string> { "USD/TRY", "USD/PKR", "EUR/TRY", "USD/PKR", "GBP/TRY", "GBP/PKR" };
            var fxValues = _cache.Get<Dictionary<string, CurrencyPairNameValue>>("Currencies");
            var currencies = new Dictionary<string, CurrencyPairNameValue>(fxValues);
            var fxList = fxValues.Where(x => openingPricePermitList.Contains(x.Key)).Select(x => x.Value);
            foreach (var fxValue in fxList)
            {
                var client = new RestClient("https://www.investing.com/instruments/HistoricalDataAjax");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "text/plain, */*; q=0.01");
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Cookie", "adBlockerNewUserDomains=1587290520; PHPSESSID=tkelsa1e92u0r8t5k2cqcdurho; StickySession=id.70032824951.943_www.investing.com");
                request.AddParameter("action", "historical_data");
                request.AddParameter("curr_id", fxValue.FxId.ToString());
                request.AddParameter("end_date", DateTime.Now.ToString("MM/dd/yyyy"));
                //request.AddParameter("header", "USD/TRY Historical Data");
                request.AddParameter("interval_sec", "Daily");
                request.AddParameter("smlID", "106699");
                request.AddParameter("sort_col", "date");
                request.AddParameter("sort_ord", "DESC");
                request.AddParameter("st_date", DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy"));
                IRestResponse response = client.Execute(request);

                HtmlDocument pageDocument = new HtmlDocument
                {

                    OptionFixNestedTags = true,
                    OptionCheckSyntax = true,
                    OptionAutoCloseOnEnd = true
                };
                pageDocument.LoadHtml(response.Content);
                var openingPrice = pageDocument.DocumentNode.SelectSingleNode("(//table[@id='curr_table']//tbody//tr//td[3])").InnerText;
                var value = Convert.ToDecimal(openingPrice, new CultureInfo("en-US"));
                var openingPriceValue = new CurrencyValue
                {
                    DateTime = DateTime.Now.Date + new TimeSpan(09, 00, 0),
                    Value = value
                };
                var currencyPair = new CurrencyPairNameValue
                {
                    Code = fxValue.Code,
                    FxId = fxValue.FxId,
                    FxOrder = fxValue.FxOrder,
                    Name = fxValue.Name,
                    Order = fxValue.Order,
                    Values = fxValue.Values
                };
                currencyPair.Values.AddFirst(openingPriceValue);
                if (currencyPair.Values.Count > 3)
                {
                    currencyPair.Values.Remove(currencyPair.Values.First.Next);
                }

                currencies[currencyPair.Code] = currencyPair;
            }
            _cache.Set("Currencies", fxValues);
            _isFirstRun = false;
        }

        private CurrencyPairNameValue GetFirstGoldPrices()
        {
            var client = new RestClient("https://www.investing.com/instruments/HistoricalDataAjax");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "text/plain, */*; q=0.01");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "adBlockerNewUserDomains=1587290520; PHPSESSID=tkelsa1e92u0r8t5k2cqcdurho; StickySession=id.70032824951.943_www.investing.com");
            request.AddParameter("action", "historical_data");
            request.AddParameter("curr_id", 68);
            request.AddParameter("end_date", DateTime.Now.ToString("MM/dd/yyyy"));
            //request.AddParameter("header", "USD/TRY Historical Data");
            request.AddParameter("interval_sec", "Daily");
            request.AddParameter("smlID", "106699");
            request.AddParameter("sort_col", "date");
            request.AddParameter("sort_ord", "DESC");
            request.AddParameter("st_date", DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy"));
            IRestResponse response = client.Execute(request);

            HtmlDocument pageDocument = new HtmlDocument
            {

                OptionFixNestedTags = true,
                OptionCheckSyntax = true,
                OptionAutoCloseOnEnd = true
            };
            pageDocument.LoadHtml(response.Content);
            var openingPrice = Convert.ToDecimal(pageDocument.DocumentNode.SelectSingleNode("(//table[@id='curr_table']//tbody//tr//td[3])").InnerText, new CultureInfo("en-US"));
            var xauusd = new CurrencyPairNameValue
            {
                Code = "XAU/USD",
                FxId = "68",
                FxOrder = 4,
                Name = "GOLD OUNCE",
                Order = 4,
                Values = new LinkedList<CurrencyValue>()
            };
            xauusd.Values.AddFirst(new CurrencyValue { DateTime = DateTime.Now.Date + new TimeSpan(09, 00, 0), Value = openingPrice });
            return xauusd;

        }

        private CurrencyPairNameValue GetGoldLastPrice()
        {
            var goldOunceCode = "XAU/USD";
            var client = new RestClient("https://www.investing.com/commodities/real-time-futures");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "adBlockerNewUserDomains=1587290520; PHPSESSID=gudril80af23qkeubvuolfo4mr; geoC=IE; prebid_page=0; prebid_session=0; gtmFired=OK; nyxDorf=NTNlN28nNmgxZzo2NXgxMj5nYzw%2BJzo5PDliYA%3D%3D; StickySession=id.22293894360.193_www.investing.com");
            IRestResponse response = client.Execute(request);

            HtmlDocument pageDocument = new HtmlDocument
            {

                OptionFixNestedTags = true,
                OptionCheckSyntax = true,
                OptionAutoCloseOnEnd = true
            };
            pageDocument.LoadHtml(response.Content);

            var lastPrice = Convert.ToDecimal(pageDocument.DocumentNode.SelectSingleNode("(//table[@id='cross_rate_1']//tbody//tr[2]//td[4])").InnerText, new CultureInfo("en-US"));


            var currencyPairs = _cache.Get<Dictionary<string, CurrencyPairNameValue>>("Currencies");
            var fx = new CurrencyPairNameValue();
            currencyPairs.TryGetValue(goldOunceCode, out fx);
            fx.Values.AddLast(new CurrencyValue
            {
                DateTime = DateTime.Now,
                Value = Convert.ToDecimal(lastPrice, new CultureInfo("en-US"))
            });

            if (fx.Values.Count > 3)
            {
                fx.Values.Remove(fx.Values.First.Next);
            }
                return fx;
        }

    }
}
