using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models.DB;

namespace WebApplication5.ViewModel.CustomerView
{
    public class AdditionalfacilitiesINFO
    {
        public int additionalandfunctionID { get; set; }
        public int functionID { get; set; }
        public int functionName { get; set; }
        public int additionalID { get; set; }
        public string additionalName { get; set; }
        public Nullable<int> additionalFacilityPrice { get; set; }

        public void Deleteadditional(int id)
        {
            List<AdditionalFacilitiesandFunction> addi = new List<AdditionalFacilitiesandFunction>();
            using (MehriamarqueeEntities meh = new MehriamarqueeEntities())
            {
                addi = meh.AdditionalFacilitiesandFunctions.Where(x => x.functionID.Equals(id)).ToList();
                foreach (var item in addi)
                {
                    meh.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    meh.SaveChanges();
                }
            }
        }
    }

   
}