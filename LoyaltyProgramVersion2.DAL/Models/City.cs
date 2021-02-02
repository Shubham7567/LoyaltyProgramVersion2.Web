using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoyaltyProgramVersion2.DAL.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string Name { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}
