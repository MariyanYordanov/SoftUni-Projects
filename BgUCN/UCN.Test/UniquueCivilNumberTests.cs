namespace UCN.Test
{
    using NUnit.Framework;
    using System;

    public class UniquueCivilNumberTests
    {
        [Test]

        public void Are_Constructor_Work_Properly()
        {
            UniqueCivilNumber UCN = new UniqueCivilNumber("4901225409");
            Assert.AreEqual(UCN.Birthdate, new DateTime(1949, 01, 22));
        }

        [Test]

        public void Are_Property_BirthPlace_Work_Properly()
        {
            UniqueCivilNumber UCN = new UniqueCivilNumber("4901225409");
            Assert.AreEqual(UCN.BirthPlace, "Ruse");
        }

        [Test]

        public void Are_UCN_Property_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new UniqueCivilNumber("1225409"), 
                "\nError: The length of the Unique Civil Number must be exactly 10 digits." +
                "\nPlease try again\n");
            Assert.Throws<ArgumentException>(() => new UniqueCivilNumber("@#$1225409"), 
                "\nError: The Unique Civil Number must contain digits only." +
                "\nPlease try again\n");
            Assert.Throws<ArgumentException>(() => new UniqueCivilNumber("1234567890"), 
                "\nError: The date of birth is uncorrect." +
                "\nPlease try again\n");
        }

        [Test]

        public void Are_IsValid_Returns_True()
        {
            UniqueCivilNumber UCN = new UniqueCivilNumber("0845196487");
            Assert.IsTrue(UCN.IsValid());
        }

        [Test]

        public void Are_IsValid_Returns_False()
        {
            UniqueCivilNumber UCN = new UniqueCivilNumber("0845196483");
            Assert.IsFalse(UCN.IsValid());
        }

        [Test]

        public void Are_DefineGender_Return_Correct_gender()
        {
            UniqueCivilNumber maleUCN = new UniqueCivilNumber("0845196483");
            UniqueCivilNumber femaleUCN = new UniqueCivilNumber("0845196413");
            var resultMale = maleUCN.DefineGender();
            var resultFemale = femaleUCN.DefineGender();
            Assert.AreEqual(resultMale, "male");
            Assert.AreEqual(resultFemale, "female");
        }

        [Test]

        public void Are_TakeBirthPlace_Is_Correct()
        {
            UniqueCivilNumber UCN = new UniqueCivilNumber("0845196483");
            var result = UCN.TakeBirthPlace();
            Assert.AreEqual(result,"Sofia City");
        }
    }
}
