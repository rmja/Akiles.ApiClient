using System.Runtime.CompilerServices;
using Akiles.ApiClient.Members;
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
    Task<MemberGroup> CreateMemberAsync(
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
    Task<MemberGroup> DeleteMemberAsync(
        string memberGroupId,
        CancellationToken cancellationToken = default
    );

    [Get("/members")]
    internal Task<PagedList<Member>> ListMembersAsync(
        string? cursor,
        int? limit,
        Sort<Member>? sort,
        ListMembersFilter? filter = null,
        MembersExpand expand = MembersExpand.None,
        CancellationToken cancellationToken = default
    );
}

public static class MemberGroupsExtensions
{
    public static async IAsyncEnumerable<MemberGroupAssociation> ListMemberAssociationsAsync(
        this IMemberGroups memberGroups,
        string memberGroupId,
        MemberGroupsExpand expand = MemberGroupsExpand.None,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var page = await memberGroups.ListMembersAsync(
            cursor: null,
            limit: Constants.DefaultPaginationLimit,
            sort: null,
            filter: null,
            expand: MembersExpand.GroupAssociations,
            cancellationToken
        );

        while (!cancellationToken.IsCancellationRequested)
        {
            foreach (var member in page.Data)
            {
                if (member.GroupAssociations is null)
                {
                    continue;
                }

                foreach (
                    var association in member.GroupAssociations.Where(x =>
                        x.MemberGroupId == memberGroupId
                    )
                )
                {
                    if (expand.HasFlag(MemberGroupsExpand.Member))
                    {
                        association.Member = member;
                    }

                    yield return association;
                }
            }

            if (!page.HasNext)
            {
                break;
            }

            page = await memberGroups.ListMembersAsync(
                cursor: page.CursorNext,
                limit: Constants.DefaultPaginationLimit,
                sort: null,
                filter: null,
                expand: MembersExpand.GroupAssociations,
                cancellationToken
            );
        }
    }
}
