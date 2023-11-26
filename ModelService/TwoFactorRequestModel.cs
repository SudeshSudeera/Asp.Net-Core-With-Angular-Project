using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class TwoFactorRequestModel
    {
        public string ProviderType { get; set; }
        public string TwoFactorToken { get; set; }
        public bool RememberDevice { get; set; }
    }
}
