using System;
using System.Text;

namespace UCN
{
    public class Validator
    {
        public Validator()
        {
        }
        public DateTime BirthDateCheck(string birthDate)
        {
            DateTime minDate = new DateTime(1800, 01, 01);
            DateTime maxDate = new DateTime(2099, 12, 31);
            if (!DateTime.TryParse(birthDate, out DateTime result) || result < minDate || result > maxDate)
            {
                throw new FormatException("\nError: Invalid date." +
                                          "\nThe date must be in the period from January 1, 1800 year to December 31, 2099 year" +
                                          "\nEnter date of birth in the following format Year-Month-Day," +
                                          "\nFor example:" +
                                          "\n1999-01-01 or 1999-1-1" +
                                          "\n1999/01/01 or 1999/1/1" +
                                          "\n1999 01 01 or 1999 1 1" +
                                          "\nPlease try again\n");
            }

            return result;
        }

        public string GenderCheck(string gender)
        {
            if (gender != "male" && gender != "female")
            {
                throw new ArgumentException();
            }

            return gender;
        }

        public string DistrictCheck(string district)
        {
            District districts = new District();
            if (!districts.Districts.ContainsKey(district))
            {
                throw new ArgumentException("\nError: District is not correct. Check carefully for white space or misspellings." +
                                    "\nPlease try again\n");
            }

            return district;
        }

        public string BirthDateToUCNFormat(string birthDate)
        {
            DateTime date = DateTime.Parse(birthDate);
            StringBuilder sb = new StringBuilder();
            sb.Append(date.Year);
            if (date.Month < 9)
            {
                sb.Append('0');
            }

            sb.Append(date.Month);
            if (date.Day < 9)
            {
                sb.Append('0');
            }

            sb.Append(date.Day);
            sb.Remove(0, 2);
            string result = sb.ToString();
            sb.Clear();

            return result;
        }
    }
}
