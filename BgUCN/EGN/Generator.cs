namespace UCN
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Generator
    {
        private readonly string birthDate;
        private readonly string gender;
        private readonly string district;

        public Generator(string birthDate, string gender, string district)
        {
            this.birthDate = birthDate;
            this.gender = gender;
            this.district = district;
        }

        public int RandomDistrictCode()
        {
            District district = new District();
            List<int> gendercodes = district.GetCodeRangeByDistrict(this.district);
            var districtCode = new Random();
            int code = districtCode.Next(gendercodes[0], gendercodes[gendercodes.Count - 1]);
            if (this.gender == "male")
            {
                while (code % 2 != 0)
                {
                    code = districtCode.Next(gendercodes[0], gendercodes[gendercodes.Count - 1]);
                }
            }
            else
            {
                while (code % 2 == 0)
                {
                    code = districtCode.Next(gendercodes[0], gendercodes[gendercodes.Count - 1]);
                }
            }

            return code;
        }

        public string GenerateUCN()
        {
            Validator validator = new Validator();
            ControlDigit cd = new ControlDigit();
            StringBuilder sb = new StringBuilder();
            sb.Append(validator.BirthDateToUCNFormat(this.birthDate));
            sb.Append(RandomDistrictCode().ToString());
            int controlDigit = cd.CalcCheckDigit(sb.ToString());
            sb.Append(controlDigit.ToString());
            string result = sb.ToString();
            sb.Clear();

            return result;
        }

    }
}
