using ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityService
{
    public interface IActivitySvc
    {
        Task AddUserActivity(ActivityModel model);

        Task<List<ActivityModel>> GetUserActivity(string userId);
    }
}
