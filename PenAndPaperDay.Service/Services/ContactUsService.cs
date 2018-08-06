using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using PenAndPaperDay.Core.Configuration;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Service.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IEmailSenderService _emailSender;
        private readonly IOptions<PenAndPaperConfiguration> _penAndPaperConfiguration;

        public ContactUsService(IEmailSenderService emailSender, IOptions<PenAndPaperConfiguration> penAndPaperConfiguration)
        {
            _emailSender = emailSender;
            _penAndPaperConfiguration = penAndPaperConfiguration;
        }

        public ContactUsResult ContactUs(ContactUsResult contactUs)
        {
            if(contactUs.ContactUsForm == null)
                throw new ArgumentNullException("No ContactUsForm send");

            if(string.IsNullOrEmpty(contactUs.ContactUsForm.Email))
                throw new ArgumentException("Empty Email", nameof(contactUs.ContactUsForm.Email));

            if (string.IsNullOrEmpty(contactUs.ContactUsForm.Text))
                throw new ArgumentException("Empty Text", nameof(contactUs.ContactUsForm.Text));

            string admin = _penAndPaperConfiguration.Value.EmailSender;

            IList<string> to = new List<string>();
            to.Add(admin);
            to.Add(contactUs.ContactUsForm.Email);
            
            _emailSender.SendMail(to, "Contact Us", "New Request with content: " + contactUs.ContactUsForm.Text);

            return contactUs;
        }
    }
}
