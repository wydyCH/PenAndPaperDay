using System;
using System.Collections.Generic;
using System.Text;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IEmailSenderService
    {
        bool SendMail(IList<string> to, string subject, string body);
    }
}
