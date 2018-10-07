using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hirportal.Models;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Web.Controllers;
using AutoMapper;
using Hirportal.Bll.Models;
using Hirportal.Model;

namespace Hirportal.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IFormService formService;

        public HomeController(IMapper mapper, IFormService formService): base(mapper)
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
        public async Task<IActionResult> SubmitedForm([FromBody] ExampleFormData model)
        {
            var form = mapper.Map<Form>(model);
            await formService.addForm(form);

            string message = "Works!";
            return Json(new {  message });
        }
    }
}
