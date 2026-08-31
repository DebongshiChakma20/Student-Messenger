using Microsoft.Data.SqlClient;

public class MessageRepository
{
    private readonly Database database = new Database();

    public bool SaveMessage(string senderId, string receiverId, string messageText)
    {
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            INSERT INTO Messages
                (senderId, receiverId, messageText)
            VALUES
                (@senderId, @receiverId, @messageText)
            """;

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@senderId", senderId);
        command.Parameters.AddWithValue("@receiverId", receiverId);
        command.Parameters.AddWithValue("@messageText", messageText);

        return command.ExecuteNonQuery() > 0;
    }

    public bool deleteMessage(string messageId)
    {
        using SqlConnection connecction = database.GetConnection();

        connecction.Open();

        string sql="""
            DELETE FROM Messages
            WHERE messageId=@messageId

            """;

        using SqlCommand cmd = new SqlCommand(sql, connecction);
        cmd.Parameters.AddWithValue("@messageId", messageId);

        return cmd.ExecuteNonQuery() > 0;
    }

    public List<string[]> getMessage(string userId, string contactId)
    {
        List<string[]> message = new List<string[]>();
        using SqlConnection connection = database.GetConnection();

        connection.Open();

        string sql = """
            SELECT messageId, senderId, receiverId, messageText
            FROM Messages
            WHERE (senderId=@userId AND receiverId=@contactId) OR
                  (senderId=@contactId AND receiverId=@userId)
            ORDER BY messageId ASC
            """;

        using SqlCommand cmd= new SqlCommand(sql, connection);

        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@contactId", contactId);

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            message.Add(new string[]
            {
                reader["messageId"].ToString()!,
                reader["senderId"].ToString()!,
                reader["receiverId"].ToString()!,
                reader["messageText"].ToString()!
            });
        }
        return message;
    }
}