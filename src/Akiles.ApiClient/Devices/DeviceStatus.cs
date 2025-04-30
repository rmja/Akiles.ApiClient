namespace Akiles.ApiClient.Devices;

public record DeviceStatus
{
    public bool Online { get; set; }
    public bool MainsPresent { get; set; }
    public bool BatteryPresent { get; set; }
    public bool BatteryCharging { get; set; }
    public double BatteryPercent { get; set; }
}
