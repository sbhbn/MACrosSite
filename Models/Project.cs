using System.Text.Json.Serialization;

namespace MACrosSite.Models
{
    public class Project
    {
        internal string license_place;
        internal string vihical_type;
        internal DateTimeOffset occupied_time;

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;

        [JsonIgnore]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

        public List<ProjectTask> Tasks { get; set; } = [];

        public List<Tag> Tags { get; set; } = [];
        public int Car_Id { get; internal set; }

        public override string ToString() => $"{Name}";
    }

    public class ProjectsJson
    {
        public List<Project> Projects { get; set; } = [];
    }
}