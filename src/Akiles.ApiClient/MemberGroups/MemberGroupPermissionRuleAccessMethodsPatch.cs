using OneOf;
using OneOf.Types;

namespace Akiles.ApiClient.MemberGroups;

public record MemberGroupPermissionRuleAccessMethodsPatch
{
    public OneOf<None, bool> Online { get; set; }
    public OneOf<None, bool> Bluetooth { get; set; }
    public OneOf<None, bool> MobileNfc { get; set; }
    public OneOf<None, bool> Pin { get; set; }
    public OneOf<None, bool> Card { get; set; }
}
