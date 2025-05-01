using Refit;

namespace Akiles.ApiClient.MemberGroups;

public interface IMemberGroups
{
    [Get("/member_groups")]
    Task<PagedList<MemberGroup>> ListMemberGroupsAsync(
        string? cursor,
        int? limit,
        Sort<MemberGroup>? sort,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<MemberGroup> ListMemberGroupsAsync(Sort<MemberGroup>? sort = null) =>
        new PaginationEnumerable<MemberGroup>(
            (cursor, cancellationToken) =>
                ListMemberGroupsAsync(
                    cursor,
                    Constants.DefaultPaginationLimit,
                    sort,
                    cancellationToken
                )
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
