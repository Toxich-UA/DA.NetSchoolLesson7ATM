using System.ComponentModel.DataAnnotations;

namespace Lesson7ATM.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string PinCode { get; set; }
    }
}