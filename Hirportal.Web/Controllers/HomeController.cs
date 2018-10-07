using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hirportal.Models;
using Hirportal.Web.Models;
using Hirportal.Bll.ServiceInterfaces;

namespace Hirportal.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFormService formService;

        public HomeController(IFormService formService)
        {
            this.formService = formService;
        }

        public IActionResult Index()
        {
            return View();
        }       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitedForm([FromBody] ExampleFormViewmodel model)
        {
            string message = "Works!";
            await formService.addForm(new Model.Form()
            {
                Comments = model.Comments,
                Email = model.Email,
                FullName = model.FullName
            });
            return Json(new {  message });
        }
    }
}
