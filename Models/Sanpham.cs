using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        public int SanphamId { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập Tên Sản Phẩm")]
        public string Tensanpham { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Mô Tả Sản Phẩm")]
        public string Motasanpham { get; set; }
        public int DanhmucId { get; set; }
        public string Hinhanh { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Số Lượng Tồn Kho")]
        [Range(0, 999999999, ErrorMessage = "Số Lượng Không Được Nhỏ Hơn 0")]
        public int? Tonkho { get; set; }
        public string Dungluong { get; set; }
        public int HedieuhanhId { get; set; }
        [Required(ErrorMessage ="Vui Lòng Nhập Giá Tiền")]
        [Range(0,999999999,ErrorMessage ="Số Tiền Không Được Nhỏ Hơn 0")]
        public int? Giatien { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
        public virtual Hedieuhanh Hedieuhanh { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
