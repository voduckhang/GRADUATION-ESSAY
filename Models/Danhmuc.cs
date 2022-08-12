using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int DanhmucId { get; set; }
        public string Tendanhmuc { get; set; }
        public string Hinhanh { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
