using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace mip_exam
{
    // Implements the repository using a local SQLite database.
    public class SqliteDeliveryRepository : IDeliveryRepository
    {
        private readonly string connectionString;

        // Creates the database table if it does not already exist.
        public SqliteDeliveryRepository(string databasePath)
        {
            connectionString =
                "Data Source=" + databasePath + ";Version=3;";

            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command =
                    connection.CreateCommand())
                {
                    command.CommandText =
                        @"CREATE TABLE IF NOT EXISTS Delivery
                          (
                              Id INTEGER PRIMARY KEY AUTOINCREMENT,
                              Recipient TEXT NOT NULL,
                              Priority INTEGER NOT NULL,
                              Status TEXT NOT NULL
                          );";

                    command.ExecuteNonQuery();
                }
            }
        }

        // Inserts a delivery using parameterized SQL.
        public int Insert(Delivery delivery)
        {
            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command =
                    connection.CreateCommand())
                {
                    command.CommandText =
                        @"INSERT INTO Delivery
                          (
                              Recipient,
                              Priority,
                              Status
                          )
                          VALUES
                          (
                              @Recipient,
                              @Priority,
                              @Status
                          );";

                    command.Parameters.AddWithValue(
                        "@Recipient",
                        delivery.Recipient);

                    command.Parameters.AddWithValue(
                        "@Priority",
                        delivery.Priority);

                    command.Parameters.AddWithValue(
                        "@Status",
                        delivery.Status);

                    command.ExecuteNonQuery();
                }

                using (SQLiteCommand command =
                    connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT last_insert_rowid();";

                    return Convert.ToInt32(
                        command.ExecuteScalar());
                }
            }
        }

        // Loads deliveries and reconstructs the correct subclass
        // based on the stored priority.
        public List<Delivery> LoadAll()
        {
            List<Delivery> deliveries =
                new List<Delivery>();

            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command =
                    connection.CreateCommand())
                {
                    command.CommandText =
                        @"SELECT
                              Id,
                              Recipient,
                              Priority,
                              Status
                          FROM Delivery
                          ORDER BY Id;";

                    using (SQLiteDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id =
                                Convert.ToInt32(reader["Id"]);

                            string recipient =
                                Convert.ToString(reader["Recipient"]);

                            int priority =
                                Convert.ToInt32(reader["Priority"]);

                            string status =
                                Convert.ToString(reader["Status"]);

                            Delivery delivery;

                            // Priority 3 is ExpressDelivery; priorities 1 and 2
                            // are RegularDelivery.
                            if (priority == 3)
                            {
                                delivery =
                                    new ExpressDelivery(
                                        id,
                                        recipient,
                                        priority,
                                        status);
                            }
                            else
                            {
                                delivery =
                                    new RegularDelivery(
                                        id,
                                        recipient,
                                        priority,
                                        status);
                            }

                            deliveries.Add(delivery);
                        }
                    }
                }
            }

            return deliveries;
        }

        // Persists a delivery status transition.
        public void UpdateStatus(
            int id,
            string status)
        {
            if (status != "Pending" &&
                status != "Processing" &&
                status != "Completed")
            {
                throw new ArgumentException(
                    "Invalid delivery status.");
            }

            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command =
                    connection.CreateCommand())
                {
                    command.CommandText =
                        @"UPDATE Delivery
                          SET Status = @Status
                          WHERE Id = @Id;";

                    command.Parameters.AddWithValue(
                        "@Status",
                        status);

                    command.Parameters.AddWithValue(
                        "@Id",
                        id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}