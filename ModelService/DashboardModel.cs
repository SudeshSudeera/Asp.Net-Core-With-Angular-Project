using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class DashboardModel
    {
        public int TotalUsers { get; set; }
        public int NewUsers { get; set; }
        public int PendingRequests { get; set; }
        public int TotalPosts { get; set; }
    }
}
