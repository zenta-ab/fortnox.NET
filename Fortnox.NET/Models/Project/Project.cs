using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Project
{
    [JsonPropertyClass("Projects")]
    public class Project
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Description of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// End date of the project
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Projectnumber
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// Status of the project
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Start date of the project
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Comments on project
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// ContactPerson for project
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Projectleader
        /// </summary>
        public string ProjectLeader { get; set; }
    }
}