using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace soft.test.lib.api2.services
{
    public class JurosRateService
    {
        public decimal Get(string url)
        {
            lock (this)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url).Result;

                    var culture = new CultureInfo("en-US");
                    decimal.TryParse(response.Content.ReadAsStringAsync().Result, NumberStyles.Float, culture, out decimal result);

                    return result;
                }
            }            
        }
    }
}
