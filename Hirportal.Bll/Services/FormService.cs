using Hirportal.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Data;

namespace Hirportal.Bll.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationDbContext context;

        public FormService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task addForm(Form form)
        {
            context.Form.Add(form);
            await context.SaveChangesAsync();
        }
    }
}
