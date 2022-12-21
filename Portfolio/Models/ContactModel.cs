using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ContactModel
    {
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public string PhoneNumber { get; set; }


        [Required, Display(Name = "Your name")]
        public string? FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string? FromEmail { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}

//https://www.mikesdotnetting.com/article/268/how-to-send-email-in-asp-net-mvc