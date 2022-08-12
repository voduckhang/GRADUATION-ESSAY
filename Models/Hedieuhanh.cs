using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Hedieuhanh
    {
        public Hedieuhanh()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int HedieuhanhId { get; set; }
        public string Tenhedieuhanh { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
