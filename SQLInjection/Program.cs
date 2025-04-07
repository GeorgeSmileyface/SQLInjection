using System;
using System.Data.SqlClient;

Console.WriteLine("Input username");
string username = Console.ReadLine();

Console.WriteLine("Input password");
string password = Console.ReadLine();

string connectionString = "Server = localhost; Database = SqlTeachingDb; User Id = sa; Password = 1234; Trusted_Connection = True;";

SqlConnection connection = new SqlConnection(connectionString);

SqlCommand command = connection.CreateCommand();

string sql = $"SELECT Password FROM Logins WHERE Username = '{username}'";

//string sql = $"SELECT Password FROM Logins WHERE Username = '" + username + "'";

command.CommandText = sql;

connection.Open();

using (SqlDataReader reader = command.ExecuteReader())
{
    while (reader.Read())
    {
        string dbPassword = reader.GetString(0);
        if (dbPassword == password)
        {
            Console.WriteLine("Login successful");
        }
        else
        {
            Console.WriteLine("Login failed");
        }
    }
}