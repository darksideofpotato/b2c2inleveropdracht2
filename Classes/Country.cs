using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Country
    {
        private int countryId;
        private string countryName;

        public Country(int _countryId, string _countryName)
        {
            this.countryId = _countryId;
            this.countryName = _countryName;
        }
           
    }
}