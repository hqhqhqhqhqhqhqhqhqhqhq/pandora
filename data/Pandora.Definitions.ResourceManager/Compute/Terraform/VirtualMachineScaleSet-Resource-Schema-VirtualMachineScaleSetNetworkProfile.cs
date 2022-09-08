using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkProfileSchema
{

    [HclName("health_probe")]
    [Optional]
    public VirtualMachineScaleSetResourceApiEntityReferenceSchema HealthProbe { get; set; }


    [HclName("network_api_version")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.NetworkApiVersionConstant))]
    public string NetworkApiVersion { get; set; }


    [HclName("network_interface_configuration")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkConfigurationSchema> NetworkInterfaceConfiguration { get; set; }

}