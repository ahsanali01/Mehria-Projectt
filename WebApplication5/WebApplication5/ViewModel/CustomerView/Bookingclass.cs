using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models.DB;

namespace WebApplication5.ViewModel.CustomerView
{
    public class Bookingclass
    {
        public List<Bookingdata> GetBookingdetail()
        {
            List<Bookingdata> bookdatas = new List<Bookingdata>();
            using (MehriamarqueeEntities4 db = new MehriamarqueeEntities4())
            {
                bookdatas = db.Bookingdatas.ToList();
            }
            return bookdatas;
        }
    }
}