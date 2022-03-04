using SOMIService.Models.Base;
using SOMIService.Models.Enums;
using SOMIService.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Models
{
    public class FailureLogging

    {
        [Key]
        public int FailureLoggingId { get; set; }
        public string UserId { get; set; }
        public string OperatorId { get; set; }
        public string TechnicianId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description{ get; set; }
        public bool TechnicianIsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? TechnicianAssignDate { get; set; }
        [DisplayName("İşlem Durumu")]
        public OperationStatuses OperationStatus { get; set; } = OperationStatuses.Pending;
        [DisplayName("İşlem Zamanı")]
        public DateTime? OperationTime { get; set; }
        [Display(Name = "Arıza Giderildi Mi")]
        public bool FaultIsFixxed { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public decimal? TotalPrice { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey(nameof(TechnicianId))]
        //public virtual ApplicationUser Technician { get; set; }


    }
}
