using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.CreateCheckingAccount
{
    public class CreateCheckingAccountRequest
    {
        [Required]
        public int TradingAccount { get; set; }

        [Required]
        public int Brand { get; set; }
        [Required]

        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
