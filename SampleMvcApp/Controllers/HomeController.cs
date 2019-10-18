using Har.AspNetCore.Mvc.Alerts.Services;
using Har.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Data;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlertService _alert;



        public HomeController(IAlertService alertService,
            IRepository<Product, int> repository)
        {
            _alert = alertService;
        }

        public IActionResult Index()
        {

            _alert.InfoAlert("Test Title", "Test Message");

            _alert.ErrorAlert("Error Title", "Error message");


            return View();
        }
    }


}
