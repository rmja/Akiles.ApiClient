namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRuleAccessMethods
{
    public bool Online { get; set; }
    public bool Bluetooth { get; set; }
    public bool MobileNfc { get; set; }
    public bool Pin { get; set; }
    public bool Card { get; set; }
}
