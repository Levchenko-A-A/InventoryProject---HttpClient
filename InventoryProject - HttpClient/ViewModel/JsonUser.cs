﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryProject___HttpClient.ViewModel
{
    public class JsonUser
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
