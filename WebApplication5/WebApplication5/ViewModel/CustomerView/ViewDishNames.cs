using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.ViewModel.CustomerView
{
    public class NameofItem
    {
        public int menuanddishID { get; set; }
        public int menuID { get; set; }
        public int dishID { get; set; }

        public string dishName { get; set; }

        public NameofItem()
        {
            Resources = new List<string>();
            Beve = new List<string>();
            Desert= new List<string>();
        }

        public List<string> Resources { get; set; }
        public List<string> Beve { get; set; }
        public List<string> Desert { get; set; }





    }

 

}