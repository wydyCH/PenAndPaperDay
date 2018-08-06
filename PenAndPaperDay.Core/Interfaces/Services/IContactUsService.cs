using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IContactUsService
    {
        ContactUsResult ContactUs(ContactUsResult contactUs);
    }
}
