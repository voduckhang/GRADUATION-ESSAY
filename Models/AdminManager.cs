using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class AdminManager
    {
        public bool AdminId { get; set; }
        public string TenAdmin { get; set; }
        public int PhanquyenId { get; set; }
        public string MatkhauAdmin { get; set; }

        public virtual Phanquyen Phanquyen { get; set; }
    }
}
