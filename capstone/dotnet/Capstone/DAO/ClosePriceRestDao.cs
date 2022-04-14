using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;

namespace Capstone.Services
{
    public class ClosePriceRestDao : IClosePriceDao
    {
       
        private readonly RestClient client = new RestClient();

        public ClosePrice GetPrice(string stockTicker)
        {

            string first = "https://api.polygon.io/v1/open-close/";
            string second = "/2020-10-14?adjusted=true&apiKey=katsjNypap5pM3XpvIDU8ypcVp9EiMrx";

            RestRequest request = new RestRequest($"{first}{stockTicker}{second}");
            IRestResponse<ClosePrice> response = client.Get<ClosePrice>(request);

            return response.Data;
        }
    }
}
