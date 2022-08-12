using System;
using System.Collections.Generic;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Donhang
    {
        public Donhang()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        public int DonhangId { get; set; }
        public int KhachhangId { get; set; }
        public string Masodonhang { get; set; }
        public DateTime? Ngaytaodon { get; set; }
        public int? TrangthaidonhangId { get; set; }
        public string Diachigiaohang { get; set; }
        public int? Tongtien { get; set; }
        public int? TaikhoanId { get; set; }

        public virtual Khachhang Khachhang { get; set; }
        public virtual Nhanvien Taikhoan { get; set; }
        public virtual Trangthaidonhang Trangthaidonhang { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
