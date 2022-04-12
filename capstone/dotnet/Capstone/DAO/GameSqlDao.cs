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

        public List<Game> GetGamesByUser(int id)
        {
            List<Game> gameByUser = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT g.gameId, g.game_Name, u.username FROM game g JOIN game_name gn On g.game_id = gn.game_id " +
                                                "JOIN users u ON gn.user_id = u.user_id " +
                                                "WHERE u.user_id = @user_id;", conn);
                cmd.Parameters.AddWithValue("@user_id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Game game = CreateGameFromReader(reader);
                    gameByUser.Add(game);
                }

            }
            return gameByUser;
        }

        public Game GetGamesById(int id)
        {
            Game game = null;
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Game WHERE game_id = @game_id", conn);
                cmd.Parameters.AddWithValue("@game_id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    game = CreateGameFromReader(reader);
                }
            }
            return game;
        }
        public Game CreateGame(Game game)
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
            return GetGamesById(newGameId);
        }



        private Game CreateGameFromReader(SqlDataReader reader)
        {
            Game g = new Game()
            {
                GameId = Convert.ToInt32(reader["game_id"]),
                GameName = Convert.ToString(reader["game_name"])

            };
            return g;
        }


    }
}
