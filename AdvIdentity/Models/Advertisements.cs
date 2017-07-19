using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvIdentity.Models
{
    public class AdvertisementsViewModel
    {
        public UInt32 AdvId
        { get; set; }
        public string CreatorId
        { get; set; }
        public string Type
        { get; set; }
        public string Description
        { get; set; }
        public int Price
        { get; set; }
    }
    public class AdvertisementsCreateModel
    {
        public UInt32 AdvId
        { get; set; }
        public string CreatorId
        { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} should not exceed more than 20 characters")]
        public string Type
        { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should not exceed more than 100 characters")]
        public string Description
        { get; set; }
        [Required]
        public int Price
        { get; set; }
    }
}
