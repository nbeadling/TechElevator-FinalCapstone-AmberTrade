using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class GameSqlDao : IGameDAO
    {

        private readonly string connectionSting;

        public GameSqlDao(string dbConnectionString)
        {
            connectionSting = dbConnectionString;
        }

        public int CreateGameId(int userId, string gameName)
        {
            int newGameId = 0;
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT Into Game (game_name) " +
                                                "OUTPUT INSERTED.game_id " +
                                                "VALUES(@game_name);", conn);
                cmd.Parameters.AddWithValue("@game_name", gameName);

                newGameId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return CreateGameById(newGameId, userId);
        }


        public int CreateGameById(int newGameId, int userId)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                int createdGameId = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT holdings (stock, balance,user_id, game_id) " +
                                                "OUTPUT INSERTED.game_id " +
                                                "values ('', 100000, @user_id, @game_id); " +
                                                "SELECT username FROM users WHERE user_id = @user_id ", conn);
                cmd.Parameters.AddWithValue("@game_id", newGameId);
                cmd.Parameters.AddWithValue("@user_id", userId);

                createdGameId = Convert.ToInt32(cmd.ExecuteScalar());
                return createdGameId;
            }
           
        }

        public List<Holdings> ViewGamesByUserId(int userId)
        {
            List<Holdings> listGames = new List<Holdings>();

            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT h.balance, g.game_id, g.game_name FROM holdings h " +
                                                "JOIN Game G on G.game_id = h.game_id " +
                                                "WHERE h.user_id = @user_id;", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Holdings games = ViewGamesByUserIdReader(reader);
                    listGames.Add(games);
                }
            }
            return listGames;
        }

        private Holdings ViewGamesByUserIdReader(SqlDataReader reader)
        {
            Holdings g = new Holdings();

            g.GameId = Convert.ToInt32(reader["game_id"]);
            g.GameName = Convert.ToString(reader["game_name"]);
            g.Balance = Convert.ToDecimal(reader["balance"]);
            //UserName = Convert.ToString(reader["username"])
            return g;
        }

        public int InvitePlayer(int userId, Game gameId)
        {

            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                int transferGame = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT holdings (stock, balance,user_id, game_id) " +
                                                "OUTPUT INSERTED.game_id " +
                                                "values ('', 100000, @user_id, @game_id); ", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@game_id", gameId.GameId);

                transferGame = (int)cmd.ExecuteScalar();
   
                return transferGame;
            }

        }



    }
}
