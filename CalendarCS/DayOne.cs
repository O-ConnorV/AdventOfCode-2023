namespace CalendarCS;
using System.Text.RegularExpressions;

public class DayOne
{
    public static int DecodeCalender(string filepath)
    {
        int res = 0;
        var currentNumber =new Stack<int>();
        string? currentLine = "";
        try
        {
            using (StreamReader tst = new StreamReader(filepath))
            {
                while ((currentLine = tst.ReadLine()) != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (char.IsDigit(currentLine[i]))
                        {
                            currentNumber.Push(currentLine[i] - '0');
                            break;
                        }
                    }

                    for (int i = 1; i <= currentLine.Length; i++)
                    {
                        if (char.IsDigit(currentLine[^i]))
                        {
                            currentNumber.Push(currentLine[^i] - '0');
                            break;
                        }
                    }

                    for (int j = 0; j <= currentNumber.Count; j++)
                    {
                        res += currentNumber.Pop() * (int)Math.Pow(10, j);
                    }
                    
                }
            }
        }
        catch (Exception)
        {
            throw new FileNotFoundException();
        }

        return res;
    }
    
    public static int DecodeCalender2(string filepath)
    {
        int res = 0;
        var currentNumber = new Stack<int>();
        string? currentLine;
        //var validNumbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        try
        {
            using (StreamReader tst = new StreamReader(filepath))
            {
                while ((currentLine = tst.ReadLine()) != null)
                {
                    //don't know if it works
                    if (currentLine.Length != null)
                    {
                        string pattern = @"\b(?:zero|one|two|three|four|five|six|seven|eight|nine)\b";
                        MatchCollection matches = Regex.Matches(currentLine, pattern);

                        string firstDigit = matches[0].Value;
                        string lastDigit = matches[matches.Count - 1].Value;

                        int firstDigitValue = Array.IndexOf(
                            new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                            firstDigit
                        );

                        int lastDigitValue = Array.IndexOf(
                            new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                            lastDigit
                        );

                        res += (firstDigitValue * 10 + lastDigitValue);
                    }
                        /*
                        string isNumber = "";
                        string pattern = @"\b(?:zero|one|two|three|four|five|six|seven|eight|nine)\b";
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            isNumber += currentLine[i];
                            MatchCollection matches = Regex.Matches(isNumber, pattern);

                            string firstDigit = matches[0].Value;
                            string lastDigit = matches[matches.Count - 1].Value;

                            int firstDigitValue = Array.IndexOf(
                                new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }, 
                                firstDigit
                                );

                            int lastDigitValue = Array.IndexOf(
                                new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                                lastDigit
                                );

                            res += (firstDigitValue * 10 + lastDigitValue);
                        }*/
                }
            }
        }
        catch (Exception)
        {
            throw new FileNotFoundException();
        }

        return res;
    }
    
    //ChatGPT code
    /*
        static int CalculateSumOfDigits(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int totalSum = 0;

                foreach (string line in lines)
                {
                    string pattern = @"\b(?:zero|one|two|three|four|five|six|seven|eight|nine)\b";
                    MatchCollection matches = Regex.Matches(line, pattern);

                    string firstDigit = matches[0].Value;
                    string lastDigit = matches[matches.Count - 1].Value;

                    int firstDigitValue = Array.IndexOf(
                        new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                        firstDigit
                    );

                    int lastDigitValue = Array.IndexOf(
                        new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                        lastDigit
                    );

                    totalSum += (firstDigitValue * 10 + lastDigitValue);
                }

                return totalSum;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }
        }*/
}