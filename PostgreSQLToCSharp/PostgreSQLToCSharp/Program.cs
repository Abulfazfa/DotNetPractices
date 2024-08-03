using Npgsql;

string connString = "Server=your_server;Port=5432;Database=UserRegistrationDB;User Id=your_username;Password=your_password;";

using (var conn = new NpgsqlConnection(connString))
{
    conn.Open();

    Console.WriteLine("Enter username:");
    string username = Console.ReadLine().Trim();

    Console.WriteLine("Enter password:");
    string password = Console.ReadLine().Trim();

    // Example SQL command
    string sql = "INSERT INTO users (username, password) VALUES (@username, @password)";

    using (var cmd = new NpgsqlCommand(sql, conn))
    {
        cmd.Parameters.AddWithValue("username", username);
        cmd.Parameters.AddWithValue("password", password);

        cmd.ExecuteNonQuery();

        Console.WriteLine("User registered successfully!");
    }
}