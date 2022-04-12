using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;

namespace Capstone.Services
{
    public class ClosePriceDao : IClosePriceDao
    {
        private static readonly string APIUrl = "https://api.polygon.io/v1/open-close/C/2020-10-14?adjusted=true&apiKey=katsjNypap5pM3XpvIDU8ypcVp9EiMrx";
        private readonly RestClient client = new RestClient();

        public ClosePrice GetPrice()
        {
            RestRequest request = new RestRequest(APIUrl);
            IRestResponse<ClosePrice> response = client.Get<ClosePrice>(request);

            return response.Data;
        }
    }
}
