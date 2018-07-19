using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CakeCrude.Controllers
{
    public class OrderCakeController : Controller
    {

        [HttpGet]
        public IActionResult OrderCake()
        {
            return View("OrderCake");
        }

    }
}