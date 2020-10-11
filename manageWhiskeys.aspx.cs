using _2einleveropdracht.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2c2inleveropdracht2
{
    public partial class manageWhiskeys : System.Web.UI.Page
    {
        //Creates an object from the DAL class, to access the database
        static Dal dal = new Dal();
        protected void Page_Load(object sender, EventArgs e)
        {

            #region fill gridview
            // Fills the datagridview with the datatable from the whiskeyview. It has more elaborate data than the whiskey table itself.
            DataTable dt = dal.fillDataGridWhiskeys();

            gridViewWhiskeys.DataSource = dt;
            gridViewWhiskeys.DataBind();

            #endregion

            #region setDropDownCategory
            // Populates the dropdown list for the categories, since it required more than one name in the datatextfield, and this wasn't possible in the webforms method itself

            if (!IsPostBack)
            {
                DataTable dtb = dal.getCategories();

                dropDownCategory.DataSource = dtb;
                dropDownSortCategories.DataSource = dtb;
                dtb.Columns.Add("categoryInfo", typeof(string), "countryName + ' - ' +  tasteName + ' - ' + typeName");
                dropDownCategory.DataBind();
                dropDownSortCategories.DataBind();

                dropDownCategory.DataTextField = "categoryInfo";
                dropDownSortCategories.DataTextField = "categoryInfo";
                dropDownCategory.DataValueField = "categoryId";
                dropDownSortCategories.DataValueField = "categoryId";
                dropDownCategory.DataBind();
                dropDownSortCategories.DataBind();
            }

            #endregion

        }

        protected void addAWhiskey_Click(object sender, EventArgs e)
        {
            // Makes an object from the filled-in form. No checks on input. Triggers the method to add a whiskey to the database

            Whiskey newWhiskey = new Whiskey(0, whiskeyName.Value, whiskeyAge.Value, Convert.ToInt32(dropDownCategory.SelectedValue), 
                Convert.ToDouble(currentWhiskeyValue.Value), Convert.ToDouble(whiskeyPurchasePrice.Value), whiskeyDescription.Value, 
                Convert.ToInt32(whiskeyBrand.SelectedValue), whiskeyAlcoholPercentage.Value, isWhiskeySealed.SelectedValue, whiskeyBaseIngredient.Value, Convert.ToInt32(dropdownCollections.SelectedValue));

            dal.addWhiskey(newWhiskey);
        }

        protected void gridViewWhiskeys_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When the 'edit' button in the gridview is clicked, the info from that row wil be translated to the form's drop down lists. Those van be used to update the info
            if (e.CommandName == "EditWhiskey")
            {
                addwhiskeyForm.Visible = true;
                updateWhiskey.Visible = true;

                var rowIndex = int.Parse(e.CommandArgument.ToString());
                var selectedRow = ((GridView)sender).Rows[rowIndex];
                Whiskey currentValues = dal.getWhiskey(Convert.ToInt32(selectedRow.Cells[15].Text));

                idLabel.Text = currentValues.getId().ToString();
                whiskeyName.Value = currentValues.getName();
                whiskeyAge.Value = currentValues.getAge(); ;
                dropDownCategory.SelectedIndex = currentValues.getCategoryId() - 1;
                currentWhiskeyValue.Value = currentValues.getCurrentMarketValue().ToString();
                whiskeyPurchasePrice.Value = currentValues.getPurchasePrice().ToString();
                whiskeyDescription.Value = currentValues.getDescription();
                whiskeyBrand.SelectedIndex = currentValues.getBrandId() - 1;
                whiskeyAlcoholPercentage.Value = currentValues.getAlcoholPercentage();
                isWhiskeySealed.SelectedValue = currentValues.getIsSealed();
                whiskeyBaseIngredient.Value = currentValues.getBaseIngredient();

            }
            // When the 'delete' button in the gridview is clicked, it will delete that record from the database, using it's ID
            else if (e.CommandName == "deleteWhiskey")
            {
                var rowIndex = int.Parse(e.CommandArgument.ToString());
                var selectedRow = ((GridView)sender).Rows[rowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[15].Text);

                dal.deleteWhiskey(id);

            }
        }

        protected void updateWhiskey_Click(object sender, EventArgs e)
        {
            // Creates an object based on the filled in form, and updates the whiskey data
            Whiskey currentValue = dal.getWhiskey(Convert.ToInt32(idLabel.Text));

            currentValue.setWhiskeyName(whiskeyName.Value);
            currentValue.setWhiskeyAge(whiskeyAge.Value);
            currentValue.setCategoryId(Convert.ToInt32(dropDownCategory.SelectedValue));
            currentValue.setCurrentValue(Convert.ToDouble(currentWhiskeyValue.Value));
            currentValue.setPurchasePrice(Convert.ToDouble(whiskeyPurchasePrice.Value));
            currentValue.setBrandId(Convert.ToInt32(whiskeyBrand.SelectedValue));
            currentValue.setDescription(whiskeyDescription.Value);
            currentValue.setAlcoholPercantage(whiskeyAlcoholPercentage.Value);
            currentValue.setSealed(isWhiskeySealed.SelectedValue);
            currentValue.setBaseIngredient(whiskeyBaseIngredient.Value);


            dal.updateWhiskey(currentValue);
        }

        protected void selectedIndexChanged_user(object sender, EventArgs e)
        {
            // Changes the collection based on the chosen user
            int userId = Convert.ToInt32(dropdownCollections.SelectedValue);
            DataTable dt = dal.fillDataGridWhiskeysOnChange(userId);

            gridViewWhiskeys.DataSource = dt;
            gridViewWhiskeys.DataBind();
        }

        protected void dropDownSortCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changes the gridview based on the chosen category
            int categoryId = Convert.ToInt32(dropDownSortCategories.SelectedValue);
            DataTable dt = dal.fillDataGridWhiskeysOnCategoryChange(categoryId);

            gridViewWhiskeys.DataSource = dt;
            gridViewWhiskeys.DataBind();
        }

        protected void whiskey_onRowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Calculates the profit margin of the whiskey based upon the purchase price and the current market value
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double currentValue = Convert.ToDouble(e.Row.Cells[14].Text); 
                double purchasePrice = Convert.ToDouble(e.Row.Cells[13].Text);
                Label calculationLabel = e.Row.FindControl("calculationLabel") as Label;
                calculationLabel.Text = Convert.ToString(currentValue - purchasePrice);
            }
        }
    }
}

