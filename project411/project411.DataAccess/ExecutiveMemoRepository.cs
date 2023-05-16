namespace Project411
{
    public class ExecutiveMemoRepository : IExecutiveMemoRepository
    {
        private readonly string _connectionString;

        public ExecutiveMemoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ExecutiveMemoModel>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM memos", connection);
                var reader = await command.ExecuteReaderAsync();

                var memos = new List<ExecutiveMemoModel>();

                while (await reader.ReadAsync())
                {
                    memos.Add(new ExecutiveMemoModel
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Content = (string)reader["content"],
                        Author = (string)reader["author"],
                        DateCreated = (DateTime)reader["date_created"]
                    });
                }

                return memos;
            }
        }

        public async Task<ExecutiveMemoModel> GetAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("SELECT * FROM memos WHERE id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new ExecutiveMemoModel
                    {
                        Id = (int)reader["id"],
                        Title = (string)reader["title"],
                        Content = (string)reader["content"],
                        Author = (string)reader["author"],
                        DateCreated = (DateTime)reader["date_created"]
                    };
                }

                return null;
            }
        }

        public async Task<int> CreateAsync(ExecutiveMemoModel memo)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("INSERT INTO memos (title, content, author, date_created) VALUES (@title, @content, @author, @date_created) RETURNING id", connection);
                command.Parameters.AddWithValue("title", memo.Title);
                command.Parameters.AddWithValue("content", memo.Content);
                command.Parameters.AddWithValue("author", memo.Author);
                command.Parameters.AddWithValue("date_created", memo.DateCreated);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task UpdateAsync(ExecutiveMemoModel memo)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("UPDATE memos SET title = @title, content = @content, author = @author, date_created = @date_created WHERE id = @id", connection);
                command.Parameters.AddWithValue("title", memo.Title);
                command.Parameters.AddWithValue("content", memo.Content);
                command.Parameters.AddWithValue("author", memo.Author);
                command.Parameters.AddWithValue("date_created", memo.DateCreated);
                command.Parameters.AddWithValue("id", memo.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand("DELETE FROM memos WHERE id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}