using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apen.Entity
{
    public class Journal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true, AutoGenerateFilter = true, Name = "Id", Order = 1, Prompt = "Id")]
        public int Id { get; set; }
        public string Item { get; set; }
        public int ItemId { get; set; }
        public int Version { get; set; }
        public int ItemVersionId { get; set; }
        [ConcurrencyCheck()]
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
