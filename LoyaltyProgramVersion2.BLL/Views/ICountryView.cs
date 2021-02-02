using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LoyaltyProgramVersion2.BLL.Views
{
    public interface ICountryView
    {
        int CountryID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(length:200,ErrorMessage ="Name must be less than 200 characters.")]
        string Name { get; set; }
        List<CountryListView> CountryList { get; set; }
        List<CountryListView> Search(string search);
        void Add();
        void Update();
        void Edit(int id);
    }

    public class CountryListView
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
