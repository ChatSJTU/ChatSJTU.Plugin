using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSJTU.Plugin.Helpers
{
    public partial class EmbedResHelper
    {
        [EmbedResourceCSharp.FileEmbed("Resources/交我算.svg")]
        public static partial ReadOnlySpan<byte> Get交我算();

        [EmbedResourceCSharp.FileEmbed("Resources/交大生活.svg")]
        public static partial ReadOnlySpan<byte> Get交大生活();

        [EmbedResourceCSharp.FileEmbed("Resources/校园管理.svg")]
        public static partial ReadOnlySpan<byte> Get校园管理();
    }
}
