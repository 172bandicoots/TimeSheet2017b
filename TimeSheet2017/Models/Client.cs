using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//holes information on all clients
namespace TimeSheet2017.Models
{
    public class Client
    {

        [Key]
        public int ClientID { get; set; }

        [Required, StringLength(50), Display(Name = "Client Name")]
        public string CompanyName { get; set; }

        [Required, StringLength(50), Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Required, StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }

        [Required, StringLength(25), Display(Name = "City")]
        public string City { get; set; }

        [Required, Display(Name = "State")]
        public String State { get; set; }

        [Required, DataType(DataType.PostalCode), RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Must be at correct 5 or full 9 digit format")]
        public String Zipcode { get; set; }

        [Required, Display(Name = "Contact Phone Number"), RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Phone number must be a 10 digit format.")]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Contact Email Address")]
        public string Email { get; set; }

        //set up one to many
        public virtual List<TimeLog> TimeLogs { get; set; }

    }
}