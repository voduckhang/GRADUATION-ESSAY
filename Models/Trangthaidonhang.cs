using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Trangthaidonhang
    {
        public Trangthaidonhang()
        {
            Donhangs = new HashSet<Donhang>();
        }

        public int TrangthaidonhangId { get; set; }
        public string Tentrangthaidonhang { get; set; }

        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
