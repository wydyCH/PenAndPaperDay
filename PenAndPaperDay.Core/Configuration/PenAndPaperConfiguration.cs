namespace PenAndPaperDay.Core.Configuration
{
    /// <summary>
    /// Use IOption<PenAndPaperConfiguration>
    /// </summary>
    public class PenAndPaperConfiguration
    {
        public string EmailSender { get; set; }

        public string EmailSenderName { get; set; }

        public string SendGridAPIKey { get; set; }        
    }
}
