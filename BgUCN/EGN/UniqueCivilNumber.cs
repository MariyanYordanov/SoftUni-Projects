namespace UCN
{
    using System;
    using System.Text;

    public class UniqueCivilNumber
    {
        private string ucn;
        private readonly DateTime minDate;
        private readonly DateTime maxDate;
        const int ASCII = 48;

        public UniqueCivilNumber(string ucn)
        {
            this.UCN = ucn;
            this.minDate = new DateTime(1800, 01, 01);
            this.maxDate = new DateTime(2099, 12, 31);
        }

        public string UCN
        {
            get => ucn;
            private set
            {
                foreach (var symbol in value)
                {
                    if (!Char.IsDigit(symbol))
                    {
                        throw new ArgumentException("\nError: The Unique Civil Number must contain digits only." +
                                                    "\nPlease try again\n");
                    }
                }

                if (value.Length != 10)
                {
                    throw new ArgumentException("\nError: The length of the Unique Civil Number must be exactly 10 digits." +
                                              "\nPlease try again\n");
                }

                if (!IsCorrectDate(value))
                {
                    throw new ArgumentException("\nError: The date of birth is uncorrect." +
                                              "\nPlease try again\n");
                }

                this.ucn = value;
            }
        }

        public DateTime Birthdate => DateTime.Parse(BirthDateToDateFormat(this.UCN));

        public string BirthPlace => TakeBirthPlace();


        public bool IsValid()
        {
            ControlDigit controlDigit = new ControlDigit();
            int usnControlDigit = controlDigit.CalcCheckDigit(this.UCN);
            if (usnControlDigit == (int)this.UCN[9] - ASCII
                && this.Birthdate >= this.minDate
                && this.Birthdate <= this.maxDate)
            {
                return true;
            }

            return false;
        }

        // Print info message for owner of UCN
        public string OutputMessage()
        {
            return $"\nInfo: {string.Join("", this.UCN)} is the USN of a {DefineGender()} person, " +
                $"born on {Enum.GetName(typeof(Months), this.Birthdate.Month)} {this.Birthdate.Day}, " +
                $"{this.Birthdate.Year} year in {this.BirthPlace} district.";
        }

        public string DefineGender()
        {
            // The penultimate digit of each UCN indicates whether the person is male or female
            string gender;
            if ((int)this.UCN[8] % 2 == 0)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            return gender;
        }

        public bool IsCorrectDate(string usn)
        {
            if (DateTime.TryParse(BirthDateToDateFormat(usn), out _))
            {
                return true;
            }

            return false;
        }

        public string TakeBirthPlace()
        {
            int code = int.Parse(this.UCN.Substring(6, 3));
            District district = new District();

            return district.GetDistrictByCode(code);
        }

        public string BirthDateToDateFormat(string usn)
        {
            // First six digit are date of birth - first pair are year, second - month and third - day
            char[] dateOfBirth = usn.Substring(0, 6).ToCharArray();
            string year = "19";

            // For those born before 1 January 1900, the number 20 is added to the month
            // for those born after 31 December 1999 to 31 December 2099, the number 40 shall be added to the month
            if (dateOfBirth[2] == '2' || dateOfBirth[2] == '3')
            {
                year = "18";
                int inNumber = (int)dateOfBirth[2];
                inNumber -= 2;
                dateOfBirth[2] = (char)inNumber;
            }
            else if (dateOfBirth[2] == '4' || dateOfBirth[2] == '5')
            {
                year = "20";
                int inNumber = (int)dateOfBirth[2];
                inNumber -= 4;
                dateOfBirth[2] = (char)inNumber;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(year);
            sb.Append(dateOfBirth);
            sb.Insert(4, '-');
            sb.Insert(7, '-');
            string result = sb.ToString();
            sb.Clear();

            return result;
        }

    }
}
