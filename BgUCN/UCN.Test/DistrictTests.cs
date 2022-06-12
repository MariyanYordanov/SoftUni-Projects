namespace UCN.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistrictTests
    {
        [TestCase(1, "Blagoevgrad")]
        [TestCase(100, "Varna")]

        public void Are_GetDistrictByCode_Get_Correct_Code(int input, string output)
        {
            District district = new District();
            var result = district.GetDistrictByCode(input);
            Assert.AreEqual(result, output);
        }

        [Test]

        public void Are_GetDistrictByCode_Return_Null()
        {
            District district = new District();
            var result = district.GetDistrictByCode(1000);
            Assert.AreSame(result, null);
        }

        

        [Test]

        public void Are_GetCodeRangeByDistrict_Return_Correct_Code()
        {
            List<int> testList = new List<int>();
            testList.AddRange(Enumerable.Range(926, 74));
            District district = new District();
            var result = district.GetCodeRangeByDistrict("Other/Unknown");
            Assert.AreEqual(result, testList);
        }
    }
}
