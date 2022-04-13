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

        public List<Game> GetGamesByUser(int userId)
        {
            List<Game> gameByUser = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT username " +
                                                "FROM users " +
                                                "WHERE user_id = @user_id;", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Game game = CreateGameFromReader(reader);
                    gameByUser.Add(game);
                }

            }
            return gameByUser;
        }

        //Game name = > game_id
        //game_id as a var passed into the update for holdings along with user_id to create game




        public Game CreateGameById(int newGameId, int userId)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                Game createdGame = null;
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert holdings (stock, balance,user_id, game_id) " +
                                                "OUTPUT INSERTED.game_id " +
                                               "values ('', 100000, @user_id, @game_id); " +
                                               //"SELECT game_name FROM Game WHERE game_id = @game_id " +
                                               "SELECT username FROM users WHERE user_id = @user_id ", conn);
                cmd.Parameters.AddWithValue("@game_id", newGameId);
                cmd.Parameters.AddWithValue("@user_id", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    createdGame = CreateGameIdFromReader(reader);
                }

                createdGame.UserId = userId;
                return createdGame;
            }
           
        }
        public Game CreateGameId(Game game)
        {
            int newGameId = 0;
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT Into Game (game_name) " +
                                                "OUTPUT INSERTED.game_id " +
                                                "VALUES(@game_name);", conn);
                cmd.Parameters.AddWithValue("@game_name", game.GameName);

                newGameId = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return CreateGameById(newGameId, game.UserId);
        }



        private Game CreateGameFromReader(SqlDataReader reader)
        {
            Game g = new Game()
            {
                //GameId = Convert.ToInt32(reader["game_id"]),
                //GameName = Convert.ToString(reader["game_name"]),
                UserName = Convert.ToString(reader["username"])

            };
            return g;
        }


        private Game CreateGameIdFromReader(SqlDataReader reader)
        {
            Game g = new Game()
            {
                GameId = Convert.ToInt32(reader["game_id"]),
                GameName = Convert.ToString(reader["game_name"]),
                //UserName = Convert.ToString(reader["username"])

            };
            return g;
        }

        private Game ViewGamesByUserIdReader(SqlDataReader reader)
        {
            Game g = new Game()
            {
                GameId = Convert.ToInt32(reader["game_id"]),
                GameName = Convert.ToString(reader["game_name"]),
                Balance = Convert.ToDecimal(reader["balance"]),

                //UserName = Convert.ToString(reader["username"])

            };
            return g;
        }





        public List<Game> ViewGamesByUserId(int userId)
        {
            List<Game> listGames = null;

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
                    Game games = ViewGamesByUserIdReader(reader);
                    listGames.Add(games);
                }


            }
            return listGames;
        }



    }
}
