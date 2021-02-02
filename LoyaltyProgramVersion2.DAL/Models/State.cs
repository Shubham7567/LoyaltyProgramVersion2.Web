using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoyaltyProgramVersion2.DAL.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Name { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
