using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class AdminBaseViewModel
    {
        public ProfileModel Profile { get; set; }
        public AddUserModel AddUser { get; set; }
        public DashboardModel Dashboard { get; set; }
        public AppSettings AppSetting { get; set; }
        public SendGridOptions SendGridOption { get; set; }
        public SmtpOptions SmtpOption { get; set; }
        public ResetPasswordViewModel ResetPassword { get; set; }
        public SiteWideSettings SiteWideSetting { get; set; }
    }
}
