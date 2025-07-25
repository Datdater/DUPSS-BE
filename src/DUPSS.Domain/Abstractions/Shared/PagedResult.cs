﻿using Microsoft.EntityFrameworkCore;

namespace DUPSS.Domain.Abstractions.Shared;

public class PagedResult<T>
{
    public static int UpperPageSize = 100;
    public static int DefaultPageSize = 10;
    public static int DefaultPageIndex = 1;

    public PagedResult(List<T> items, int pageIndex, int pageSize, int totalCount)
    {
        Items = items;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public int TotalCount { get; }
    public List<T> Items { get; }
    public int PageIndex { get; }
    public int PageSize { get; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex * PageSize < TotalCount;

    /// <summary>
    /// Use for query in repo
    /// </summary>
    /// <param name="query"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static async Task<PagedResult<T>> CreateAsync(
        IQueryable<T> query,
        int pageIndex,
        int pageSize
    )
    {
        pageIndex = pageIndex <= 0 ? DefaultPageIndex : pageIndex;
        pageSize =
            pageSize <= 0 ? DefaultPageSize
            : pageSize > UpperPageSize ? UpperPageSize
            : pageSize;

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<T>(items, pageIndex, pageSize, totalCount);
    }

    public static PagedResult<T> Create(
        List<T> items,
        int pageIndex,
        int pageSize,
        int totalCount
    ) => new(items, pageIndex, pageSize, totalCount);
}
