using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Donhangs = new HashSet<Donhang>();
        }

        public int KhachhangId { get; set; }
        public string Hovaten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Sodienthoai { get; set; }
        public DateTime? Landangnhapgannhat { get; set; }
        public string Matkhau { get; set; }
        public bool? TrangthaiId { get; set; }

        public virtual Trangthai Trangthai { get; set; }
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
