using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsms;

internal class ListByResourceGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(ManagedHsmModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.KeyVault/managedHSMs";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
