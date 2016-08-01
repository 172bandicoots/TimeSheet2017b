using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


//Holds log entries for all associates
namespace TimeSheet2017.Models
{
    public class TimeLog
    {
        [Key]
        public int LogID { get; set; }

        //Must stamp date every time a record is created
        public DateTime TimeStamp { get; set; }

        [Required, Display(Name = "Associate")]
        public String AssociateName { get; set; }

        [ForeignKey("Clients"), Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client Clients { get; set; }

        //The date that the hours occurred on
        [Required, Display(Name = "Date of Work")]
        public DateTime WorkDate { get; set; }

        //The number of hours worked on this entry for this client
        [Required, Display(Name = "Hours Worked")]
        public float NumberHours { get; set; }

        //A description of work performed
        [Required, Display(Name = "Type of Work")]
        public String WorkType { get; set; }

        //A description of work performed
        [Required, Display(Name = "Work Notes")]
        public String JobNote { get; set; }
    }
}