using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.CapacityReservations;

internal class Definition : ResourceDefinition
{
    public string Name => "CapacityReservations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CapacityReservationInstanceViewTypesConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapacityReservationModel),
        typeof(CapacityReservationInstanceViewModel),
        typeof(CapacityReservationPropertiesModel),
        typeof(CapacityReservationUpdateModel),
        typeof(CapacityReservationUtilizationModel),
        typeof(InstanceViewStatusModel),
        typeof(SkuModel),
        typeof(SubResourceReadOnlyModel),
    };
}
