using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApp.Shared.Models
{
    public record class ClientModel : IValidatableObject
    {
        public const string PhonePattern = @"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$";
        public const string ZipPattern = @"^\d{5}(-\d{4})?$";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(PhonePattern, ErrorMessage = "Enter a valid phone number, e.g. (555) 123-4567.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        [RegularExpression(ZipPattern, ErrorMessage = "Enter a valid ZIP code, e.g. 12345 or 12345-6789.")]
        public string? ZipCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(Address) && string.IsNullOrWhiteSpace(ZipCode))
            {
                yield return new ValidationResult(
                    "ZIP code is required when an address is entered.",
                    [nameof(ZipCode)]);
            }
        }
    }
}
