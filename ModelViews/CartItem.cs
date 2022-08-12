using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class CartItem
    {
        public Sanpham product { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * product.Giatien.Value;
    }
}
