using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.WebPubSub.v2023_02_01.WebPubSub;

[ValueForType("EventHub")]
internal class EventHubEndpointModel : EventListenerEndpointModel
{
    [JsonPropertyName("eventHubName")]
    [Required]
    public string EventHubName { get; set; }

    [JsonPropertyName("fullyQualifiedNamespace")]
    [Required]
    public string FullyQualifiedNamespace { get; set; }
}