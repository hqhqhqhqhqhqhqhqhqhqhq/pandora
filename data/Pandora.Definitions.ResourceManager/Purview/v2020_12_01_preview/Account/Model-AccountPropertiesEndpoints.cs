using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account
{

    internal class AccountPropertiesEndpointsModel
    {
        [JsonPropertyName("catalog")]
        public string? Catalog { get; set; }

        [JsonPropertyName("guardian")]
        public string? Guardian { get; set; }

        [JsonPropertyName("scan")]
        public string? Scan { get; set; }
    }
}
