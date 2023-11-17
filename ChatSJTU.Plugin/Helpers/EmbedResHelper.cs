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

        [EmbedResourceCSharp.FileEmbed("Resources/财务.svg")]
        public static partial ReadOnlySpan<byte> Get财务();

        [EmbedResourceCSharp.FileEmbed("Resources/场馆预约.svg")]
        public static partial ReadOnlySpan<byte> Get场馆预约();

        [EmbedResourceCSharp.FileEmbed("Resources/教务.svg")]
        public static partial ReadOnlySpan<byte> Get教务();

        [EmbedResourceCSharp.FileEmbed("Resources/教学楼.svg")]
        public static partial ReadOnlySpan<byte> Get教学楼();

        [EmbedResourceCSharp.FileEmbed("Resources/日程.svg")]
        public static partial ReadOnlySpan<byte> Get日程();

        [EmbedResourceCSharp.FileEmbed("Resources/图书馆.svg")]
        public static partial ReadOnlySpan<byte> Get图书馆();
    }
}
