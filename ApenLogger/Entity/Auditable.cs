using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apen
{
    public abstract class Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true, AutoGenerateFilter = true, Name = "Id", Order = 1, Prompt = "Id")]
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }
        [Display(AutoGenerateField = true, AutoGenerateFilter = true, Name = "Title", Order = 2, Prompt = "Full Title")]
        [DataType(DataType.Text)]
        public virtual string Title { get; set; }
        [Required]
        [DefaultValue(0)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Version", Order = 93, Prompt = "Version")]
        [ScaffoldColumn(false)]
        public virtual int Version { get; set; }
        [DataType(DataType.DateTime)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Created", Order = 94, Prompt = "Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public virtual DateTime Created { get; set; }
        [DataType(DataType.Text)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Created By", Order = 95, Prompt = "Created By")]
        [ScaffoldColumn(false)]
        public virtual string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Modified", Order = 96, Prompt = "Modified")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public virtual DateTime Modified { get; set; }
        [DataType(DataType.Text)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Modified By", Order = 97, Prompt = "Modified By")]
        [ScaffoldColumn(false)]
        public virtual string ModifiedBy { get; set; }
        [Required]
        [DefaultValue(false)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Approval Status", Order = 98, Prompt = "Approval Status")]
        public virtual bool ApprovalStatus { get; set; }
        [DataType(DataType.DateTime)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Approved", Order = 99, Prompt = "Approved")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public virtual DateTime Approved { get; set; }
        [DataType(DataType.Text)]
        [ScaffoldColumn(false)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Approved By", Order = 100, Prompt = "Approved By")]
        public virtual string ApprovedBy { get; set; }
        [ScaffoldColumn(false)]
        [Display(AutoGenerateField = false, AutoGenerateFilter = true, Name = "Status", Order = 101, Prompt = "Status")]
        public ItemStatus Status { get; set; }
    }
}
