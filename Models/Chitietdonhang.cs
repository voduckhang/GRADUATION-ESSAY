using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Chitietdonhang
    {
        public int ChitietdonhangId { get; set; }
        public int DonhangId { get; set; }
        public int SanphamId { get; set; }
        public int? Tongtien { get; set; }
        public int? Soluong { get; set; }
        public DateTime? Ngaylaphoadon { get; set; }
        public int? GiaTien { get; set; }

        public virtual Donhang Donhang { get; set; }
        public virtual Sanpham Sanpham { get; set; }
    }
}
