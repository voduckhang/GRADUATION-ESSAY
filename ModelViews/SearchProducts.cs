using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class SearchProducts
    {
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string tensp { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
