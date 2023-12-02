namespace CalendarCS;

public class DayTwo
{
    public static int PuzzlePossible(string filepath)
    {
        int sumOfIDs = 0;
        try
        {
            using (StreamReader tst = new StreamReader(filepath))
            {
                string? currentLine;
                string id = "";
                int amountMax = 0;
                var amoutMaxlist = new List<int>();
                
                string amountColor = "";
                string color = "";
                var colorDict = new Dictionary<string, int> {{"red", 0}, {"green", 0}, {"blue", 0}};
                
                while ((currentLine = tst.ReadLine()) != null)
                {
                    for (int i = 5; i < currentLine.Length; i++)
                    {
                        if (i == 5)
                        {
                            while (currentLine[i] != ':')
                            {
                                id += currentLine[i];
                                i++;
                            }
                        }
                        if (currentLine[i] == ':')
                        {
                            i+= 2;
                            while (currentLine[i] != ' ') 
                            {
                                amountColor += currentLine[i]; 
                                i++;
                            }
                            while (i != currentLine.Length - 1 || currentLine[i] != ',' && currentLine[i] != ';')
                            {
                                i++;
                                color += currentLine[i];
                            }
                            for (int j = 0; j < amountColor.Length; j++)
                            {
                                colorDict[color] += (amountColor[i] - '0') * (int)Math.Pow(10, j);
                            }
                            amoutMaxlist.Add(colorDict[color]);
                            if (i == currentLine.Length - 1)
                            {
                                for (int j = 0; j < amoutMaxlist.Count; j++)
                                {
                                    amountMax += amoutMaxlist[j];
                                }

                                if (amountMax <= 14)
                                {
                                    sumOfIDs += int.Parse(id);
                                }
                                
                                break;
                            }
                            else if (currentLine[i] == ',')
                            {
                                i += 2;
                                amountColor = "";
                                color = "";
                            }
                            else if (currentLine[i] == ';')
                            {
                                i += 2;
                                amountColor = "";
                                color = "";

                                for (int j = 0; j < amoutMaxlist.Count; j++)
                                {
                                    amountMax += amoutMaxlist[j];
                                }

                                if (amountMax <= 14)
                                {
                                    sumOfIDs += int.Parse(id);
                                }
                                amountMax = 0;
                                amoutMaxlist.Clear();
                                id = "";
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            throw new FileNotFoundException();
        }

        return sumOfIDs;
    }
}