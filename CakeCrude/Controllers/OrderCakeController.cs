using CakeCrude.DbEntities;
using CakeCrude.Models;
using CakeCrude.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CakeCrude.Controllers
{
    public class OrderCakeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        private OrderCakeRepository _orderCakeRepository;

        public OrderCakeController(CakeCrudContext context, IHostingEnvironment hosting)
        {
            _orderCakeRepository = new OrderCakeRepository(context);
            hostingEnvironment = hosting;
        }

        public IActionResult Index()
        {


            var orderCakes = _orderCakeRepository.GetAll();

            var orderCakeViewModels = new List<OrderCakeViewModel>();
            foreach (var orderCake in orderCakes)
            {
                var orderCakeViewModel = new OrderCakeViewModel
                {
                    Id = orderCake.Id,
                    Name = orderCake.Name,
                    Surname = orderCake.Surname,
                    Phone = orderCake.Phone,
                    Email = orderCake.Email,
                    Comment = orderCake.Comment,
                    Date = orderCake.Date
                };

                orderCakeViewModels.Add(orderCakeViewModel);
            }

            return View("OrderList", orderCakeViewModels);
        }

        [HttpGet]
        public IActionResult OrderCake()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderCake(OrderCakeViewModel orderCakeViewModel)
        {

            if (orderCakeViewModel.File != null)
            {
                var path = $"{Environment.CurrentDirectory}\\Images\\{orderCakeViewModel.File.FileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    orderCakeViewModel.File.CopyTo(stream);
                }
            }

            var orderCare = new OrderCake
            {
                Name = orderCakeViewModel.Name,
                Surname = orderCakeViewModel.Surname,
                Phone = orderCakeViewModel.Phone,
                Email = orderCakeViewModel.Email,
                Comment = orderCakeViewModel.Comment,
                Date = DateTime.Now
            };


            _orderCakeRepository.Add(orderCare);




            return RedirectToAction("Index");
        }
    }
}