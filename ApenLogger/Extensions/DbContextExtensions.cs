namespace Apen.Extensions
{
    public static class DbContextExtensions //: DbContext
    {
        // public static SetAuditValues(this object, string username)
        // {
        //     var changeSet = ChangeTracker.Entries().Where(q => q.Entity is Item || q.Entity is Auditable || q.Entity is Document);

        //     if (changeSet != null)
        //     {
        //         foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
        //         {
        //             var e = entry.Entity is Item ? (Item)entry.Entity :
        //             entry.Entity is Document ? (Document)entry.Entity :
        //             entry.Entity is Auditable ? (Auditable)entry.Entity :
        //             (Approvable)entry.Entity;
        //             if (e.Version == 0)
        //             {
        //                 e.Version = 1;
        //                 e.Created = e.Modified = System.DateTime.Now;
        //                 e.CreatedBy = e.ModifiedBy;
        //             }
        //             else
        //             {
        //                 e.Version += 1;
        //                 e.Modified = System.DateTime.Now;
        //             }
        //         }
        //     }
        // }

    }
}