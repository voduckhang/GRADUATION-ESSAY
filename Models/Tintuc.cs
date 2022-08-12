using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Tintuc
    {
        public int TintucId { get; set; }
        public string Tentintuc { get; set; }
        public string Noidung { get; set; }
        public string Hinhanhtintuc { get; set; }
        public string Tieude { get; set; }
        public DateTime? Ngaytaotintuc { get; set; }
        public int? TaikhoanId { get; set; }

        public virtual Nhanvien Taikhoan { get; set; }
    }
}
