using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class LeaderboardDao : ILeaderboards
    {
        private readonly string connectionSting;

        public LeaderboardDao(string dbConnectionString)
        {
            connectionSting = dbConnectionString;
        }

        //get value of quantity of stocks * daily value 

        public Leaderboards TradesReader(SqlDataReader reader)
        {
            Leaderboards list = new Leaderboards();

            list.Stock = Convert.ToString(reader["stock"]);
            list.UserId = Convert.ToInt32(reader["user_id"]);
            list.Quanitity = Convert.ToInt32(reader["quantity"]);
            list.GameId = Convert.ToInt32(reader["game_id"]);
            return list;
        }

        //leaderboards int variable needs to change since we changed to to pass a static game id and not use a variable where the game id would be passed in
        public List<Leaderboards> LeaderboardBalance(int leaderboard)
        {
            List<Leaderboards> result = new List<Leaderboards>();

            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Stock, user_id, quantity, game_id " +
                                                "FROM holdings " +
                                                "WHERE game_id = @game_id ", conn);
                cmd.Parameters.AddWithValue("@game_id", leaderboard);
                SqlDataReader test = cmd.ExecuteReader();

                while (test.Read())
                {
                    Leaderboards newLeaderboard = TradesReader(test);
                    result.Add(newLeaderboard);
                }
                return result;


                //    decimal holdingsbalance = 0;
                //    for(int i = 1 ; i < user_id.count; i++)
                //    {
                //        using (SqlConnection conn = new SqlConnection(connectionSting))
                //        {
                //            conn.Open();
                //            SqlCommand cmd = new SqlCommand("SELECT * FROM holdings " +
                //                                            "Where user_id = @user_id and game_id = @game_id" conn);
                //            cmd.Parameters.AddWithValue("@user_id", i);
                //            SqlDataReader read = cmd.ExecuteReader();
                //    }
                //}

                // quantity * daily price 

            }

        }
    }
}
