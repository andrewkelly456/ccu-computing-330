using System;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace DateProject.Tests
{
    public class DateTests
    {
        //Date.Month Testing part of assignment
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void Month_Monthis1To12_ReturnsCorrectNumber(int monthNum)
        {
            //Arrange
            Date d = new Date(2020, monthNum, 1);
            //Act
            int month = d.Month;
            //Assert
            Assert.Equal(monthNum, month);
        }

        //Date.MonthNameAbbrev part of assignment
        [Theory]
        [InlineData(1, "Jan")]
        [InlineData(2, "Feb")]
        [InlineData(3, "Mar")]
        [InlineData(4, "Apr")]
        [InlineData(5, "May")]
        [InlineData(6, "Jun")]
        [InlineData(7, "Jul")]
        [InlineData(8, "Aug")]
        [InlineData(9, "Sep")]
        [InlineData(10, "Oct")]
        [InlineData(11, "Nov")]
        [InlineData(12, "Dec")]
        public void MonthNameAbbrev_MonthIsJanToDec_ReturnsCorrectAbbrev(int monthNum, string expectedAbbrev)
        {
            //Arrange
            Date d = new Date(2020, monthNum, 1);
            //Act
            string monthAbbrev = d.MonthNameAbbrev;
            //Assert
            Assert.Equal(expectedAbbrev, monthAbbrev);
        }

        //Date.MonthName Testing
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

        [Fact]
        public void DateConstructor_MonthIs31DayMax_DayIsBetween1And31_DateSetAccordingToParameters()
        {
            //Arrange
            int day = 31;
            int month = 1;
            //Act
            Date d = new Date(1000, month, day);
            //Assert
            Assert.Equal(1000, d.Year);
            Assert.Equal(month, d.Month);
            Assert.Equal(day, d.Day);
        }

        [Fact]
        public void DateConstructor_MonthIs31DayMax_DayIsNotBetween1And31_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            int day = 32;
            int month = 1;
            //Act
            Date d;
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(1000, month, day));
        }

        [Fact]
        public void DateConstructor_MonthIsFebruary_DayIsBetween1And28_DateSetAccordingToParameters()
        {
            //Arrange
            int day = 28;
            int month = 2;
            //Act
            Date d = new Date(1000, month, day);
            //Assert
            Assert.Equal(1000, d.Year);
            Assert.Equal(month, d.Month);
            Assert.Equal(day, d.Day);
        }

        [Fact]
        public void DateConstructor_MonthIsFebruary_DayIsNotBetween1And28_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            int day = 29;
            int month = 2;
            //Act
            Date d;
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(1000, month, day));
        }

        [Fact]
        public void IsToday_DateMatchesToday_ReturnsTrue()
        {
            //Arrange
            var systemDateProvider = new Mock<ISystemDateProvider>();
            systemDateProvider.Setup(m=>m.GetToday()).Returns(new Date(2020,01, 01));

            // set up new date
            Date date = new Date(2020, 01, 01, systemDateProvider.Object);
            //Act
            bool isToday = date.IsToday();
            //Assert
            Assert.True(isToday);
        }

        [Fact]
        public void IsToday_DateDoesNotMatchToday_ReturnsFalse()
        {
            //Arrange
            var systemDateProvider = new Mock<ISystemDateProvider>();
            systemDateProvider.Setup(m=>m.GetToday()).Returns(new Date(2020,01, 01));

            // set up new date
            Date date = new Date(2020, 01, 02, systemDateProvider.Object);
            //Act
            bool isToday = date.IsToday();
            //Assert
            Assert.False(isToday);
        }

        [Fact]
        public void WhatHolidayIsOnThisDay_FindOneHoliday_ReturnHolidayName()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            List<Holiday> holidays = new List<Holiday>()
            {
              new Holiday()
              {
                  TheDate=new Date(2020, 12, 25),
                  Name="Christmas"
              },
              new Holiday()
              {
                  TheDate=new Date(2020, 10, 31),
                  Name="Halloween"
              }
            };
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(holidays);
            Date date = new Date(2020, 10, 31,holidayProvider.Object);
            //Act
            string foundHoliday=date.WhatHolidayIsOnThisDay();
            //Assert
            Assert.Equal("Halloween", foundHoliday);
        }

        [Fact]
        public void WhatHolidayIsOnThisDay_FindNoHoliday_ReturnsNull()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            List<Holiday> holidays = new List<Holiday>()
            {
              new Holiday()
              {
                  TheDate=new Date(2020, 12, 25),
                  Name="Christmas"
              },
              new Holiday()
              {
                  TheDate=new Date(2020, 10, 31),
                  Name="Halloween"
              }
            };
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(holidays);
            Date date = new Date(2020, 10, 30,holidayProvider.Object);
            //Act
            string foundHoliday=date.WhatHolidayIsOnThisDay();
            //Assert
            Assert.Null(foundHoliday);
        }

        //Date.AddOneMonth Testing
        [Theory]
        [InlineData(2020, 5, 15, 2020, 6, 15)]  //normal case, same day carries over
        [InlineData(2020, 12, 15, 2021, 1, 15)] //December rolls over into the next year
        [InlineData(2020, 12, 31, 2021, 1, 31)] //December 31 fits in January
        [InlineData(2020, 1, 31, 2020, 2, 28)]  //day too big for February, clamped to 28
        [InlineData(2020, 3, 31, 2020, 4, 30)]  //day too big for a 30 day month, clamped to 30
        [InlineData(2020, 1, 30, 2020, 2, 28)]  //another February clamp
        [InlineData(2020, 1, 28, 2020, 2, 28)]  //last valid February day is not changed
        [InlineData(2020, 8, 30, 2020, 9, 30)]  //last valid day of a 30 day month is not changed
        public void AddOneMonth_ValidDate_ReturnsDateOneMonthLater(int year, int month, int day, int expectedYear, int expectedMonth, int expectedDay)
        {
            //Arrange
            Date d = new Date(year, month, day);
            //Act
            Date result = d.AddOneMonth(d);
            //Assert
            Assert.Equal(expectedYear, result.Year);
            Assert.Equal(expectedMonth, result.Month);
            Assert.Equal(expectedDay, result.Day);
        }

        //Date.WhatHolidaysAreOnThisDay Testing
        private static List<Holiday> BuildHolidays()
        {
            return new List<Holiday>()
            {
                new Holiday() { TheDate=new Date(2020, 12, 25), Name="Christmas" },
                new Holiday() { TheDate=new Date(2020, 10, 31), Name="Halloween" },
                new Holiday() { TheDate=new Date(2020, 10, 31), Name="Reformation Day" },
                new Holiday() { TheDate=new Date(2020, 10, 15), Name="Same Month Different Day" },
                new Holiday() { TheDate=new Date(2020, 9, 30), Name="Same Day Different Month" }
            };
        }

        [Fact]
        public void WhatHolidaysAreOnThisDay_FindTwoHolidays_ReturnsBothNames()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(BuildHolidays());
            Date date = new Date(2020, 10, 31, holidayProvider.Object);
            //Act
            List<string> found = date.WhatHolidaysAreOnThisDay();
            //Assert
            Assert.Equal(new List<string>() { "Halloween", "Reformation Day" }, found);
        }

        [Fact]
        public void WhatHolidaysAreOnThisDay_FindOneHoliday_ReturnsListWithOneName()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(BuildHolidays());
            Date date = new Date(2020, 12, 25, holidayProvider.Object);
            //Act
            List<string> found = date.WhatHolidaysAreOnThisDay();
            //Assert
            Assert.Single(found);
            Assert.Equal("Christmas", found[0]);
        }

        [Fact]
        public void WhatHolidaysAreOnThisDay_FindNoHoliday_ReturnsEmptyList()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(BuildHolidays());
            Date date = new Date(2020, 10, 30, holidayProvider.Object);
            //Act
            List<string> found = date.WhatHolidaysAreOnThisDay();
            //Assert
            Assert.NotNull(found);
            Assert.Empty(found);
        }

        [Fact]
        public void WhatHolidaysAreOnThisDay_SameDayDifferentMonth_ReturnsEmptyList()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(BuildHolidays());
            //"Same Day Different Month" is 9/30, so 11/30 has the same day but a different month
            Date date = new Date(2020, 11, 30, holidayProvider.Object);
            //Act
            List<string> found = date.WhatHolidaysAreOnThisDay();
            //Assert
            Assert.Empty(found);
        }

        [Fact]
        public void WhatHolidaysAreOnThisDay_EmptyHolidayList_ReturnsEmptyList()
        {
            //Arrange
            var holidayProvider = new Mock<IHolidayProvider>();
            holidayProvider.Setup(m=>m.GetHolidays(2020)).Returns(new List<Holiday>());
            Date date = new Date(2020, 10, 31, holidayProvider.Object);
            //Act
            List<string> found = date.WhatHolidaysAreOnThisDay();
            //Assert
            Assert.Empty(found);
        }

        //Date.WhoseBirthdayIsIt Testing
        private static List<Birthday> BuildBirthdays()
        {
            return new List<Birthday>()
            {
                new Birthday() { TheDate=new Date(1990, 10, 1), Name="Alice" },
                new Birthday() { TheDate=new Date(1985, 10, 1), Name="Bob" },
                new Birthday() { TheDate=new Date(2001, 12, 25), Name="Carol" },
                new Birthday() { TheDate=new Date(1999, 10, 25), Name="Dave" },
                new Birthday() { TheDate=new Date(1980, 12, 1), Name="Erin" }
            };
        }

        [Fact]
        public void WhoseBirthdayIsIt_TwoPeopleMatch_ReturnsBothNamesRegardlessOfBirthYear()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(BuildBirthdays());
            Date date = new Date(2020, 10, 1, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.Equal(new List<string>() { "Alice", "Bob" }, found);
        }

        [Fact]
        public void WhoseBirthdayIsIt_OnePersonMatches_ReturnsListWithOneName()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(BuildBirthdays());
            Date date = new Date(2020, 12, 25, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.Single(found);
            Assert.Equal("Carol", found[0]);
        }

        [Fact]
        public void WhoseBirthdayIsIt_NobodyMatches_ReturnsEmptyList()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(BuildBirthdays());
            Date date = new Date(2020, 3, 3, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.NotNull(found);
            Assert.Empty(found);
        }

        [Fact]
        public void WhoseBirthdayIsIt_SameDayDifferentMonth_ReturnsEmptyList()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(BuildBirthdays());
            //Dave is 10/25 and Carol is 12/25, so 11/25 has the day but not the month
            Date date = new Date(2020, 11, 25, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.Empty(found);
        }

        [Fact]
        public void WhoseBirthdayIsIt_SameMonthDifferentDay_ReturnsEmptyList()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(BuildBirthdays());
            //Alice is 10/1 and Dave is 10/25, so 10/10 has the month but not the day
            Date date = new Date(2020, 10, 10, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.Empty(found);
        }

        [Fact]
        public void WhoseBirthdayIsIt_EmptyBirthdayList_ReturnsEmptyList()
        {
            //Arrange
            var birthdayProvider = new Mock<IBirthdayProvider>();
            birthdayProvider.Setup(m=>m.GetBirthdays()).Returns(new List<Birthday>());
            Date date = new Date(2020, 10, 1, birthdayProvider.Object);
            //Act
            List<string> found = date.WhoseBirthdayIsIt();
            //Assert
            Assert.Empty(found);
        }
    }
}
