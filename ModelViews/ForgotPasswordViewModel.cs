using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class ForgotPasswordViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
