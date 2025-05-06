namespace Akiles.ApiClient.MemberGroups;

[Flags]
[EnumParameterFormatter<MemberGroupsExpand>]
public enum MemberGroupsExpand
{
    None = 0x00,
    Member = 0x01,
}
