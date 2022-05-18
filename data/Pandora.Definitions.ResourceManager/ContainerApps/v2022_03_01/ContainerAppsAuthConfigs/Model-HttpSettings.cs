using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;


internal class HttpSettingsModel
{
    [JsonPropertyName("forwardProxy")]
    public ForwardProxyModel? ForwardProxy { get; set; }

    [JsonPropertyName("requireHttps")]
    public bool? RequireHttps { get; set; }

    [JsonPropertyName("routes")]
    public HttpSettingsRoutesModel? Routes { get; set; }
}
