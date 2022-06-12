namespace UCN.Test
{
    using NUnit.Framework;
    public class ControlDigitTests
    {

        [TestCase("1234567890", 0)]
        [TestCase("0123456789", 0)]
        [TestCase("0000000000", 0)]
        [TestCase("1111111111", 0)]
        [TestCase("0121012302", 2)]
        [TestCase("1121918808", 8)]

        public void Are_CalcCheckDigit_Return_Correct_Digit(string input, int output)
        {
            ControlDigit controlDigit = new ControlDigit();
            var result = controlDigit.CalcCheckDigit(input);
            Assert.AreEqual(result, output);
        }
    }
}
