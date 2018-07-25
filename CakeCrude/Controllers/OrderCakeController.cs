using CakeCrude.DbEntities;
using CakeCrude.Models;
using CakeCrude.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeCrude.Controllers
{
    public class OrderCakeController : Controller
    {
        private OrderCakeRepository _orderCakeRepository;

        public OrderCakeController(CakeCrudContext context)
        {
            _orderCakeRepository = new OrderCakeRepository(context);
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