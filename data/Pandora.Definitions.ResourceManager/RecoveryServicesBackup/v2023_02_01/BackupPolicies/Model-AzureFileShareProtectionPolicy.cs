using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupPolicies;

[ValueForType("AzureStorage")]
internal class AzureFileShareProtectionPolicyModel : ProtectionPolicyModel
{
    [JsonPropertyName("retentionPolicy")]
    public RetentionPolicyModel? RetentionPolicy { get; set; }

    [JsonPropertyName("schedulePolicy")]
    public SchedulePolicyModel? SchedulePolicy { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("workLoadType")]
    public WorkloadTypeConstant? WorkLoadType { get; set; }
}