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
    public partial class Shopping : System.Web.UI.Page
    {
        double tax = .055;
        double price;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            string Output = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "Select Role from Users where UserName = '" + Session["Prog5_User"] + "'";

            SqlCommand com = new SqlCommand(insertQuery, conn);

            //com.ExecuteNonQuery();
            SqlDataReader item = com.ExecuteReader();
            while (item.Read())
            {
                Output = item.GetValue(0).ToString();
            }
            conn.Close();
            if (!Output.Contains("Member"))
                Response.Redirect("Default.aspx");
        }

        protected void btnCompute_Click(object sender, EventArgs e)
        {
            if (btnCompute.Text == "Clear")
            {
                txtPrice.ReadOnly = false;
                txtQuantity.ReadOnly = false;
                txtOrderID.ReadOnly = false;
                Session["Prog2_ProductID"] = "";
                Session["Prog2_ProductPrice"] = "";
                Session["Prog2_ProductQuantity"] = "";
                Session["Prog2_Computed"] = false;
                txtOrderID.Text = (string)Session["Prog2_ProductID"];
                txtQuantity.Text = (string)Session["Prog2_ProductQuantity"];
                txtPrice.Text = (string)Session["Prog2_ProductPrice"];
                CalculateTotals();
                txtOrderID.Focus();
                btnCompute.Text = "Compute";
            }
            else
            {
                for (int i = 0; i < SQLDataClass.tblProduct.Rows.Count; i++)
                {
                    System.Data.DataRow row
                    = SQLDataClass.tblProduct.Rows[i];
                    string temp = row[0].ToString();
                    if (txtOrderID.Text.Equals(temp))
                    {
                        txtName.Text = row[1].ToString();
                        txtPrice.Text = string.Format("{0:C}", row[2]);
                        Double.TryParse(row[2].ToString(), out price);
                    }
                }
                Session["Prog2_ProductPrice"] = txtPrice.Text;
                Session["Prog2_ProductQuantity"] = txtQuantity.Text;
                Session["Prog2_ProductID"] = txtOrderID.Text;
                Session["Prog2_Computed"] = true;
                txtPrice.ReadOnly = true;
                txtQuantity.ReadOnly = true;
                txtOrderID.ReadOnly = true;
                CalculateTotals();
                btnCompute.Text = "Clear";
            }
            
             
        }

        protected void CalculateTotals()
        {
            
            
            double quantity;
            Double.TryParse(txtQuantity.Text, out quantity);
            double value = price * quantity;
            double orderTax = value * tax;
            double grandTotal = value + orderTax;
            txtSub.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            txtTax.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", orderTax);
            txtGrand.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", grandTotal);
        }
        protected void text_changed(object sender, EventArgs e)
        {
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string temp = Session["Prog5_User"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "insert into ShopingBag (ProductID, ProductName, UnitPrice, Quantity, Cost, Customer) values (@keyID, @Pname, @PPrice, @PQuantity, @PCost, @PCust)";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@keyID", txtOrderID.Text);
            com.Parameters.AddWithValue("@Pname", txtName.Text);
            com.Parameters.AddWithValue("@PPrice", txtPrice.Text);
            com.Parameters.AddWithValue("@PQuantity", txtQuantity.Text);
            com.Parameters.AddWithValue("@PCost", txtSub.Text);
            com.Parameters.AddWithValue("@PCust", temp);
            com.ExecuteNonQuery();
            Response.Redirect("Shopping.aspx");

            conn.Close();
        }
    }
}