using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using LUANVANTOTNGHIEP_VODUCANKHANG.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public Task SendEmailAsync(SendMailDTO mailRequest)
        {
            throw new NotImplementedException();
        }
    }
}
