﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientHttp.Model
{
    class Manufacturer
    {
        [JsonPropertyName("manufacturerid")]
        public int Manufacturerid { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("createdat")]
        public DateTime? Createdat { get; set; }
        [JsonIgnore]
        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
