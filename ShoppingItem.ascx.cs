using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Prog3.App_Code_folder;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Prog3
{
    public partial class ShoppingItem : System.Web.UI.UserControl
    {

        private string _theID, _theName;
        private double _thePrice, _theCost;
        private int _theQuantity;

        double price;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMess.Text = "";

            txtID.Text = _theID;
            txtName.Text = _theName;
            txtPrice.Text = string.Format("{0:C}", _thePrice);
            txtQuantity.Text = _theQuantity.ToString();
            txtCost.Text = string.Format("{0:C}", _theCost);

        }
        
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity;

            if (int.TryParse(txtQuantity.Text, out quantity) && quantity >= 0)
            {
                // update the object and display new cost
                _theQuantity = quantity;
                _theCost = _theQuantity * _thePrice;
                txtMess.Text = "";
                txtCost.Text = string.Format("{0:C}", _theCost);
            }
            else
            {
                // Error message on label and clear Cost
                txtCost.Text = "";
                txtMess.Text = "Invalid";
            }
        }
        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < SQLDataClass.tblProduct.Rows.Count; i++)
            {
                System.Data.DataRow row
                = SQLDataClass.tblProduct.Rows[i];
                string temp = row[0].ToString();
                if (txtID.Text.Equals(temp))
                {
                    txtName.Text = row[1].ToString();
                    txtPrice.Text = string.Format("{0:C}", row[2]);
                    Double.TryParse(row[2].ToString(), out price);
                }
            }
            Session["Prog2_ProductPrice"] = txtPrice.Text;
            Session["Prog2_ProductQuantity"] = txtQuantity.Text;
            Session["Prog2_ProductID"] = txtID.Text;
            Session["Prog2_Computed"] = true;
            txtPrice.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            txtID.ReadOnly = true;
            CalculateTotals();
            
        }
        protected void CalculateTotals()
        {


            double quantity;
            Double.TryParse(txtQuantity.Text, out quantity);
            double value = price * quantity;
            txtCost.Text = string.Format("{0:C}", value);


        }


    }
}