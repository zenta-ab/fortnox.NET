using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Project
{
    [JsonPropertyClass("Projects")]
    public class Project
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectNumber { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public string Comments { get; set; }
        public string ContactPerson { get; set; }
        public string ProjectLeader { get; set; }
    }
}