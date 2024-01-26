﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Reddit.Domain.Entities.Base;

namespace Reddit.Domain.Database;
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            entry.State = EntityState.Modified;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        }
        return result;
    }
}
