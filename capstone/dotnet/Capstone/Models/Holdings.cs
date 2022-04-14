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


        public Holdings(decimal balance) : base(gamename)
        {

            this.Balance = balance;

        }
    }

}
