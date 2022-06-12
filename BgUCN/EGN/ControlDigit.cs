
namespace UCN
{
    public class ControlDigit
    {
        const int ASCII = 48;
        public ControlDigit()
        {
        }

        public int CalcCheckDigit(string usn)
        {
            // The tenth digit is a check digit and is calculated using the following algorithm
            int sum = (((int)usn[0] - ASCII) * 2
                + ((int)usn[1] - ASCII) * 4
                + ((int)usn[2] - ASCII) * 8
                + ((int)usn[3] - ASCII) * 5
                + ((int)usn[4] - ASCII) * 10
                + ((int)usn[5] - ASCII) * 9
                + ((int)usn[6] - ASCII) * 7
                + ((int)usn[7] - ASCII) * 3
                + ((int)usn[8] - ASCII) * 6);

            double divisionResult = sum / 11;
            double remainder = sum - (divisionResult * 11);
            if (remainder < 10)
            {
                return (int)remainder;
            }
            else
            {
                return 0;
            }
        }
    }
}
