using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apen.Entity
{
    public class ItemVersion
    {
        public ItemVersion()
        {
            
        }
        public ItemVersion(string item,int itemId,int version,DateTime date,string user,string detail)
        {
            Item = item;
            ItemId = itemId;
            Version = version;
            Date = date;
            User = user;
            Detail = detail;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true, AutoGenerateFilter = true, Name = "Id", Order = 1, Prompt = "Id")]
        public int Id { get; set; }
        public string Item { get; set; }
        public int ItemId { get; set; }
        public int Version { get; set; }
        [ConcurrencyCheck()]
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Detail { get; set; }
    }
}
