using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    //https://dotnettutorials.net/lesson/viewdata-asp-net-core-mvc/

    public class HighScoreController : Controller
    {
        IList<HighScoreModel> highScoreList = new List<HighScoreModel>();

        //string connection =
        //    @"Data Source = 192.168.0.35;
        //    user Id = sa;
        //    password = Password321!;
        //    Initial Catalog = PortfolioGame;";
        string connection = @"Server = tcp:portfoliojeremiah.database.windows.net,1433;Initial Catalog = Portfolio_db; Persist Security Info=False;User ID = jeremiah; Password = Password321!; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";


        public ViewResult Index()
        {
            ViewData["Title"] = "High Score Page";
            ViewData["Header"] = "High Score Tile Puzzles";
            ViewDataStuffer();
            ViewData["HighScoreModel"] = highScoreList;
            return View();
        }

        public void ViewDataStuffer()
        {
            string connectionString = connection;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "Select PlayerScore, PlayerName From MyUser " +
                        "Where PlayerScore " +
                        "In (Select PlayerScore) " +
                        "Order By PlayerScore Desc;", connection);
                    connection.Open();
                    SqlDataReader sdr1 = cmd.ExecuteReader();

                    while (sdr1.Read())
                    {
                        highScoreList.Add(new HighScoreModel(sdr1["PlayerName"].ToString(), Int32.Parse(sdr1["PlayerScore"].ToString())));
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.\n" + ex);
            }
        }
    }
}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    ViewDataStuffer();
        //    ViewDataStuffer2();
        //    return View();
        //}



        //public void ViewDataStuffer()
        //{
        //    try
        //    {
        //        IList<int> dataScores = new List<int>();
        //        IList<HighScoreModel> dataScores = new List<HighScoreModel>();
        //        string connectionString = connection;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd1 = new SqlCommand(
        //                "Select Top 5 PlayerScore From MyUser " +
        //                "Where PlayerScore " +
        //                "In (Select PlayerScore) " +
        //                "Order By PlayerScore Desc;", connection);
        //            connection.Open();
        //            SqlDataReader sdr1 = cmd1.ExecuteReader();

        //            while (sdr1.Read())
        //            {
        //                dataScores.Add(Int32.Parse(sdr1["PlayerScore"].ToString()));
        //                dataScores.Add(Int32.Parse(sdr1));
        //                dataScores.Add(new HighScoreModel() { PlayerScore.To = "sdr1" });
        //            }

        //            ViewData["Message0.0"] = dataScores[0];
        //            ViewData["Message1.0"] = dataScores[1];
        //            ViewData["Message2.0"] = dataScores[2];
        //            ViewData["Message3.0"] = dataScores[3];
        //            ViewData["Message4.0"] = dataScores[4];

        //            ViewData["myScores"] = dataScores.Count.ToString();

        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Something went wrong.\n" + ex);
        //    }
        //}

        //public void ViewDataStuffer2()
        //{
        //    List<string> dataFirstNames = new List<string>();
        //    string connectionString = connection;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd2 = new SqlCommand(
        //                "Select Top 5 PlayerName From MyUser " +
        //                "Where PlayerScore " +
        //                "In (Select PlayerScore) " +
        //                "Order By PlayerScore Desc;", connection);
        //            connection.Open();
        //            SqlDataReader sdr2 = cmd2.ExecuteReader();

        //            while (sdr2.Read())
        //            {
        //                dataFirstNames.Add(sdr2["PlayerName"].ToString());
        //            }

        //            ViewData["Message0.1"] = dataFirstNames[0];
        //            ViewData["Message1.1"] = dataFirstNames[1];
        //            ViewData["Message2.1"] = dataFirstNames[2];
        //            ViewData["Message3.1"] = dataFirstNames[3];
        //            ViewData["Message4.1"] = dataFirstNames[4];
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Something went wrong.\n" + ex);
        //    }
        //}

        //public void CreateOutput()
        //{
        //    try
        //    {
        //        User user = new User();

        //        List<string> dataFirstNames = new List<string>();
        //        List<string> dataLastNames = new List<string>();
        //        List<int> dataScores = new List<int>();
        //        string connectionString = connection;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(
        //                "Select Top 5 * From MyUser " +
        //                "Where PlayerScore " +
        //                "In (Select PlayerScore) " +
        //                "Order By PlayerScore Desc;", connection);
        //            connection.Open();
        //            SqlDataReader sdr = cmd.ExecuteReader();

        //            while (sdr.Read())
        //            {
        //                dataScores.Add(Int32.Parse(sdr["PlayerScore"].ToString()));
        //                dataFirstNames.Add(sdr["PlayerFirstName"].ToString());
        //                dataLastNames.Add(sdr["PlayerLastName"].ToString());
        //            }

        //            for (int i = 0; i < dataScores.Count; i++)
        //            {
        //                //scores[i].text = dataScores[i].ToString();
        //                user.PlayerScore = dataScores[i];
        //            }

        //            for (int i = 0; i < dataFirstNames.Count; i++)
        //            {
        //                //firstNames[i].text = dataFirstNames[i];
        //                user.PlayerNameFirst = dataFirstNames[i];
        //            }

        //            for (int i = 0; i < dataLastNames.Count; i++)
        //            {
        //                //lastNames[i].text = dataLastNames[i];
        //                user.PlayerNameLast = dataLastNames[i];
        //            }

        //            connection.Close();
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Console.WriteLine("Something went wrong.\n" + ex);
        //    }
        //}
    //}
//}