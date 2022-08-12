using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(SendMailDTO mailRequest);
    }
}
