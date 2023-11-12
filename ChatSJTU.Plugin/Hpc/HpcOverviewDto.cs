using Newtonsoft.Json;

namespace ChatSJTU.Plugin.Hpc
{
    public class HpcOverviewDto
    {
        [JsonProperty("arm")]
        public double Arm { get; set; }

        [JsonProperty("armAlloc")]
        public long ArmAlloc { get; set; }

        [JsonProperty("armIdle")]
        public long ArmIdle { get; set; }

        [JsonProperty("armOther")]
        public long ArmOther { get; set; }

        [JsonProperty("armTotal")]
        public long ArmTotal { get; set; }

        [JsonProperty("cpu")]
        public double Cpu { get; set; }

        [JsonProperty("cpuAlloc")]
        public long CpuAlloc { get; set; }

        [JsonProperty("cpuIdle")]
        public long CpuIdle { get; set; }

        [JsonProperty("cpuOther")]
        public long CpuOther { get; set; }

        [JsonProperty("cpuTotal")]
        public long CpuTotal { get; set; }

        [JsonProperty("gpu")]
        public double Gpu { get; set; }

        [JsonProperty("gpuAlloc")]
        public long GpuAlloc { get; set; }

        [JsonProperty("gpuIdle")]
        public long GpuIdle { get; set; }

        [JsonProperty("gpuOther")]
        public long GpuOther { get; set; }

        [JsonProperty("gpuTotal")]
        public long GpuTotal { get; set; }

        [JsonProperty("node")]
        public double Node { get; set; }

        [JsonProperty("nodeAlloc")]
        public long NodeAlloc { get; set; }

        [JsonProperty("nodeIdle")]
        public long NodeIdle { get; set; }

        [JsonProperty("nodeOther")]
        public long NodeOther { get; set; }

        [JsonProperty("nodeTotal")]
        public long NodeTotal { get; set; }

        [JsonProperty("power")]
        public long Power { get; set; }

        [JsonProperty("pue")]
        public long Pue { get; set; }

        [JsonProperty("sy")]
        public double Sy { get; set; }

        [JsonProperty("syAlloc")]
        public long SyAlloc { get; set; }

        [JsonProperty("syIdle")]
        public long SyIdle { get; set; }

        [JsonProperty("syOther")]
        public long SyOther { get; set; }

        [JsonProperty("syTotal")]
        public long SyTotal { get; set; }
    }
}
