using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Category
    {
        private int categoryId;
        private int typeId;
        private int countryId;
        private int tasteId;

        public Category(int _categoryId, int _typeId, int _countryId, int _tasteId)
        {
            this.categoryId = _categoryId;
            this.typeId = _typeId;
            this.countryId = _countryId;
            this.tasteId = _tasteId;
        }

        public int getCategoryId()
        {
            return this.categoryId;
        }
        public int getType()
        {
            return this.typeId;
        }
        public int getCountry()
        {
            return this.countryId;
        }
        public int getTaste()
        {
            return this.tasteId;
        }

        public void setType(int _type)
        {
            this.typeId = _type;
        }
        public void setCountry(int _country)
        {
            this.countryId = _country;
        }
        public void setTaste(int _taste)
        {
            this.tasteId = _taste;
        }
    }
}