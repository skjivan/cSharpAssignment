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

            insertTopCharts();
            //insertNumStreams();
            //insertDaysOnRadio();
            //insertSpotifyStreams();
            //insertAppleStreams();

        }

        public static void insertTopCharts()
        {
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            string connectionString = ("Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            //SqlConnection conn = new SqlConnection(@"Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;

            string[] chartsArray = new string[1500];
            int counter = 0;

            driver.Url = "https://www.officialcharts.com/charts/singles-chart/table";             //top charts
            IWebElement topChartTable = driver.FindElement(By.ClassName("chart-positions"));      //top charts               //this one works with the className instead of id

            var rows = topChartTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var tds = row.FindElements(By.TagName("td"));
                foreach (var entry in tds)
                {
                    chartsArray[counter] = entry.Text;
                    Console.WriteLine(counter + "this is a row " + chartsArray[counter]);
                    counter++;
                }
                Console.WriteLine();
            }

            connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "INSERT INTO topCharts VALUES (@pos, @lw, @title, @album, @artist, @peakPos, @woc, @buy)"; //scaler variables dont have to have the same names as sql tables but they have to be in order
            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@pos", chartsArray[0]);
            command.Parameters.AddWithValue("@lw", chartsArray[1]);
            command.Parameters.AddWithValue("@title", chartsArray[2].ToString());
            command.Parameters.AddWithValue("@album", chartsArray[3].ToString());
            command.Parameters.AddWithValue("@artist", chartsArray[4].ToString());
            command.Parameters.AddWithValue("@peakPos", chartsArray[5]);
            command.Parameters.AddWithValue("@woc", chartsArray[6]);
            command.Parameters.AddWithValue("@buy", chartsArray[7].ToString());

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();

            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

        public static void insertNumStreams()
        {
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            SqlConnection conn = new SqlConnection(@"Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            string[] streamsArray = new string[1500];
            int counter = 0;

            driver.Url = "https://hitsdailydouble.com/streaming_songs";                                     //number of streams
            IWebElement totalStreamsTable = driver.FindElement(By.ClassName("hits_album_chart"));           //number of streams         //this one works with the className


                var rows = totalStreamsTable.FindElements(By.TagName("tr"));
                foreach (var row in rows)
                {
                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in tds)
                    {
                        streamsArray[counter] = entry.Text;
                        Console.WriteLine(counter + "this is the row " + streamsArray[counter]);
                        counter++;
                    }

                    Console.WriteLine();
                }

            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

        public static void insertDaysOnRadio()
        {
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            //SqlConnection conn = new SqlConnection(@"Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            string[] radioArray = new string[1500];
            int counter = 0;
            string connectionString = ("Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "INSERT INTO radioStreams VALUES(@position, @pos, @title, @days, @pk, @aud, @audpt2, @formats, @pkaud, @itunes, @spotify, @apple, @shazam)";
            command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@position", );
            //command.Parameters.AddWithValue();
            //command.Parameters.AddWithValue();

            driver.Url = "https://kworb.net/radio/";                                              //days on the radio     //THIS ONE WORKS
            IWebElement daysOnRadioTable = driver.FindElement(By.Id("overallai"));                //days on the radio     //THIS ONE WORKS with the normal

            var rows = daysOnRadioTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var tds = row.FindElements(By.TagName("td"));
                foreach (var entry in tds)
                {
                    radioArray[counter] = entry.Text;
                    //Console.WriteLine(counter + "this is the row" + radioArray[counter]);
                    Console.WriteLine(radioArray[counter]);
                }
                Console.WriteLine();
            }

            command.Parameters.AddWithValue("@position", radioArray[0]);
            command.Parameters.AddWithValue("@pos", radioArray[1]);
            command.Parameters.AddWithValue("@title", radioArray[2].ToString());
            command.Parameters.AddWithValue("@days", radioArray[3]);
            command.Parameters.AddWithValue("@pk", radioArray[4]);
            command.Parameters.AddWithValue("@aud", radioArray[5]);
            command.Parameters.AddWithValue("@audpt2", radioArray[6]);
            command.Parameters.AddWithValue("@formats", radioArray[7]);
            command.Parameters.AddWithValue("@pkaud", radioArray[8]);
            command.Parameters.AddWithValue("@itunes", radioArray[9]);
            command.Parameters.AddWithValue("@spotify", radioArray[10]);
            command.Parameters.AddWithValue("@apple", radioArray[11]);
            command.Parameters.AddWithValue("@shazam", radioArray[12]);

            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            driver.Quit();

            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

        public static void insertSpotifyStreams()
        {
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            //string connectionString = ("Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            //SqlConnection connection;
            //SqlCommand command;
            //SqlDataReader dataReader;
            string[] spotifyArray = new string[1500];
            int counter = 0;

            driver.Url = "https://spotifycharts.com/regional";                                      //spotify streams
            IWebElement spotifyStreamsTable = driver.FindElement(By.ClassName("chart-table"));      //spotify streams       //this one works with the className

             var rows = spotifyStreamsTable.FindElements(By.TagName("tr"));
             foreach (var row in rows)
             {
                var tds = row.FindElements(By.TagName("td"));
                foreach (var entry in tds)
                {
                    spotifyArray[counter] = entry.Text;
                    Console.WriteLine(counter + "this is an attempt" + spotifyArray[counter]);
                    counter++;
                }
                Console.WriteLine();
            }



            //connection = new SqlConnection(connectionString);
            //connection.Open();
            //string sql = "INSERT INTO spofityStreams VALUES (@position, @title, @streams)";
            //command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@position", );
            //command.Parameters.AddWithValue();
            //command.Parameters.AddWithValue();

            //command.ExecuteNonQuery();
            //connection.Close();
            //command.Dispose();

            //INSERT INTO [dbo].[spofityStreams] ([position], [title], [streams]) VALUES (< position, int,>, < title, varchar(100),>, < streams, int,>)

            //private void btnInsertQuest_Click(object sender, EventArgs e)
            //{
            //    try
            //    {
            //        int answer;
            //        connection = new SqlConnection(connectionString);
            //        connection.Open();
            //        string sql = "INSERT INTO quests VALUES (@NPC, @req, @loot)"; //scaler variables dont have to have the same names as sql tables but they have to be in order
            //        command = new SqlCommand(sql, connection);

            //        command.Parameters.AddWithValue("@NPC", txtNPC.Text);
            //        command.Parameters.AddWithValue("@req", txtReqs.Text);
            //        command.Parameters.AddWithValue("@loot", txtLoot.Text);

            //        answer = command.ExecuteNonQuery();

            //        connection.Close();
            //        command.Dispose();

            //        MessageBox.Show("You successfully inserted " + answer + " quest record!!");
            //    }
            //    catch (Exception error)
            //    {
            //        MessageBox.Show("Hey you did not successfully insert a quest. look at this error  " + error);
            //    }
            //}

            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }

        public static void insertAppleStreams()
        {
            IWebDriver driver = new ChromeDriver("S:/skjivan/bdp");         //this is where the chromedriver is
            SqlConnection conn = new SqlConnection(@"Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTF2111;User ID=PROJECTF2111;Password=EK85gon$");
            string[] appleArray = new string[1000];
            int counter = 0;

            driver.Url = "https://kworb.net/charts/apple_a/us.html";                           //appleMusic streams    //THIS ONE WORKS
            IWebElement appleStreamTable = driver.FindElement(By.Id("simpletable"));           //appleMusic streams    //THIS ONE WORKS with the normal

            var rows = appleStreamTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var tds = row.FindElements(By.TagName("td"));
                foreach (var entry in tds) 
                {
                    appleArray[counter] = entry.Text;
                    Console.WriteLine(counter + "this is the last try " + appleArray[counter]);
                    counter++;
                }
                Console.WriteLine();
            }
           
            driver.Quit();
            Console.Write("press any key to end ...");
            Console.ReadLine();
        }
    }
}


