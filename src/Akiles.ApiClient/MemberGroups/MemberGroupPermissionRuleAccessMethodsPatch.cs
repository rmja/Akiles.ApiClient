using LanguageExt;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRuleAccessMethodsPatch
{
    public Option<bool> Online { get; set; }
    public Option<bool> Bluetooth { get; set; }
    public Option<bool> MobileNfc { get; set; }
    public Option<bool> Pin { get; set; }
    public Option<bool> Card { get; set; }
}
