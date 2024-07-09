using System.ComponentModel.DataAnnotations;

namespace VantageCoreDomain.Customer
{

    public class Email
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email needs to be valid")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set ; }

    }
}
