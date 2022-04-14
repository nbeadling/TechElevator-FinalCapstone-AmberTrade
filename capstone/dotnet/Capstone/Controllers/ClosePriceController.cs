using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;


namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClosePriceController : ControllerBase
    {
        private readonly IClosePriceDao closePriceDao;
        public ClosePriceController(IClosePriceDao closePriceDao)
        {
            this.closePriceDao = closePriceDao;
        }

        [HttpGet("/getprice/{stockTicker}")]
        public ClosePrice GetPrice(string stockTicker)
        {
            ClosePrice price = closePriceDao.GetPrice(stockTicker);
            return price;
        }
    }






}
