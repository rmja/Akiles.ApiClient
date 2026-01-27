using Akiles.ApiClient.MemberGroups;
using Cursor;
using Refit;

namespace Akiles.ApiClient;

public interface IMemberGroups
{
    [Get("/member_groups")]
    [GenerateEnumerator]
    Task<PagedList<MemberGroup>> ListMemberGroupsAsync(
        Sort<MemberGroup>? sort = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );

    [Get("/member_groups/{memberGroupId}")]
    Task<MemberGroup> GetMemberGroupAsync(
        string memberGroupId,
        CancellationToken cancellationToken = default
    );

    [Post("/member_groups")]
    Task<MemberGroup> CreateMemberGroupAsync(
        MemberGroupInit member,
        CancellationToken cancellationToken = default
    );

    [Patch("/member_groups/{memberGroupId}")]
    Task<MemberGroup> EditMemberGroupAsync(
        string memberGroupId,
        MemberGroupPatch patch,
        CancellationToken cancellationToken = default
    );

    [Delete("/member_groups/{memberGroupId}")]
    Task<MemberGroup> DeleteMemberGroupAsync(
        string memberGroupId,
        CancellationToken cancellationToken = default
    );
}
