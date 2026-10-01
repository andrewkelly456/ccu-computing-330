using System;
using Xunit;

namespace DateProject.Tests
{
    public class DateTests
    {
        [Fact]
        public void MonthName_MonthIs1_ReturnsJanuary()
        {
            //Arrange
            Date d = new Date();
            //Setting up a new Date where the month is 1 (default construct)

            //Act
            string monthName = d.MonthName;

            //Assert
            Assert.Equal("January", monthName);
            //Expected value, acutal value
        }
        [Fact]

        public void MonthName_Monthis2_ReturnsFebruary()
        {
            //Arange
            Date d = new Date(2020, 2, 1);

            //Act
            string monthName = d.MonthName;
            //Call the method that were testing to assign the value

            //Assert
            Assert.Equal("February", monthName);
        }

        [Theory]
        [InlineData(12, "December")]
        [InlineData(11, "November")]
        [InlineData(10, "October")]
        [InlineData(9, "September")]
        [InlineData(8, "August")]
        public void MonthName_Monthis1To12_ReturnsCorrectMonth(int monthNum, string name)
        {
            //Arange
            Date d = new Date(2020, monthNum, 1);

            //Act
            string monthName = d.MonthName;
            //Call the method that were testing to assign the value

            //Assert
            Assert.Equal(name, monthName);
        }

        [Fact] 
        public void MonthConstructor_YearIsTooBig_ThrowsArgumentOutOfRangeException()
        {
            //Arange
            int year = 10000;
           //Act
            Date d; //  = new Date(year, 1, 1);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(year,1,1));
        }

        [Fact] 
        public void DateConstructor_YearIsTooSmall_ThrowsArgumentOutOfRangeException()
        {
            //Arange
            int year = -10000;
           //Act
            Date d; //  = new Date(year, 1, 1);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(year,1,1));
        }

        [Fact]
        public void DateConstructor_MonthIsTooSmall_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            int month = 0;

            //Act
            Date d; // = new Date(1000, month, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(1000,month,1));
        }

        [Fact]
        public void DateConstructor_MonthIsTooBig_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            int month = 13;

            //Act
            Date d; // = new Date(1000, month, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(1000,month,1));
        }

        [Fact]
        public void DateConstructor_MonthIs30DayMax_DayIsBetween1And30_DateSetAccordingToParameters()
        {
            //Arrange
            int day = 30;
            int month = 4;
            //Act
            Date d = new Date(1000, month, day);
            //Assert
            Assert.Equal(1000, d.Year);
            Assert.Equal(month, d.Month);
            Assert.Equal(day, d.Day);
        }

        [Fact]
        public void DateConstructor_MonthIs30DayMax_DayIsNotBetween1And30_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            int day = 31;
            int month = 4;
            //Act
            Date d; // = new Date(1000, month, day);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(1000, month, day));
        }

        //Add tests for MonthIs31DayMax and DayBetween1And31
        //Add tests for MonthIs31DaysMax and DayNotBetween1And31
        //Add test for MonthIsFebruary and DayBetween1And28
        //Add test for MonthIsFebrurary and DayNotBetween1And28
    }
}
