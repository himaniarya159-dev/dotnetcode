namespace SmartHomeMonitor
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string Status { get; set; } = "ONLINE";
        public double Temperature { get; set; }
        public int BatteryLevel { get; set; }
    }
}