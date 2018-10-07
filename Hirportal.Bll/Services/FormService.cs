using Hirportal.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Data;

namespace Hirportal.Bll.Services
{
    public class FormService : ServiceBase, IFormService
    {
        public FormService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task addForm(Form form)
        {
            context.Form.Add(form);
            await context.SaveChangesAsync();
        }
    }
}
