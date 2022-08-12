using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Phanquyen
    {
        public Phanquyen()
        {
            AdminManagers = new HashSet<AdminManager>();
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int PhanquyenId { get; set; }
        public string Tenquyentruycap { get; set; }

        public virtual ICollection<AdminManager> AdminManagers { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
