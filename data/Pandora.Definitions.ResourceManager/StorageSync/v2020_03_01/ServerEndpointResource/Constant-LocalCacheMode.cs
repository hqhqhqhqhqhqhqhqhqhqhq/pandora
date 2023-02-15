using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LocalCacheModeConstant
{
    [Description("DownloadNewAndModifiedFiles")]
    DownloadNewAndModifiedFiles,

    [Description("UpdateLocallyCachedFiles")]
    UpdateLocallyCachedFiles,
}