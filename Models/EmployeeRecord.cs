using System.Text.Json.Serialization;

namespace agentmodedemo.Models;

public class EmployeeRecord
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public DateTime HiringDate { get; set; }

    public required string Department { get; set; }

    [JsonPropertyName("Job Title")]
    public required string JobTitle { get; set; }
}
