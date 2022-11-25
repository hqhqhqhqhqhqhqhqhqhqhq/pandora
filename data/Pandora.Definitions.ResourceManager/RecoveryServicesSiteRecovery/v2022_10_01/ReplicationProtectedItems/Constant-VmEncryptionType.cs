using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VmEncryptionTypeConstant
{
    [Description("NotEncrypted")]
    NotEncrypted,

    [Description("OnePassEncrypted")]
    OnePassEncrypted,

    [Description("TwoPassEncrypted")]
    TwoPassEncrypted,
}