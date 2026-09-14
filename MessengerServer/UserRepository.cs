using Microsoft.Data.SqlClient;

public class UserRepository
{
    private readonly Database database = new Database();

    public bool UserExists(string userId)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            SELECT COUNT(*)
            FROM UserInfo
            WHERE UserId = @userId
            """;

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@userId", userId);

        int count = (int)command.ExecuteScalar();

        return count > 0;
    }

    public bool RegisterUser(string userId, string username, string passwordHash)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            INSERT INTO UserInfo (UserId, Username, PassHash)
            VALUES (@userId, @username, @passwordHash)
            """;

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@passwordHash", passwordHash);

        return command.ExecuteNonQuery() > 0;
    }

    public bool LoginUser(string userId, string password)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

            string sql = """
            SELECT COUNT(*)
            FROM UserInfo
            WHERE UserId = @userId
            AND PassHash = @password
            """;

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@password", password);

        int count = (int)command.ExecuteScalar();

        return count > 0;
    }

    public string[]? GetUser(string userId)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            SELECT UserId, Username
            FROM UserInfo
            WHERE UserId = @userId
            """;

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@userId", userId);

        using SqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new string[]
            {
            reader["UserId"].ToString()!,
            reader["Username"].ToString()!
            };
        }

        return null;
    }
    public List<string[]> SearchUsers(string searchText)
    {
        List<string[]> userList = new List<string[]>();

        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            SELECT userId, username, PassHash
            FROM UserInfo
            WHERE userId LIKE @search
               OR username LIKE @search
            ORDER BY userId ASC
            """;

        using SqlCommand cmd = new SqlCommand(sql, connection);

        cmd.Parameters.AddWithValue( "@search", "%" + searchText + "%");

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            userList.Add(new string[]
            {
            reader["userId"].ToString()!,
            reader["username"].ToString()!,
            reader["PassHash"].ToString()!
            });
        }

        return userList;
    }
    public bool UpdateUser(string userId,string username,string password)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            UPDATE UserInfo
            SET username = @username,
                PassHash = @password
            WHERE userId = @userId
            """;

        using SqlCommand cmd = new SqlCommand(sql, connection);

        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool adminDelete(string userId) {
        using SqlConnection connection = database.GetConnection();
        connection.Open();

        string sql = """
            DELETE FROM UserInfo
            WHERE userId = @userId
            """;

        using SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@userId", userId);

        return cmd.ExecuteNonQuery() > 0;
    }
}

