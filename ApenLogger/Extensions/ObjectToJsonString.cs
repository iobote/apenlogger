using System;
using System.Linq;
using Apen.Entity;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Apen.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJsonString(this object obj)
        {
            if (obj == null)
                return string.Empty;

            foreach (var item in obj.GetType().GetProperties().Where(q => q.Name.Contains("password")))
                item.SetValue(obj, "************************", null);

            string result = JsonSerializer.Serialize(obj); //JsonConvert.SerializeObject(obj);
            return result;
        }
        public static string GetString(this object obj)
        {
            if (obj == null)
                return string.Empty;

            string result = string.Empty;

            foreach (var item in obj.GetType().GetProperties().Where(q => q.Name.Contains("password")))
                item.SetValue(obj, "************************", null);

            foreach (var item in obj.GetType().GetProperties())
            {
                if (item.GetValue(obj) != null)
                    result += $"{item.Name} : {item.GetValue(obj)}\r\n";
            }
            return result;
        }
        public static string GetJsonString(this object obj)
        {
            foreach (var item in obj.GetType().GetProperties().Where(q => q.Name.Contains("password")))
                item.SetValue(obj, "************************", null);

            string result = System.Text.Json.JsonSerializer.Serialize(obj);
            return result;
        }
        // public static object SetAuditValues(this object obj, string user, )
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
        public static object SetAuditValues(this object obj, string user)
        {
            obj.GetType().GetProperties()
                .Where(q => "Version".Contains(q.Name) && q.PropertyType == typeof(int))
                .ToList()
                .ForEach(d => d.SetValue(obj, (int)d.GetValue(obj) + 1, null));

            int version = (int)obj.GetType().GetProperties()
                .FirstOrDefault(q => "Version".Contains(q.Name) && q.PropertyType == typeof(int))
                .GetValue(obj);

            if (version > 1)
            {
                obj.GetType().GetProperties()
                    .Where(q => "Modified,Approved".Contains(q.Name) && q.PropertyType == typeof(DateTime))
                    .ToList()
                    .ForEach(d => d.SetValue(obj, DateTime.Now, null));

                obj.GetType().GetProperties()
                    .Where(q => "ModifiedBy,ApprovedBy".Contains(q.Name) && q.PropertyType == typeof(string))
                    .ToList()
                    .ForEach(d => d.SetValue(obj, user, null));
            }
            else
            {
                obj.GetType().GetProperties()
                    .Where(q => "Created,Modified,Approved".Contains(q.Name) && q.PropertyType == typeof(DateTime))
                    .ToList()
                    .ForEach(d => d.SetValue(obj, DateTime.Now, null));

                obj.GetType().GetProperties()
                    .Where(q => "CreatedBy,ModifiedBy,ApprovedBy".Contains(q.Name) && q.PropertyType == typeof(string))
                    .ToList()
                    .ForEach(d => d.SetValue(obj, user, null));

                obj.GetType().GetProperties()
                    .Where(q => "Status".Contains(q.Name) && q.PropertyType == typeof(ItemStatus))
                    .ToList()
                    .ForEach(d => d.SetValue(obj, ItemStatus.Pending, null));
            }
            return obj;
        }
    }
}