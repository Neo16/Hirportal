using Hirportal.Bll.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ErrorDto
    {       
        public ErrorCode ErrorCode { get; set; }
       
        public string[] ErrorMessages { get; set; } = new string[0];
    }
}
