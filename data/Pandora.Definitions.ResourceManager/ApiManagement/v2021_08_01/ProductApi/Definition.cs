using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductApi;

internal class Definition : ResourceDefinition
{
    public string Name => "ProductApi";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckEntityExistsOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ListByProductOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessIdNameConstant),
        typeof(ApiTypeConstant),
        typeof(BearerTokenSendingMethodsConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NotificationNameConstant),
        typeof(ProtocolConstant),
        typeof(TemplateNameConstant),
        typeof(VersioningSchemeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiContactInformationModel),
        typeof(ApiContractModel),
        typeof(ApiContractPropertiesModel),
        typeof(ApiLicenseInformationModel),
        typeof(ApiVersionSetContractDetailsModel),
        typeof(AuthenticationSettingsContractModel),
        typeof(OAuth2AuthenticationSettingsContractModel),
        typeof(OpenIdAuthenticationSettingsContractModel),
        typeof(SubscriptionKeyParameterNamesContractModel),
    };
}
