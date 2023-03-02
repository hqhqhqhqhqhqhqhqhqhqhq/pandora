using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.SubVolumes;

internal class SubVolumeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{netAppAccountName}/capacityPools/{capacityPoolName}/volumes/{volumeName}/subVolumes/{subVolumeName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetApp", "Microsoft.NetApp"),
        ResourceIDSegment.Static("staticNetAppAccounts", "netAppAccounts"),
        ResourceIDSegment.UserSpecified("netAppAccountName"),
        ResourceIDSegment.Static("staticCapacityPools", "capacityPools"),
        ResourceIDSegment.UserSpecified("capacityPoolName"),
        ResourceIDSegment.Static("staticVolumes", "volumes"),
        ResourceIDSegment.UserSpecified("volumeName"),
        ResourceIDSegment.Static("staticSubVolumes", "subVolumes"),
        ResourceIDSegment.UserSpecified("subVolumeName"),
    };
}