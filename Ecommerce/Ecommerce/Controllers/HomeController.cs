﻿using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}