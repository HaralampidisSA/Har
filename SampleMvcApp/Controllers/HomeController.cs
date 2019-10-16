using Har.AspNetCore.Mvc.Alerts.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlertService _alert;

        public HomeController(IAlertService alertService)
        {
            _alert = alertService;
        }

        public IActionResult Index()
        {

            _alert.InfoAlert("Test Title", "Test Message");

            _alert.ErrorAlert(new Exception("Test Exception"));
            return View();
        }
    }
}
