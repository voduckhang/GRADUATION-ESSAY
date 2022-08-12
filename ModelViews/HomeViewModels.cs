using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class HomeViewModels
    {
        public List<Tintuc> tintucs { get; set; }
        public List<ProductHomeViewModels> products { get; set; }
    }
}
