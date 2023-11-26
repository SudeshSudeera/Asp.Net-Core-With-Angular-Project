using ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardService
{
    public interface IDashboardSvc
    {
        Task<DashboardModel> GetDashboardData();
    }
}
