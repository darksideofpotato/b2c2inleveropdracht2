using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;


namespace _2einleveropdracht.Classes
{
    public class Dal
    {
        #region Database methods     
        // Basis connection method
        static SqlConnection con;
        public SqlConnection databaseConnect()
        {
            string connectionString = @"Data Source=JUDITH-PC;Initial Catalog=CollectionsDB;Integrated Security=True";

            con = new SqlConnection(connectionString);

            con.Open();

            return con;
        }

        #endregion

        #region Manage Whiskeys

        // Method that returns the datatable from the mainWhiskeyView, to then use as a datasource for a datagridview
        public DataTable fillDataGridWhiskeys()
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("Select * FROM mainWhiskeyView", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }

        // Changes the data in the datagridview based on which user is selected from the dropdown
        public DataTable fillDataGridWhiskeysOnChange(int userId)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("Select * FROM mainWhiskeyView WHERE collectionId = @ID", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.AddWithValue("@ID", userId);
            da.Fill(dt);

            return dt;
        }


        // Changes the data in the datagridview based on which category is selected from the dropdown
        public DataTable fillDataGridWhiskeysOnCategoryChange(int categoryId)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("Select * FROM mainWhiskeyView WHERE categoryId = @ID", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Parameters.AddWithValue("@ID", categoryId);
            da.Fill(dt);

            return dt;
        }

       
        // Method to add a whiskey to the databased with a given object
        public void addWhiskey(Whiskey whiskey)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("insert into Whiskeys(name,age,categoryId,currentMarketValue," +
                "purchasePrice,description,brandId,alcoholPercentage,sealed,baseIngredient,collectionId) values (@name," +
                "@age,@categoryId,@currentMarketValue,@purchasePrice,@description,@brandId,@alcoholPercentage," +
                "@sealed,@baseingredient,@collectionId)", con);

            cmd.Parameters.AddWithValue("@name", whiskey.getName());
            cmd.Parameters.AddWithValue("@age", whiskey.getAge());
            cmd.Parameters.AddWithValue("@categoryId", whiskey.getCategoryId());
            cmd.Parameters.AddWithValue("@currentMarketValue", whiskey.getCurrentMarketValue());
            cmd.Parameters.AddWithValue("@purchasePrice", whiskey.getPurchasePrice());
            cmd.Parameters.AddWithValue("@description", whiskey.getDescription());
            cmd.Parameters.AddWithValue("@brandId", whiskey.getBrandId());
            cmd.Parameters.AddWithValue("@alcoholPercentage", whiskey.getAlcoholPercentage());
            cmd.Parameters.AddWithValue("@sealed", whiskey.getIsSealed());
            cmd.Parameters.AddWithValue("@baseingredient", whiskey.getBaseIngredient());
            cmd.Parameters.AddWithValue("@collectionId", whiskey.getCollectionId());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Method to update a whiskey to the databased with a given object
        public void updateWhiskey(Whiskey whiskey)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("UPDATE Whiskeys SET name = @name, age = @age, categoryId = @categoryId," +
                "currentMarketValue = @currentMarketValue, purchasePrice = @purchasePrice, description = @description, " +
                "brandId = @brandId, alcoholPercentage = @alcoholPercentage, sealed = @sealed, baseingredient = @baseingredient WHERE whiskeyId = @ID", con);

            cmd.Parameters.AddWithValue("@ID", whiskey.getId());
            cmd.Parameters.AddWithValue("@name", whiskey.getName());
            cmd.Parameters.AddWithValue("@age", whiskey.getAge());
            cmd.Parameters.AddWithValue("@categoryId", whiskey.getCategoryId());
            cmd.Parameters.AddWithValue("@currentMarketValue", whiskey.getCurrentMarketValue());
            cmd.Parameters.AddWithValue("@purchasePrice", whiskey.getPurchasePrice());
            cmd.Parameters.AddWithValue("@description", whiskey.getDescription());
            cmd.Parameters.AddWithValue("@brandId", whiskey.getBrandId());
            cmd.Parameters.AddWithValue("@alcoholPercentage", whiskey.getAlcoholPercentage());
            cmd.Parameters.AddWithValue("@sealed", whiskey.getIsSealed());
            cmd.Parameters.AddWithValue("@baseingredient", whiskey.getBaseIngredient());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Method to get the whiskey info with a given whiskey ID. Returns an object from the class whiskey with the received information
        public Whiskey getWhiskey(int ID)
        {
            SqlConnection con = databaseConnect();
            string cmd = "Select * FROM Whiskeys WHERE whiskeyId = @ID";
      
            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            ad.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach(DataRow row in dt.Rows)
                {
                    objectList.Add(row[col.ColumnName].ToString());
                }
            }

            Whiskey newWhiskey = new Whiskey(Convert.ToInt32(objectList[0]), objectList[1], objectList[2], Convert.ToInt32(objectList[3]),
                Convert.ToDouble(objectList[4]), Convert.ToDouble(objectList[5]), objectList[6], Convert.ToInt32(objectList[7]),
                objectList[8], objectList[9], objectList[10], Convert.ToInt32(objectList[11]));

            return newWhiskey;
        }

        // Delete a whiskey with the given ID
        public void deleteWhiskey(int ID)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("DELETE FROM Whiskeys WHERE whiskeyId = @ID", con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        #region Manage Categories

        // Returns a datatable from the category view. Used to populate a datagridview
        public DataTable getCategories()
        {
            SqlConnection con = databaseConnect();
            string cmd = "Select * FROM categoryView";
            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);


            return dt;
        }

        // Adds a new category to the databased based on an object
        public void addCategory(Category newCategory)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("insert into Categories(typeId, countryId, tasteId) values (@type," +
                "@country,@taste)", con);

            cmd.Parameters.AddWithValue("@type", newCategory.getType());
            cmd.Parameters.AddWithValue("@country", newCategory.getCountry());
            cmd.Parameters.AddWithValue("@taste", newCategory.getTaste());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Get category information from an object
        public Category getCategory(int ID)
        {
            SqlConnection con = databaseConnect();
            string cmd = "Select * FROM Categories WHERE categoryId = @ID";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            ad.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objectList.Add((Convert.ToInt32(row[col.ColumnName])-1).ToString());
                }
            }
          
            Category newCategory = new Category((Convert.ToInt32(objectList[0])+1), Convert.ToInt32(objectList[1]), Convert.ToInt32(objectList[2]), Convert.ToInt32(objectList[3]));

            return newCategory;
        }

        // Updates a category with the information from a given object
        public void updateCategory(Category category)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("UPDATE Categories SET typeId = @typeId, countryId = @countryId, tasteId = @tasteId WHERE categoryId = @ID", con);

            cmd.Parameters.AddWithValue("@ID", category.getCategoryId());
            cmd.Parameters.AddWithValue("@typeId", category.getType());
            cmd.Parameters.AddWithValue("@countryId", category.getCountry());
            cmd.Parameters.AddWithValue("@tasteId", category.getTaste());


            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Deletes a category based on the given ID
        public void deleteCategory(int ID)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE categoryId = @ID", con);

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

    }
}