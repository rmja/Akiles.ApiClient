using Akiles.ApiClient.Members;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface IMembers
{
    [Get("/members")]
    [GenerateEnumerator]
    Task<PagedList<Member>> ListMembersAsync(
        Sort<Member>? sort = null,
        [Query(delimiter: "")] ListMembersFilter? filter = null,
        MembersExpand expand = MembersExpand.None,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}")]
    Task<Member> GetMemberAsync(
        string memberId,
        //MembersExpand expand = MembersExpand.None,
        CancellationToken cancellationToken = default
    );

    [Post("/members")]
    Task<Member> CreateMemberAsync(
        MemberInit member,
        CancellationToken cancellationToken = default
    );

    [Patch("/members/{memberId}")]
    Task<Member> EditMemberAsync(
        string memberId,
        MemberPatch patch,
        CancellationToken cancellationToken = default
    );

    [Delete("/members/{memberId}")]
    Task<Member> DeleteMemberAsync(string memberId, CancellationToken cancellationToken = default);

    [Post("/members/{memberId}/emails")]
    Task<MemberEmail> CreateEmailAsync(
        string memberId,
        MemberEmailInit email,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}/emails")]
    [GenerateEnumerator]
    Task<PagedList<MemberEmail>> ListEmailsAsync(
        string memberId,
        Sort<MemberEmail>? sort = null,
        string? q = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Patch("/members/{memberId}/emails/{memberEmailId}")]
    Task<MemberEmail> EditEmailAsync(
        string memberId,
        string memberEmailId,
        MemberEmailPatch patch,
        CancellationToken cancellationToken = default
    );

    [Post("/members/{memberId}/pins")]
    Task<MemberPinRevealed> CreatePinAsync(
        string memberId,
        MemberPinInit pin,
        CancellationToken cancellationToken = default
    );

    [Post("/members/{memberId}/cards")]
    Task<MemberCard> CreateCardAsync(
        string memberId,
        MemberCardInit card,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}/cards")]
    [GenerateEnumerator]
    Task<PagedList<MemberCard>> ListCardsAsync(
        string memberId,
        Sort<MemberCard>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}/cards/{memberCardId}")]
    Task<MemberCard> GetCardAsync(
        string memberId,
        string memberCardId,
        CancellationToken cancellationToken = default
    );

    [Patch("/members/{memberId}/cards/{memberCardId}")]
    Task<MemberCard> EditCardAsync(
        string memberId,
        string memberCardId,
        MemberCardPatch patch,
        CancellationToken cancellationToken = default
    );

    [Delete("/members/{memberId}/cards/{memberCardId}")]
    Task<MemberCard> DeleteCardAsync(
        string memberId,
        string memberCardId,
        CancellationToken cancellationToken = default
    );

    [Post("/members/{memberId}/group_associations")]
    Task<MemberGroupAssociation> CreateGroupAssociationAsync(
        string memberId,
        MemberGroupAssociationInit group,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}/group_associations")]
    [GenerateEnumerator]
    Task<PagedList<MemberGroupAssociation>> ListGroupAssociationsAsync(
        string memberId,
        Sort<MemberGroupAssociation>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/members/{memberId}/group_associations/{memberGroupAssociationId}")]
    Task<MemberGroupAssociation> GetGroupAssociationAsync(
        string memberId,
        string memberGroupAssociationId,
        CancellationToken cancellationToken = default
    );

    [Patch("/members/{memberId}/group_associations/{memberGroupAssociationId}")]
    Task<MemberGroupAssociation> EditGroupAssociationAsync(
        string memberId,
        string memberGroupAssociationId,
        MemberCardPatch patch,
        CancellationToken cancellationToken = default
    );

    [Delete("/members/{memberId}/group_associations/{memberGroupAssociationId}")]
    Task<MemberGroupAssociation> DeleteGroupAssociationAsync(
        string memberId,
        string memberGroupAssociationId,
        CancellationToken cancellationToken = default
    );
}
