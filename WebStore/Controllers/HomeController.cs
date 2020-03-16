using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Elements()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SingleBlog()
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }

        public IActionResult Tracking()
        {
            return View();
        }
    }
}