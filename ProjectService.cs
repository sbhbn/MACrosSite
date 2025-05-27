using MySqlConnector;
using MACrosSite.Models;

public class ProjectService
{
    private readonly string _connectionString = "Server=localhost;Database=carplace;User=root;Password=Sme322820829998;";
    
    public ProjectService(string connectionString)
    {
      
        _connectionString = connectionString;
       
    
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        var projects = new List<Project>();
        using var conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();

        using var cmd = new MySqlCommand("select * from car", conn);
        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            projects.Add(new Project
            {
                Car_Id = reader.GetInt32(0),
                license_place = reader.GetString(1),
                vihical_type = reader.GetString(2)
            });
        }
        return projects;
    }
}
