using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ERPSystemMVCApp.EF; 

namespace ERPSystemMVCApp.Models
{
    public class BranchCreateRMModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int RegionId { get; set; }

        public string LocalAddress { get; set; }
        public string PoliceStation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public List<int> PermissionIds { get; set; }
    }
}