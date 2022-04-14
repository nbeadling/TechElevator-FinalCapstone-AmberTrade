using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.Models
{
    public class Holdings
    {
        public string UserName { get; set; }
        public string GameName { get; set; }
        public decimal Balance { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }


        public Holdings(string userName, string gameName, decimal balance, DateTime startTime, DateTime endDate)
        {
            this.UserName = userName;
            this.GameName = gameName;
            this.Balance = balance;
            this.StartTime = startTime;
            this.EndDate = endDate;
        }

        public Holdings()
        {


        }

    }

}
