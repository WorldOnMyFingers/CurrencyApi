using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CurrencyApi.Models;
using CurrencyApi.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IMemoryCache _cache;

        public CurrencyController(ILogger<CurrencyController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<CurrencyPairNameValue> Get(string localCurrencySymbol)
        {
            var watch = new Stopwatch();
            watch.Start();
            var usdLocalFxCode = "USD/" + localCurrencySymbol.ToUpper();
            CurrencyPairNameValue ounceFx;
            CurrencyPairNameValue localFx;
            var data = _cache.Get<Dictionary<string, CurrencyPairNameValue>>("Currencies");
            data.TryGetValue("XAU/USD", out ounceFx);
            data.TryGetValue(usdLocalFxCode, out localFx);
            var symbol = Data.GetCurrencySymbolByCode(localCurrencySymbol);
            var forex = data.Where(x => x.Key.ToLower().Contains("/" + localCurrencySymbol.ToLower()) ||
            x.Key.ToLower().Contains("xau/usd")).Take(30).Select(x => new CurrencyPairNameValue
            {
                Code = new string(x.Key.Take(3).ToArray()),
                Name = Data.currencyNameAndCodes[new string(x.Key.Take(3).ToArray())].Name,
                Values = x.Value.Values,
                Order = Data.currencyNameAndCodes[new string(x.Key.Take(3).ToArray())].Order,
                LocalCurrencySymbol = symbol
            }).ToList();
            if (ounceFx.Values.Last.Previous == null || localFx.Values.Last.Previous == null) System.Threading.Thread.Sleep(10000);
            var customGolds = Data.CountrySpecificGoldUnits.Where(x => x.LocalCurrencyCode.ToLower() == localCurrencySymbol.ToLower()).Select(x => new CurrencyPairNameValue
            {
                Code = x.Name,
                Order = 5,
                LocalCurrencySymbol = symbol,
                Values = new LinkedListWithInit<CurrencyValue> {
                    x.CalculatePrice(ounceFx.Values.First.Value.Value, localFx.Values.First.Value.Value),
                    x.CalculatePrice(ounceFx.Values.Last.Previous.Value.Value, localFx.Values.Last.Previous.Value.Value),
                    x.CalculatePrice(ounceFx.Values.Last.Value.Value, localFx.Values.Last.Value.Value),
                },
            }).ToList();
            forex.AddRange(customGolds);
            watch.Stop();
            Console.Out.WriteLine(watch.ElapsedMilliseconds);
            forex.FirstOrDefault(x => x.Code == "XAU").LocalCurrencySymbol = "$";
            return forex;
        }
    }
}