using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterRepository _newsletterRepository;

        public NewsletterService(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        public IList<NewsletterResult> GetAllNewsletter()
        {
            IList<NewsletterDto> newsletters = _newsletterRepository.GetAll();

            return newsletters.Select(newsletter => NewsletterParse(newsletter)).ToList();
        }

        public NewsletterResult SaveNewsletter(NewsletterResult newsletterResult)
        {
            if (newsletterResult == null || newsletterResult.NewsletterForm == null)
                throw new ArgumentNullException("No NewsletterForm send");

            if (string.IsNullOrEmpty(newsletterResult.NewsletterForm.Email))
                throw new ArgumentException("Empty email", nameof(newsletterResult.NewsletterForm.Email));

            var newsletterDto = NewsletterParse(newsletterResult);

            if (_newsletterRepository.GetByEmail(newsletterDto.Email) == null)
            {
                newsletterDto.Id = 0;
                newsletterDto = _newsletterRepository.Insert(newsletterDto);
            }
            else
            {
                newsletterDto = _newsletterRepository.GetByEmail(newsletterDto.Email);
            }

            return NewsletterParse(newsletterDto);
        }

        public NewsletterResult GetNewsletter(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Empty email", nameof(email));

            var newsletterDto = _newsletterRepository.GetByEmail(email);
            if (newsletterDto == null)
                throw new ArgumentException("Invalid email", nameof(newsletterDto.Email));

            return NewsletterParse(newsletterDto);
        }

        public bool DeleteNewsletter(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Empty email", nameof(email));

            var newsletterDto = _newsletterRepository.GetByEmail(email);
            

            return _newsletterRepository.Delete(newsletterDto);
        }

        private NewsletterResult NewsletterParse(NewsletterDto newsletterDto)
        {
            NewsletterResult newsletterResult = new NewsletterResult
            {
                NewsletterForm = new NewsletterForm()
            };

            newsletterResult.NewsletterForm.Email = newsletterDto.Email;

            return newsletterResult;
        }

        private NewsletterDto NewsletterParse(NewsletterResult newsletterResult)
        {
            NewsletterDto newsletterDto = new NewsletterDto
            {
                Email = newsletterResult.NewsletterForm.Email
            };

            return newsletterDto;
        }
    }
}
