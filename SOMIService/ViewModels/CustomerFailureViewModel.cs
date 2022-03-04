using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.ViewModels
{
    public class CustomerFailureViewModel
    {
        public string UserId { get; set; }
        public int FailureLoggingId { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı gereklidir.")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [StringLength(100, MinimumLength = 20)]
        [Required(ErrorMessage = "Adress alanı gereklidir.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Arıza açıklama alanı gereklidir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool FaultIsFixxed { get; set; } = false;
    }
}
