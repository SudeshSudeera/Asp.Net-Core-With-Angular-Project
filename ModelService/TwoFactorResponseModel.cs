﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class TwoFactorResponseModel
    {
        public bool IsValid { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public bool RememberDevice { get; set; }
        public int Attempts { get; set; }
        public ResponseStatusInfoModel ResponseMessage { get; set; }
    }
}
