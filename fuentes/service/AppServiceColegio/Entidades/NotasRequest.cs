﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class NotasRequest : BaseRequest
    { 
        public String clase { get; set; }
        public String nota { get; set; } 
        public String tipo { get; set; }
    } 
}
