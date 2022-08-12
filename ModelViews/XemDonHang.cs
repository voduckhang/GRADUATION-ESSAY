using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class XemDonHang
    {
        public Donhang DonHang { get; set; }
        public List<Chitietdonhang> ChiTietDonHang { get; set; }
    }
}
