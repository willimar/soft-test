using Soft.CalculateInterest.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace Soft.CalculateInterest.Domain.services
{
    public class JurosRateService: INavigator
    {
        private readonly HttpClient _httpClient;

        public JurosRateService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public decimal Get(string url)
        {
            lock (this)
            {
                var response = this._httpClient.GetAsync(url).Result;

                var culture = new CultureInfo("en-US");
                decimal.TryParse(response.Content.ReadAsStringAsync().Result, NumberStyles.Float, culture, out decimal result);

                return result;
            }            
        }
    }
}
