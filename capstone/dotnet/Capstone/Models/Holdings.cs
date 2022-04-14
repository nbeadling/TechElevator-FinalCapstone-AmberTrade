using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.Models
{
    public class Holdings : Game
    {
        public decimal Balance { get; set; }

        public string Stock { get; set; } = "";


        public Holdings(decimal balance, string stock)
        {

            this.Balance = balance;
            this.Stock = stock;
        }

        public Holdings()
        {


        }

    }

}
