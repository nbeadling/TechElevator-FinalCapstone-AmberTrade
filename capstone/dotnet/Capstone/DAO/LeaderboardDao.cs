using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;
using Capstone.Services;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class LeaderboardDao : ILeaderboards
    {
        private readonly string connectionSting;
        private readonly IClosePriceDao Close;

        public LeaderboardDao(string dbConnectionString)
        {
            connectionSting = dbConnectionString;
            Close = new ClosePriceServices();
        }
        private readonly IClosePriceDao ClosePriceServices;
        public LeaderboardDao(IClosePriceDao closePriceServices)
        {
            this.ClosePriceServices = closePriceServices;
        }
        //get value of quantity of stocks * daily value
        public Leaderboards TradesReader(SqlDataReader reader)
        {
            Leaderboards list = new Leaderboards();
            list.Stock = Convert.ToString(reader["stock"]);
            list.UserId = Convert.ToInt32(reader["user_id"]);
            list.Quanitity = Convert.ToInt32(reader["quantity"]);
            list.GameId = Convert.ToInt32(reader["game_id"]);
            list.Username = Convert.ToString(reader["username"]); 
            return list;
        }

        //leaderboards int variable needs to change since we changed to to pass a static game id and not use a variable where the game id would be passed in
        public Dictionary<string, decimal> LeaderboardBalance(int leaderboard)
        {
            //Dictionary<string, Leaderboards> result = new Dictionary<string, Leaderboards>();
            List<Leaderboards> results = new List<Leaderboards>();
            List<string> listTwo = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT H.Stock, H.user_id, H.quantity, H.game_id, U.username " +
                                                "FROM holdings H join users U on H.user_id = U.user_id " +
                                                "WHERE game_id = @game_id ", conn);
                cmd.Parameters.AddWithValue("@game_id", leaderboard);
                SqlDataReader test = cmd.ExecuteReader();
                while (test.Read())
                {
                    Leaderboards newLeaderboard = TradesReader(test);
                    results.Add(newLeaderboard);
                }

                Dictionary<string, decimal> balances = new Dictionary<string, decimal>();

                //foreach (var result in results)
                //{

                for (int i = 1; i <= results.Count; i++)  {
                    decimal playerBalance = 0;

                    string ticker = results[i-1].Stock;
                    ClosePrice price = Close.GetPrice(ticker);
                    decimal finalPrice = price.close;
                    playerBalance = finalPrice * results[i-1].Quanitity;

                    string key = results[i - 1].Username.ToString();


                    balances[key] = playerBalance + finalPrice;


                    }
                        
                    //balances.Add(results[i -1].UserId, playerBalance);
                    //}
                    //if (results[i - 1].UserId == i)
                    //{
                    // value of each row in table

                //}
                    return balances;
            }
        } }
    }


