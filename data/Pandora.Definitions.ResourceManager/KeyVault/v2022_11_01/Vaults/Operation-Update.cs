using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Vaults;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override Type? RequestObject() => typeof(VaultPatchParametersModel);

    public override ResourceID? ResourceId() => new KeyVaultId();

    public override Type? ResponseObject() => typeof(VaultModel);


}
