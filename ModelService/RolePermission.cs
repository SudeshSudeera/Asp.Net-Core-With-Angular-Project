using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }
        public bool Read { get; set; }
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public bool Add { get; set; }
        public string Type { get; set; }
        public string ApplicationRoleId { get; set; }
    }
}
