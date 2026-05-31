using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Requests
{
    public class RegisterRequest : LoginRequest
    {
        public string Name { get; set; } = string.Empty;

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;


    }
}
