//PROJECTF2111
//EK85gon$

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;
using System.Data.SqlClient;

namespace cSharpAssignment
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            //insertSpotifyStreams();
            //insertTopCharts();
            insertDaysOnRadio();
        }

        public static void insertTopCharts()
        {
            //variables
            double calculation = 0;
            int count = 1;
            double avgWOCPercent;
            double averageWOC;

            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            driver.Url = "https://www.officialcharts.com/charts/singles-chart/table";             //top charts
            IWebElement topChartTable = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/article/div/div[1]/section/table"));      //top charts               
            var rows = topChartTable.FindElements(By.TagName("tr"));

            Console.WriteLine();
            Console.WriteLine("Calculating average weeks on chart...");
            Console.WriteLine("Calculating top 10 songs that have been on the charts the longest");
            Console.WriteLine();

            //the actual calculation
                foreach (var row in rows)
                {
                    var tds = row.FindElements(By.XPath("td[5]"));
                    foreach (var entry in tds)
                    {
                    double WOC;
                    string temp = entry.Text;
                    WOC = Convert.ToDouble(temp);

                    calculation += WOC;
                    averageWOC = (calculation / 100);

                    avgWOCPercent = (WOC / calculation) * 100;
                    avgWOCPercent = Math.Round(avgWOCPercent, 2);

                    if ((WOC > averageWOC) && (count < 11))
                    {
                        Console.WriteLine(count + ". Number of Weeks on Charts: " + WOC + Environment.NewLine + "   WOC Percentage: " + avgWOCPercent + "%");
                    }

                    var song = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry2 in song)
                    {
                        string songName = entry2.Text;
                        if ((WOC > averageWOC) && (count < 11))
                        {
                            Console.WriteLine(count + ". Name of Song: " + songName);
                            Console.WriteLine();
                            count++;
                        }
                    }
                }
                }

                driver.Quit();
                Console.Write("press any key to end ...");
                Console.ReadLine();
        }

        public static void insertDaysOnRadio()
        {
            //variables
            double calculation = 0;
            int count = 1;
            double avgDaysPercent;
            double avgDays;

            //change the website and xpath here for each different website
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            driver.Url = "https://kworb.net/radio/";                                              //days on the radio     //THIS ONE WORKS
            IWebElement daysOnRadioTable = driver.FindElement(By.XPath("/html/body/div[2]/div[4]/table"));                //days on the radio     //THIS ONE WORKS with the normal
            var rows = daysOnRadioTable.FindElements(By.TagName("tr"));

            Console.WriteLine();
            Console.WriteLine("Calculating the average number of days on the radio...");
            Console.WriteLine("Calculating the top 10 songs on the radio the longest...");
            Console.WriteLine();

            //actual calculation
            foreach (var row in rows)
            {
                var tds = row.FindElements(By.XPath("td[4]"));
                foreach (var entry in tds)
                {
                    double days;
                    string temp = entry.Text;
                    days = Convert.ToDouble(temp);

                    calculation += days;
                    avgDays = (calculation / 100);

                    avgDaysPercent = (days / calculation) * 100;
                    avgDaysPercent = Math.Round(avgDaysPercent, 2);

                    if ((days > avgDays) && (count < 11))
                    {
                        Console.WriteLine(count + ". Number of Days: " + days + Environment.NewLine + "   Days Percentage: " + avgDaysPercent + "%");
                    }

                    var song = row.FindElements(By.XPath("td[3]"));
                    foreach (var entry2 in song)
                    {
                        string songName = entry2.Text;
                        if ((days > avgDays) && (count < 11))
                        {
                            Console.WriteLine(count + ". Name of Song: " + songName);
                            Console.WriteLine();
                            count++;
                        }
                    }
                }
            }

            //ending everything and closing it all out
            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

        public static void insertSpotifyStreams()
        {
            //variables
            double calculation = 0;
            int count = 1;
            double avgPercent;
            double averageStreams;

            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            driver.Url = "https://spotifycharts.com/regional";                                      //spotify streams
            IWebElement spotifyStreamsTable = driver.FindElement(By.XPath("/html/body/div/div/div/div/span/table"));      //spotify streams       //this one works with the className
            var rows = spotifyStreamsTable.FindElements(By.TagName("tr"));

            Console.WriteLine();
            Console.WriteLine("Calculating the average number of streams... \n");
            Console.WriteLine("Calculating the percentage of the total streams the top 10 streaming songs are...");
            Console.WriteLine();

            foreach (var row in rows)
            {
                var tds = row.FindElements(By.XPath("td[5]"));
                foreach(var entry in tds)
                {
                    double stream;
                    string temp = entry.Text;
                    stream = Convert.ToDouble(temp);

                    calculation += stream;
                    averageStreams = (calculation / 200);

                    avgPercent = (stream / calculation) * 100;
                    avgPercent = Math.Round(avgPercent, 2);

                    if ((stream > averageStreams) && (count < 11))
                    {
                        Console.WriteLine(count + ". Number of Streams: " + stream + Environment.NewLine + "   Stream Percentage: " + avgPercent + "%");
                    }

                    var song = row.FindElements(By.XPath("td[4]"));
                    foreach (var entry2 in song)
                    {
                        string songName = entry2.Text;
                        if((stream > averageStreams) && (count < 11))
                        {
                            Console.WriteLine(count + ". Name of Song: " + songName);
                            Console.WriteLine();
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("This is the average number of streams on spotify " + calculation + ".");

            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

    }
}


