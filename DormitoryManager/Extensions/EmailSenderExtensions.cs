using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DormitoryManager.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Xác nhận email",
                $"Xác thực tài khoản của bạn bằng cách truy cập đường link này: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
