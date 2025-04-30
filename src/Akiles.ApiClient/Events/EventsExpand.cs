namespace Akiles.ApiClient.Events;

[Flags]
public enum EventsExpand
{
    None = 0x0000,
    ObjectApiKey = 0x0001,
    ObjectDevice = 0x0002,
    ObjectGadget = 0x0004,
    ObjectLink = 0x0008,
    ObjectMember = 0x0010,
    ObjectMemberGroup = 0x0020,
    ObjectMemberMagicLink = 0x0040,
    ObjectMemberPin = 0x0080,
    ObjectMemberToken = 0x0100,
    ObjectSchedule = 0x0200,
    ObjectSite = 0x0400,
    SubjectApiKey = 0x0800,
    SubjectMember = 0x1000,
    SubjectOauthApplication = 0x2000,
    SubjectUser = 0x4000,
    SubjectUserSession = 0x8000,
}
