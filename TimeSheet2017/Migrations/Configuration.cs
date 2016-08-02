namespace TimeSheet2017.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeSheet2017.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimeSheet2017.Models.ApplicationDbContext context)
        {
            /////// this creates a super user acct: Manager@Timesheet2017.com if not already existing in db ///////////
            if (!context.Users.Any(u => u.UserName == "Manager@Timesheet2017.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Manager@Timesheet2017.com", Email = "Manager@Timesheet2017.com" };
                manager.Create(user, "ManagerPS_1");
            }
           


            /*
                        context.Clients.AddOrUpdate(
                              p => p.ClientID,
                              new Models.Client
                              {
                                  ClientID = 1001,
                                  CompanyName = "Lothlorien Health Systems",
                                  Address = "2200 Malorn Way",
                                  City = "Caros Galadhon",
                                  State = "LothLorien",
                                  Zipcode = "11223",
                                  PhoneNumber = "123-456-7891",
                                  Email = "galadriel@LHS.com",
                                  ContactName = "Galadriel"
                              },
                              new Models.Client
                              {
                                  ClientID = 1003,
                                  CompanyName = "White Tree Cancer Center",
                                  Address = "5600 White Tree Lane",
                                  City = "Minas Tirith",
                                  State = "Gondor",
                                  Zipcode = "44556",
                                  PhoneNumber = "123-456-7891",
                                  Email = "Aragorn@WhiteTree.com",
                                  ContactName = "Aragorn"
                              }

                            );

                        context.TimeLogs.AddOrUpdate(
                        p => p.LogID,
                        new Models.TimeLog
                        {
                            TimeStamp = DateTime.Now,
                            AssociateName = "Jimi Hendrix",
                            ClientID = 1001,
                            WorkDate = DateTime.Now,
                            NumberHours = 7,
                            WorkType = "Abstract",
                            JobNote = "If six turned out to be nine, I don't mind."
                        },
                        new Models.TimeLog
                        {
                            TimeStamp = DateTime.Now,
                            AssociateName = "Edward Van Hallen",
                            ClientID = 1001,
                            WorkDate = DateTime.Now,
                            NumberHours = 4,
                            WorkType = "Abstract",
                            JobNote = "I might as well jump."
                        },
                        new Models.TimeLog
                        {
                            TimeStamp = DateTime.Now,
                            AssociateName = "Stevie Ray Vaughan",
                            ClientID = 1003,
                            WorkDate = DateTime.Now,
                            NumberHours = 5,
                            WorkType = "Case finding",
                            JobNote = "I've been walking the tightrope."
                        }
                      );
                      */
        }
    }
}
