namespace Akiles.ApiClient.Members;

[Flags]
[EnumParameterFormatter<MembersExpand>]
public enum MembersExpand
{
    None = 0x00,
    Cards = 0x01,
    Emails = 0x02,
    GroupAssociations = 0x04,
    MagicLinks = 0x08,
    Pins = 0x10,
}
