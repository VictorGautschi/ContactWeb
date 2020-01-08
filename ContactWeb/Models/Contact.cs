using System;
using System.ComponentModel.DataAnnotations;

namespace ContactWeb.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(ContactWebConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(ContactWebConstants.MAX_FIRST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [StringLength(ContactWebConstants.MAX_EMAIL_LENGTH)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Phone is Required")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [StringLength(ContactWebConstants.MAX_PHONE_LENGTH)]
        public string PhonePrimary { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(ContactWebConstants.MAX_PHONE_LENGTH)]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }
        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(ContactWebConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public int StateId { get; set; } 
        public virtual State State { get; set; }

        [Required(ErrorMessage = "Zip Code is Required")]
        [Display(Name ="Zip Code")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada
        [StringLength(ContactWebConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactWebConstants.MIN_ZIP_CODE_LENGTH)]
        public string Zip { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Display(Name ="Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => string.IsNullOrWhiteSpace(StreetAddress2)
                                            ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                                            : $"{StreetAddress1}, {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";
    }
}
