namespace UCN.Test
{
    using NUnit.Framework;
    public class GeneratorTests
    {
        [Test]

        public void Are_GenerateUCN_Work_Correct()
        {
            Generator generator = new Generator("1899-03-29", "female", "Unknown/Other");
            var result = generator.GenerateUCN();
            Assert.AreEqual(result, "9903299996");
        }
    }
}
