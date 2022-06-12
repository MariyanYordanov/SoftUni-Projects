namespace UCN
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n-> Select an option:\n" +
                                "\n-> press #1 and then Enter for Validation of Unique Civil Number" +
                                "\n-> press #2 and then Enter for Generation of Unique Civil Number" +
                                "\n-> press #9 and then Enter for End of program\n");
            string command = Console.ReadLine();
            while (command != "#9")
            {
                if (command == "#1")
                {
                    Console.WriteLine("\nEnter a ten-digit Unique Civil Number and then press Enter\n");
                    string ucn = Console.ReadLine();
                    bool isCorrectUCN = false;
                    while (!isCorrectUCN)
                    {
                        try
                        {
                            UniqueCivilNumber UCN = new UniqueCivilNumber(ucn);
                            if (UCN.IsValid())
                            {
                                Console.WriteLine("\nResult: The entered Unique Civil Number is valid.");
                                Console.WriteLine(UCN.OutputMessage());
                                Console.WriteLine("\n-> Select an option:");
                            }
                            else
                            {
                                Console.WriteLine("\nResult: The entered Unique Civil Number is invalid.\n" +
                                                  "\n-> Select an option:");
                            }

                            isCorrectUCN = true;
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            ucn = Console.ReadLine();
                        }
                    }
                }
                else if (command == "#2")
                {
                    Validator validator = new Validator();

                    Console.WriteLine("\nThe UCN that will be generated will be valid and possible, but only for example." +
                                          "\nThe date must be in the period from January 1, 1800 year to December 31, 2099 year" +
                                          "\nEnter date of birth in the following format Year-Month-Day," +
                                          "\nFor example:" +
                                          "\n1999-01-01 or 1999-1-1" +
                                          "\n1999/01/01 or 1999/1/1" +
                                          "\n1999 01 01 or 1999 1 1\n");
                    string birthDate = Console.ReadLine();
                    bool isCorrectDate = false;
                    while (!isCorrectDate)
                    {
                        try
                        {
                            validator.BirthDateCheck(birthDate);
                            isCorrectDate = true;
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine(fe.Message);
                            birthDate = Console.ReadLine();
                        }
                    }

                    Console.WriteLine("\nEnter gender of birth -> male or female\n");
                    string gender = Console.ReadLine();
                    bool isCorrectGender = false;
                    while (!isCorrectGender)
                    {
                        try
                        {
                            validator.GenderCheck(gender);
                            isCorrectGender = true;
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            gender = Console.ReadLine();
                        }
                    }

                    Console.WriteLine("\nSelect a district of birth from these list: " +
                                          "\nBlagoevgrad, Burgas, Varna, Veliko Tarnovo, Vidin, Vratsa, Gabrovo" +
                                          "\nKardzhali, Kyustendil, Lovech, Montana, Pazardzhik, Pernik, Pleven" +
                                          "\nPlovdiv, Razgrad, Ruse, Silistra, Sliven, Smolyan, Sofia City, Sofia District" +
                                          "\nStara Zagora, Dobrich, Targovishte, Haskovo, Shumen, Yambol, Other/Unknown\n");
                    string district = Console.ReadLine();
                    bool isCorrectDistrict = false;
                    while (!isCorrectDistrict)
                    {
                        try
                        {
                            validator.DistrictCheck(district);
                            isCorrectDistrict = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            district = Console.ReadLine();
                        }
                    }

                    Generator generator = new Generator(birthDate, gender, district);
                    Console.WriteLine($"\nResult: {generator.GenerateUCN()}\n");
                }
                else
                {
                    Console.WriteLine("\nError: Invalid command. Please select one of the following options:\n");
                }

                Console.WriteLine("\n-> press #1 and then Enter for Validation of Unique Civil Number" +
                                  "\n-> press #2 and then Enter for Generation of Unique Civil Number" +
                                  "\n-> press #9 and then Enter for End of program\n");

                command = Console.ReadLine();
            }

        }
    }
}
