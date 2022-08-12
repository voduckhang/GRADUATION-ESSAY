using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Trangthai
    {
        public Trangthai()
        {
            Khachhangs = new HashSet<Khachhang>();
            Nhanviens = new HashSet<Nhanvien>();
        }

        public bool TrangthaiId { get; set; }
        public string Tentrangthai { get; set; }

        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
