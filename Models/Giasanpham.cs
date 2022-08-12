using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Giasanpham
    {
        public int GiasanphamId { get; set; }
        public int SanphamId { get; set; }
        public string Giatien { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
