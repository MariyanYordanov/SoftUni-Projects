namespace UCN.Test
{
    using NUnit.Framework;
    using System;

    public class ValidatorTests
    {

        [Test]

        public void Are_BirthDateCheck_Return_Correct_Date()
        {

            Validator validator = new Validator();
            var result = validator.BirthDateCheck("1800-1-1");
            Assert.AreEqual(result, new DateTime(1800, 1, 1));
        }

        [Test]

        public void Are_BirthDateCheck_Throw_FormatException_For_MinDate()
        {
            Validator validator = new Validator();
            Assert.Throws<FormatException>(() => validator.BirthDateCheck("1799-12-31"), "\nError: Invalid date." +
                                           "\nThe date must be in the period from January 1, 1800 year to December 31, 2099 year" +
                                           "\nEnter date of birth in the following format Year-Month-Day," +
                                           "\nFor example:" +
                                           "\n1999-01-01 or 1999-1-1" +
                                           "\n1999/01/01 or 1999/1/1" +
                                           "\n1999 01 01 or 1999 1 1" +
                                           "\nPlease try again\n");

        }

        [Test]

        public void Are_BirthDateCheck_Throw_FormatException_For_MaxDate()
        {
            Validator validator = new Validator();
            Assert.Throws<FormatException>(() => validator.BirthDateCheck("2100-1-1"));
        }

        [TestCase("male", "male")]
        [TestCase("female", "female")]

        public void Are_GenderCheck_Returns_Correct_Gender(string input, string output)
        {
            Validator validator = new Validator();
            var result = validator.GenderCheck(input);
            Assert.AreEqual(result, output);
        }

        [Test]

        public void Are_GenderCheck_Throw_ArgumentException()
        {
            Validator validator = new Validator();
            Assert.Throws<ArgumentException>(() => validator.GenderCheck("man"), "\nError: The gender must be only: male / female." +
                                            "\nPlease try again\n");
        }

        [TestCase("Pleven", "Pleven")]
        [TestCase("Ruse", "Ruse")]

        public void Are_DistrictCheck_Check_For_District_Properly(string input, string output)
        {
            Validator validator = new Validator();
            var result = validator.DistrictCheck(input);
            Assert.AreEqual(result, output);
        }

        [Test]

        public void Are_DistrictCheck_Throw_Exeption()
        {
            Validator validator = new Validator(); 
            Assert.Throws<ArgumentException>(() => validator.DistrictCheck("pleven"));
        }

        [Test]

        public void Are_BirthDateToUCNFormat_Return_Correct_Date()
        {
            Validator validator = new Validator();
            var result = validator.BirthDateToUCNFormat("1981-12-12");
            Assert.AreEqual(result, "811212");
        }

    }
}