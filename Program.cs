using System;
using System.IO;

namespace Vokabel
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = "y";
            while (start == "y")
            {

                Console.WriteLine("Welche Sprache wollen sie Lernen?[Englisch/Italienisch]");
                string language = Console.ReadLine();

                if (language == "Italienisch" || language == "i" || language == "I" || language == "italienisch")
                {
                    string inPath = @"italianwords.csv";
                    string text = File.ReadAllText(inPath);

                    string[] lines = text.Split("\r\n");
                    int words = lines.Length;
                    string[] italien = new string[words];
                    string[] german = new string[words];


                    for (int line = 0; line < lines.Length; line++)
                    {
                        string[] items = lines[line].Split(',');
                        italien[line] = items[0];
                        german[line] = items[1];
                    }

                    int score = 0;
                    int all = 0;
                    string[] corrects = new string[50];

                    while (all < 49)
                    {
                        int random = new Random().Next(1, 50);

                        try
                        {
                            if (corrects[random] == "richtig")
                            {
                                throw new alreadyrightException();
                            }


                            Console.WriteLine("" + italien[random] + "");
                            string answer = Console.ReadLine();
                            if (answer == german[random])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                score = score + 1;
                                all = all + 1;
                                Console.WriteLine("Richtig!");
                                corrects[random] = "richtig";
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (answer == "stop")
                            {
                                all = 50;
                            }
                            else if (answer != italien[random])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("richtige Lösung:" + italien[random] + "");
                                score = score - 1;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        catch (alreadyrightException)
                        {

                        }
                    }
                    string inPaths = @"highscoreI.csv";
                    string texts = File.ReadAllText(inPaths);

                    string[] highscore = texts.Split("\r\n");

                    int highscorenumber = Convert.ToInt32(highscore[0]);

                    if (highscorenumber < score)
                    {
                        highscorenumber = score;
                        string outscore = "" + score + "";

                        string outPath = @"highscoreI.csv";
                        File.WriteAllText(outPath, outscore);
                    }

                    Console.WriteLine("Score: " + score + "");
                    Console.WriteLine("Highscore:" + highscorenumber + "");

                }
                else if (language == "Englisch" || language == "e" || language == "E" || language == "englisch")
                {
                    string inPath = @"wortliste.csv";
                    string text = File.ReadAllText(inPath);

                    string[] lines = text.Split("\r\n");
                    int words = lines.Length;
                    string[] english = new string[words];
                    string[] german = new string[words];


                    for (int line = 0; line < lines.Length; line++)
                    {
                        string[] items = lines[line].Split(',');
                        english[line] = items[0];
                        german[line] = items[1];
                    }

                    int score = 0;
                    int all = 0;
                    string[] corrects = new string[50];

                    while (all < 49)
                    {
                        int random = new Random().Next(1, 50);

                        try
                        {
                            if (corrects[random] == "richtig")
                            {
                                throw new alreadyrightException();
                            }


                            Console.WriteLine("" + german[random] + "");
                            string answer = Console.ReadLine();
                            if (answer == english[random])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                score = score + 1;
                                all = all + 1;
                                Console.WriteLine("Richtig!");
                                corrects[random] = "richtig";
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (answer == "stop")
                            {
                                all = 50;
                            }
                            else if (answer != german[random])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("richtige Lösung:" + english[random] + "");
                                score = score - 1;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        catch (alreadyrightException)
                        {

                        }
                    }


                    string inPaths = @"highscoreE.csv";
                    string texts = File.ReadAllText(inPaths);

                    string[] highscore = texts.Split("\r\n");

                    int highscorenumber = Convert.ToInt32(highscore[0]);

                    if (highscorenumber < score)
                    {
                        highscorenumber = score;
                        string outscore = "" + score + "";

                        string outPath = @"highscoreE.csv";
                        File.WriteAllText(outPath, outscore);
                    }

                    Console.WriteLine("Score: " + score + "");
                    Console.WriteLine("Highscore:" + highscorenumber + "");

                }

                Console.Write("Wollen sie erneut lernen?[y/n]");
                start = Console.ReadLine();
                Console.Clear();
            }


        }


    }

    class alreadyrightException : Exception { }
}

