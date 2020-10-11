using _2einleveropdracht.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2c2inleveropdracht2
{
    public partial class manageCategories : System.Web.UI.Page
    {
        //Creates an object from the DAL class, to access the database
        static Dal dal = new Dal();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Makes the add category form invisible until the button for it is triggered
            addCategoryForm.Visible = false;
        }

        protected void addCategory_Click(object sender, EventArgs e)
        {
            // adds a new category based on the info from the drop down lists

            Category newCategory = new Category(0, Convert.ToInt32(DropDownTypeName.SelectedValue), Convert.ToInt32(dropDownCountryName.SelectedValue),
                Convert.ToInt32(DropDownTasteName.SelectedValue));

            dal.addCategory(newCategory);
        }

        protected void updateCategory_Click(object sender, EventArgs e)
        {
            // Updates the chosen category with the info from the dropdown lists
            Category currentValue = dal.getCategory(Convert.ToInt32(idLabel.Text));

            currentValue.setCountry(Convert.ToInt32(dropDownCountryName.SelectedValue));
            currentValue.setType(Convert.ToInt32(DropDownTypeName.SelectedValue));
            currentValue.setTaste(Convert.ToInt32(DropDownTasteName.SelectedValue));

            dal.updateCategory(currentValue);
        }

        protected void gridViewCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When the 'edit' button in the gridview is clicked, the info from that row wil be translated to the form's drop down lists. Those van be used to update the info
            if (e.CommandName == "editCategory")
            {

                var rowIndex = int.Parse(e.CommandArgument.ToString());
                var selectedRow = ((GridView)sender).Rows[rowIndex];
                System.Diagnostics.Debug.WriteLine("ID: ", selectedRow.Cells[0].Text);
                Category currentValues = dal.getCategory(Convert.ToInt32(selectedRow.Cells[0].Text));

                idLabel.Text = currentValues.getCategoryId().ToString();
                
                dropDownCountryName.SelectedIndex = currentValues.getCountry();
                DropDownTasteName.SelectedIndex = currentValues.getTaste();
                DropDownTypeName.SelectedIndex = currentValues.getType();

            }

            // When the 'delete' button in the gridview is clicked, it will delete that record from the database, using it's ID
            else if (e.CommandName == "deleteCategory")
            {
                var rowIndex = int.Parse(e.CommandArgument.ToString());
                var selectedRow = ((GridView)sender).Rows[rowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Text);

                dal.deleteCategory(id);

            }
        }

        protected void addCategoryButton_Click(object sender, EventArgs e)
        {
            // shows the add or edit form when clicked
            if (addCategoryForm.Visible == false)
            {
                addCategoryForm.Visible = true;
                addCategory.Visible = true;
            }
            else if (addCategoryForm.Visible == true)
            {
                addCategoryForm.Visible = false;

            }
            
        }
    }
}