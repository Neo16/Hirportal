using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Web.Controllers;
using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Model;
using Hirportal.Web.ViewModels;

namespace Hirportal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormService formService;
        protected readonly IMapper mapper;

        public HomeController(IMapper mapper, IFormService formService)
        {
            this.formService = formService;
            this.mapper = mapper;
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
        public async Task<IActionResult> SubmitedForm([FromBody] ExampleFormData model)
        {
            var form = mapper.Map<Form>(model);
            await formService.addForm(form);

            string message = "Works!";
            return Json(new {  message });
        }
    }
}
