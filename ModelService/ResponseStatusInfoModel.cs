﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class ResponseStatusInfoModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
