using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.DTO
{
    public class Error
    {
        public List<Errors> errors;
    }

    public class Errors
    {
        public int? id;
        public int? codigo;
        public string mensaje;
    }

}
