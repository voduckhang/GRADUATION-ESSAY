using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Donhangs = new HashSet<Donhang>();
            Tintucs = new HashSet<Tintuc>();
        }

        public int TaikhoanId { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Họ Và Tên")]
        public string Hovaten { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập Mật Khẩu")]
        [MinLength(5,ErrorMessage ="Mật Khẩu Phải Tối Thiểu 5 Ký Tự")]
        public string Matkhau { get; set; }
        public int PhanquyenId { get; set; }
        public DateTime? Ngaytao { get; set; }
        public bool? TrangthaiId { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập Số CMND hoặc Căn Cước Công Dân")]
        [MinLength(9,ErrorMessage ="Số CMND hoặc Căn Cước Công Dân phải trên 9 số")]
        public string Cmnd { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Ngày Sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Địa Chỉ")]
        public string Diachi { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Giới Tính")]
        public string Gioitinh { get; set; }

        public virtual Phanquyen Phanquyen { get; set; }
        public virtual Trangthai Trangthai { get; set; }
        public virtual ICollection<Donhang> Donhangs { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }

    }
}
