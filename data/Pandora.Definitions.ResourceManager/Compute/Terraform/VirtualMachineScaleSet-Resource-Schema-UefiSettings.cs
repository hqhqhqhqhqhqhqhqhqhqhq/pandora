using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceUefiSettingsSchema
{

    [HclName("secure_boot_enabled")]
    [Optional]
    public bool SecureBootEnabled { get; set; }


    [HclName("v_tpm_enabled")]
    [Optional]
    public bool VTpmEnabled { get; set; }

}