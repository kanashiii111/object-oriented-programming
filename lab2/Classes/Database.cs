using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2.Classes
{
    public class Database
    {
        public readonly string ConnectionString = "Data Source=players.db;Foreign Keys=True;";
        public List<Player> Players { get; set; } = new List<Player>();
        public List<PointGuard> PointGuards { get; set; } = new List<PointGuard>();
        public List<Center> Centers { get; set; } = new List<Center>();
        public Database() { }

        public void ReadAll()
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
                            (Type)reader.GetInt32(4)
                        ));
                    }
                }

                foreach(Player player in Players)
                {
                    if (player.Type == Type.PointGuard)
                    {
                        using (var command = new SqliteCommand("SELECT * FROM PointGuards WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", player.getID());
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    player.setPointGuard(new PointGuard
                                    (
                                        player.getID(),
                                        player.getName(),
                                        player.getHeight(),
                                        player.getJerseyNumber(),
                                        Type.PointGuard,
                                        reader.GetDouble(1),
                                        reader.GetDouble(2)
                                    ));
                                }
                            }
                        }
                    } else
                    {
                        using (var command = new SqliteCommand("SELECT * FROM Centers WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", player.getID());
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    player.setCenter(new Center
                                    (
                                        player.getID(),
                                        player.getName(),
                                        player.getHeight(),
                                        player.getJerseyNumber(),
                                        Type.Center,
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetDouble(3),
                                        reader.GetDouble(4)
                                    ));
                                }
                            }
                        }
                    }
                }
            }
        }

        public Player ReadOne(int playerID)
        {
            Player? player = null;
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand("SELECT * FROM Players WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", playerID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                (Type)reader.GetInt32(4)
                            );
                        }
                    }
                }
                if (player.getType() == Type.PointGuard)
                {
                    using (var command = new SqliteCommand("SELECT * FROM PointGuards WHERE ID = @ID", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.getID());
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                player.setPointGuard(new PointGuard
                                (
                                    player.getID(),
                                    player.getName(),
                                    player.getHeight(),
                                    player.getJerseyNumber(),
                                    Type.PointGuard,
                                    reader.GetDouble(1),
                                    reader.GetDouble(2)
                                ));
                            }
                        }
                    }
                }
                else
                {
                    using (var command = new SqliteCommand("SELECT * FROM Centers WHERE ID = @ID", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.getID());
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                player.setCenter(new Center
                                (
                                    player.getID(),
                                    player.getName(),
                                    player.getHeight(),
                                    player.getJerseyNumber(),
                                    Type.Center,
                                    reader.GetInt32(1),
                                    reader.GetInt32(2),
                                    reader.GetDouble(3),
                                    reader.GetDouble(4)
                                ));
                            }
                        }
                    }
                }
            }
            return player;
        }

        public void Add(Player player)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand("INSERT INTO Players (Name, Height, JerseyNumber, Type) VALUES (@Name, @Height, @JerseyNumber, @Type); SELECT last_insert_rowid();", connection))
                {
                    command.Parameters.AddWithValue("@Name", player.getName());
                    command.Parameters.AddWithValue("@Height", player.getHeight());
                    command.Parameters.AddWithValue("@JerseyNumber", player.getJerseyNumber());
                    command.Parameters.AddWithValue("@Type", player.getType());

                    int lastId = Convert.ToInt32(command.ExecuteScalar());
                    player.setID(lastId);
                }

                if (player.getType() == Type.PointGuard)
                {
                    using (var command = new SqliteCommand("INSERT INTO PointGuards (ID, AssistsPerGame, ThreePointPercentage) VALUES (@ID, @AssistsPerGame, @ThreePointPercentage)", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.getID());
                        command.Parameters.AddWithValue("@AssistsPerGame", player.getPointGuard()?.getAssistsPerGame());
                        command.Parameters.AddWithValue("@ThreePointPercentage", player.getPointGuard()?.getThreePointPercentage());
                        command.ExecuteNonQuery();
                    }
                } else if (player.getType() == Type.Center)
                {
                    using (var command = new SqliteCommand("INSERT INTO Centers (ID, Blocks, Rebounds, BlocksPerGame, ReboundsPerGame) VALUES (@ID, @Blocks, @Rebounds, @BlocksPerGame, @ReboundsPerGame)", connection))
                    {
                        command.Parameters.AddWithValue("@ID", player.getID());
                        command.Parameters.AddWithValue("@Blocks", player.getCenter()?.getBlocks());
                        command.Parameters.AddWithValue("@Rebounds", player.getCenter()?.getRebounds());
                        command.Parameters.AddWithValue("@BlocksPerGame", player.getCenter()?.getBlocksPerGame());
                        command.Parameters.AddWithValue("@ReboundsPerGame", player.getCenter()?.getReboundsPerGame());
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

        public void Edit(int PlayerID, string newName, int newHeight, int newJerseyNumber)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Players SET Name = @Name, Height = @Height, JerseyNumber = @JerseyNumber WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", PlayerID);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@Height", newHeight);
                command.Parameters.AddWithValue("@JerseyNumber", newJerseyNumber);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Player player)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Players SET Name = @Name, Height = @Height, JerseyNumber = @JerseyNumber, Type = @Type WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", player.getID());
                command.Parameters.AddWithValue("@Name", player.getName());
                command.Parameters.AddWithValue("@Height", player.getHeight());
                command.Parameters.AddWithValue("@JerseyNumber", player.getJerseyNumber());
                command.Parameters.AddWithValue("@Type", player.getType());
                command.ExecuteNonQuery();

                if (player.getType() == Type.Center)
                {
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Centers SET Blocks = @Blocks, Rebounds = @Rebounds, BlocksPerGame = @BlocksPerGame, ReboundsPerGame = @ReboundsPerGame WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", player.getID());
                    command.Parameters.AddWithValue("@Blocks", player.getCenter()?.getBlocks() ?? 0);
                    command.Parameters.AddWithValue("@Rebounds", player.getCenter()?.getRebounds() ?? 0);
                    command.Parameters.AddWithValue("@BlocksPerGame", player.getCenter()?.getBlocksPerGame() ?? 0.0);
                    command.Parameters.AddWithValue("@ReboundsPerGame", player.getCenter()?.getReboundsPerGame() ?? 0.0);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        command.CommandText = "INSERT INTO Centers (ID, Blocks, Rebounds, BlocksPerGame, ReboundsPerGame) VALUES (@ID, @Blocks, @Rebounds, @BlocksPerGame, @ReboundsPerGame)";
                        command.ExecuteNonQuery();
                    }

                    command.Parameters.Clear();
                    command.CommandText = "DELETE FROM PointGuards WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", player.getID());
                    command.ExecuteNonQuery();
                } else if (player.getType() == Type.PointGuard)
                {
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE PointGuards SET AssistsPerGame = @AssistsPerGame, ThreePointPercentage = @ThreePointPercentage WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", player.getID());
                    command.Parameters.AddWithValue("@AssistsPerGame", player.getPointGuard()?.getAssistsPerGame() ?? 0);
                    command.Parameters.AddWithValue("@ThreePointPercentage", player.getPointGuard()?.getThreePointPercentage() ?? 0);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        command.CommandText = "INSERT INTO PointGuards (ID, AssistsPerGame, ThreePointPercentage) VALUES (@ID, @AssistsPerGame, @ThreePointPercentage)";
                        command.ExecuteNonQuery();
                    }

                    command.Parameters.Clear();
                    command.CommandText = "DELETE FROM Centers WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", player.getID());
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
