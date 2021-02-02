using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoyaltyProgramVersion2.BLL.Views;
using LoyaltyProgramVersion2.DAL.Models;

namespace LoyaltyProgramVersion2.BLL.Operations
{
    public class CountryOperator : ICountryView
    {
        public string Name { get; set; }
        public List<CountryListView> CountryList { get; set; }
        public int CountryID { get; set; }

        public void Add()
        {
            CountryID = 0;
            Name = String.Empty;
        }

        public void Edit(int id)
        {
            LoyaltyProgramContext db = new LoyaltyProgramContext();
            try {
                var country = db.Country.Where(x => x.CountryID == id).FirstOrDefault();
                CountryID = country.CountryID;
                Name = country.Name;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<CountryListView> Search(string search)
        {
            LoyaltyProgramContext db = new LoyaltyProgramContext();
            try
            {
                CountryList = new List<CountryListView>();
                var countries = new List<Country>();
                if (search == null)
                {
                    countries = db.Country.ToList();
                }
                else {
                    countries = db.Country.Where(x => x.Name.Contains(search)).ToList();
                }
                foreach (var item in countries)
                {
                    CountryListView country = new CountryListView();
                    country.CountryID = item.CountryID;
                    country.Name = item.Name;
                    country.IsDeactivated = item.IsDeactivated;
                    country.CreatedOn = item.CreatedOn;
                    country.ModifiedOn = item.ModifiedOn;
                    CountryList.Add(country);
                }
                return CountryList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }

        public void Update()
        {
            LoyaltyProgramContext db = new LoyaltyProgramContext();
            try {
                var country = db.Country.Where(x => x.CountryID == CountryID).FirstOrDefault();
                if (country == null)
                {
                    country = new Country();
                    country.CreatedOn = DateTime.Now;
                    country.IsDeactivated = false;
                    db.Country.Add(country);
                }
                country.Name = Name;
                country.ModifiedOn = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        public void Delete(int id)
        {
            LoyaltyProgramContext db = new LoyaltyProgramContext();
            try
            {
                Country country = db.Country.Where(x => x.CountryID == id).FirstOrDefault();
                db.Country.Remove(country);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
