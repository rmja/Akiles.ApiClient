using Akiles.ApiClient.Members;

namespace Akiles.ApiClient.Events;

public record Event
{
    public string Id { get; set; } = null!;

    //public required string OrganizationId { get; set; }
    public required EventSubject Subject { get; set; }
    public Member? SubjectMember { get; set; }
    public required EventVerb Verb { get; set; }
    public required EventObject Object { get; set; }
    public Member? ObjectMember { get; set; }
    public MemberPin? ObjectMemberPin { get; set; }
    public DateTime CreatedAt { get; set; }
}
