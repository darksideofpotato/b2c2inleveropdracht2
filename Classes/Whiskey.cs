using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Whiskey
    {
        private int whiskeyId;
        private string name;
        private string age;
        private int categoryId;
        private double currentMarketValue;
        private double purchasePrise;
        private string description;
        private int brandId;
        private string alcoholPercentage;
        private string isSealed;
        private string baseIngredient;
        private int collectionId;

        public Whiskey(int _whiskeyId, string _name, string _age, int _categoryId, double _currentMarketvalue,
            double _purchasePrice, string _description, int _brandId, string _alcoholPercentage, string _isSealed,
            string _baseIngredient, int _cId)
        {
            this.whiskeyId = _whiskeyId;
            this.name = _name;
            this.age = _age;
            this.categoryId = _categoryId;
            this.currentMarketValue = _currentMarketvalue;
            this.purchasePrise = _purchasePrice;
            this.description = _description;
            this.brandId = _brandId;
            this.alcoholPercentage = _alcoholPercentage;
            this.isSealed = _isSealed;
            this.baseIngredient = _baseIngredient;
            this.collectionId = _cId;
        }

        public string getName()
        {
            return this.name;
        }

        public string getAge()
        {
            return this.age;
        }

        public int getCategoryId()
        {
            return this.categoryId;
        }

        public double getCurrentMarketValue()
        {
            return this.currentMarketValue;
        }

        public double getPurchasePrice()
        {
            return this.purchasePrise;
        }

        public string getDescription()
        {
            return this.description;
        }

        public int getBrandId()
        {
            return this.brandId;
        }

        public string getAlcoholPercentage()
        {
            return this.alcoholPercentage;
        }

        public string getIsSealed()
        {
            return this.isSealed;
        }

        public string getBaseIngredient()
        {
            return this.baseIngredient;
        }
        public int getId()
        {
            return this.whiskeyId;
        }
        public int getCollectionId()
        {
            return this.collectionId;
        }
        public void setWhiskeyName(string _name)
        {
            this.name = _name;
        }
        public void setWhiskeyAge(string _age)
        {
            this.age = _age;
        }
        public void setCategoryId(int _cid)
        {
            this.categoryId = _cid;
        }
        public void setCurrentValue(double _currentValue)
        {
            this.currentMarketValue = _currentValue;
        }
        public void setPurchasePrice(double _purchasePrice)
        {
            this.purchasePrise = _purchasePrice;
        }
        public void setDescription(string _description)
        {
            this.description = _description;
        }
        public void setBrandId(int _brandId)
        {
            this.brandId = _brandId;
        }
        public void setAlcoholPercantage(string _alcoholPercentage)
        {
            this.alcoholPercentage = _alcoholPercentage;
        }
        public void setSealed(string _sealed)
        {
            this.isSealed = _sealed;
        }
        public void setBaseIngredient(string _baseIngredient)
        {
            this.baseIngredient = _baseIngredient;
        }
    }
}