namespace ChatSJTU.Plugin.Hpc
{
    public class HpcOverviewOutputDto
    {
        public string Sy { get; set; }
        public string SyPercent { get; set; }
        public string Pi { get; set; }
        public string PiPercent { get; set; }
        public string Gpu { get; set; }
        public string GpuPercent { get; set; }
        public string Arm { get; set; }
        public string ArmPercent { get; set; }
        public string Storage { get; set; }
        public string StoragePercent { get; set; }

        public HpcOverviewOutputDto(HpcOverviewDto dto) {
            this.Sy = $"{dto.SyAlloc} / {dto.SyTotal}";
            this.SyPercent = (dto.Sy * 100).ToString("0.00") + "%";
            this.Pi = $"{dto.CpuAlloc} / {dto.CpuTotal}";
            this.PiPercent = (dto.Cpu * 100).ToString("0.00") + "%";
            this.Arm = $"{dto.ArmAlloc} / {dto.ArmTotal}";
            this.ArmPercent = (dto.Arm * 100).ToString("0.00") + "%";
            this.Gpu = $"{dto.GpuAlloc} / {dto.GpuTotal}";
            this.GpuPercent = (dto.Gpu * 100).ToString("0.00") + "%";
            this.Storage = $"{dto.NodeAlloc} TB / {dto.NodeTotal} TB";
            this.StoragePercent = (dto.Node * 100).ToString("0.00") + "%";
        }
    }
}
