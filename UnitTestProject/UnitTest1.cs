using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet2017.AppCode;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void T1_inCurrentPayPeriod_In_Range()
        {
            /***************************************************************************************
            The target method must accepts a string date argument and returns a boolean true
            if the date falls within the current work week.  A current work week is defined as
            the period between 12:00 AM last Sunday through 11:59 PM the following Saturday.
            ****************************************************************************************/
            
            //Arrange
            DateIs testDate = new DateIs();
           
            //Act
            bool result = testDate.inCurrentPayPeriod("8/13/2016");
          
            //Assert
            Assert.AreEqual(true, result);  // today's date = current pay period
        }

        [TestMethod]
        public void T2_inCurrentPayPeriod_Not_Valid_Date()
        {
            /***************************************************************************************
            The target method must accept a string argument and returns a boolean false if the 
            string does not resolve to a date.  Although information is validated before going into
            the database, this should handle corrupt inputs. 
            ****************************************************************************************/
            
            //Arrange
            DateIs testDate = new DateIs();

            //Acts
            bool result = testDate.inCurrentPayPeriod("f%%%$$da'SELECT *'(*&^--333");  // non-date garbage
            
            //Assert
            Assert.AreEqual(false, result);  // presumed garbage input
        }

        [TestMethod]
        public void T3_inCurrentPayPeriod_Out_Of_Range()
        {
            /***************************************************************************************
            The target method must accepts a string date argument and returns a boolean false
            if the date falls outside the current work week.  A current work week is defined as
            the period between 12:00 AM last Sunday through 11:59 PM the following Saturday.
            ****************************************************************************************/
            
            //Arrange
            DateIs testDate = new DateIs();

            //Acts    -   Certainly out of range (Past or Future)
            DateTime test = DateTime.Now.Date.AddDays(7);
            bool result1 = testDate.inCurrentPayPeriod(Convert.ToString(DateTime.Now.Date.AddDays(-7)));
            bool result2 = testDate.inCurrentPayPeriod(Convert.ToString(DateTime.Now.Date.AddDays(7)));  

            //Assert   -   if the function returns a true for either or both, the assert fails
            Assert.AreEqual(false, result1 || result2);            
        }
    }
}
