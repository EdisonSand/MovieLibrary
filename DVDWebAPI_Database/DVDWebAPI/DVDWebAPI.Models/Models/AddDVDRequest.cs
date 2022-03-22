using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDWebAPI.Models
{
    public class AddDVDRequest:IValidatableObject
    {
       
        public string director { get; set; }
        public string rating { get; set; }
        [Required]
        public string dvdTitle { get; set; }
        [Required]
        public int releaseYear { get; set; }
        public string Notes { get; set; }
      //  public DVD currentState { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (director.Length > 60 || director == null || director == "") { //too long for database
                errors.Add(new ValidationResult("Director name is greater than 60 characters ",
                    new[] { "director" }));
            }
            if (rating.Length >5)
            { //too long for database
                errors.Add(new ValidationResult("Rating is greater than 5 characters.",
                    new[] { "rating" }));
            }
            if (dvdTitle.Length > 60 || dvdTitle == null || dvdTitle == "")
            { //too long for database
                errors.Add(new ValidationResult("DVD Title is greater than 60 characters or is empty.",
                    new[] { "dvdTitle" }));
            }

            if (releaseYear < 1900 || releaseYear> 2026)
            { //too long for database
                errors.Add(new ValidationResult("Please enter a release year between 1900 and 2026",
                    new[] { "releaseYear" }));
            }
            if (Notes.Length > 150 || Notes == null || Notes == "")
            { //too long for database
                errors.Add(new ValidationResult("DVD Title is greater than 60 characters or is empty.",
                    new[] { "Notes" }));
            }
            return errors;
        }
    }
}