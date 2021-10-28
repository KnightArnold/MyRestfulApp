using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.ResourceParameters;
using MyRestfulApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRestfulApp.Controllers
{
    [ApiController]
    [Route("MyRestfulApp/monedas")]
    public class CurrenciesController : ControllerBase
    {
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private readonly IMapper _mapper;
        

        public CurrenciesController(IMyRestfulAppRepository myRestfulAppRepository,
            IMapper mapper)
        {
            _myRestfulAppRepository = myRestfulAppRepository ?? throw new ArgumentNullException(nameof(myRestfulAppRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));          
        }

        [HttpGet()]        
        public async Task<IActionResult> GetCurrencies(
            [FromQuery] CurrencyResourceParameters currencyResourceParameters)
        {            
            if (currencyResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(currencyResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(currencyResourceParameters.from)
               && string.IsNullOrWhiteSpace(currencyResourceParameters.todolar))
            {
                var currenciesFromRepo = await _myRestfulAppRepository.GetCurrenciesAsync();
                var options = new JsonWriterOptions { Indented = true };

                using (var fs = new FileStream(@"C:\currencies.json", FileMode.Create, FileAccess.Write, FileShare.None))
                using (var writer = new Utf8JsonWriter(fs, options))
                {
                    JsonSerializer.Serialize(writer, currenciesFromRepo);
                }

                return Ok(currenciesFromRepo);
            }

            var currencyConversionFromRepo = await _myRestfulAppRepository.GetCurrencyConversionAsync(currencyResourceParameters);

            if (currencyConversionFromRepo == null)
            {
                return NotFound();
            }

            var path = @"C:\currencyConversion.csv";
            List<string> contents = new List<string>();
            List<string> acumRatio = new List<string>();
            if (System.IO.File.Exists(path))
            {
                contents = System.IO.File.ReadAllLines(path).ToList();
                acumRatio.AddRange(contents);
            }
            
            acumRatio.Add(currencyConversionFromRepo.ratio.ToString());            
            string csvAcumRatio = String.Join(",", acumRatio);
            System.IO.File.WriteAllText(path, csvAcumRatio);

            return Ok(currencyConversionFromRepo);
        }      
    }
}
