using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace lab2.Classes
{
    public class Database
    {
        public readonly string ConnectionString = "Data Source=players.db;Foreign Keys=True;";
        public List<Player> Players { get; set; } = new List<Player>();
        public List<PointGuard> PointGuards { get; set; } = new List<PointGuard>();
        public List<Center> Centers { get; set; } = new List<Center>();
        public Database() { }

        public void Read()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand("SELECT * FROM Players", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Players.Add(new Player
                        (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4)
                        ));
                    }
                }

                foreach(Player player in Players)
                {
                    if (player.Type == "PointGuard")
                    {
                        using (var command = new SqliteCommand("SELECT * FROM PointGuards WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", player.ID);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    player.PointGuard = new PointGuard
                                    (
                                        player.ID,
                                        player.Name,
                                        player.Height,
                                        player.JerseyNumber,
                                        "PointGuard",
                                        reader.GetDouble(1),
                                        reader.GetDouble(2)
                                    );
                                }
                            }
                        }
                    } else
                    {
                        using (var command = new SqliteCommand("SELECT * FROM Centers WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", player.ID);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    player.Center = new Center
                                    (
                                        player.ID,
                                        player.Name,
                                        player.Height,
                                        player.JerseyNumber,
                                        "Center",
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDouble(3),
                                        reader.GetDouble(4)
                                    );
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Add(Player player)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand("INSERT INTO Players (Name, Height, JerseyNumber, Type) VALUES (@Name, @Height, @JerseyNumber, @Type); SELECT last_insert_rowid();", connection))
                {
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Height", player.Height);
                    command.Parameters.AddWithValue("@JerseyNumber", player.JerseyNumber);
                    command.Parameters.AddWithValue("@Type", player.Type);

                    int lastId = Convert.ToInt32(command.ExecuteScalar());
                    player.setID(lastId);
                }

                if (player.PointGuard != null)
                {
                    using (var command = new SqliteCommand("INSERT INTO PointGuards (ID, AssistsPerGame, ThreePointPercentage) VALUES (@ID, @AssistsPerGame, @ThreePointPercentage)", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.ID);
                        command.Parameters.AddWithValue("@AssistsPerGame", player.PointGuard.assistsPerGame);
                        command.Parameters.AddWithValue("@ThreePointPercentage", player.PointGuard.threePointPercentage);
                        command.ExecuteNonQuery();
                    }
                } else if (player.Center != null)
                {
                    using (var command = new SqliteCommand("INSERT INTO Centers (ID, Blocks, Rebounds, BlocksPerGame, ReboundsPerGame) VALUES (@ID, @Blocks, @Rebounds, @BlocksPerGame, @ReboundsPerGame)", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.ID);
                        command.Parameters.AddWithValue("@Blocks", player.Center.blocks);
                        command.Parameters.AddWithValue("@Rebounds", player.Center.rebounds);
                        command.Parameters.AddWithValue("@BlocksPerGame", player.Center.blocksPerGame);
                        command.Parameters.AddWithValue("@ReboundsPerGame", player.Center.reboundsPerGame);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Delete(int PlayerID)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Players WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", PlayerID);
                command.ExecuteNonQuery();
                Console.WriteLine("Player deleted from the database.");
            }
        }
    }
}
