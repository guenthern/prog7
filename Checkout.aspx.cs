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
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "select * from ShopingBag";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            GridView1.DataSource = com.ExecuteReader();
            GridView1.DataBind();
            conn.Close();
            string Output = "";
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery2 = "Select Role from Users where UserName = '" + Session["Prog5_User"] + "'";

            SqlCommand com2 = new SqlCommand(insertQuery2, conn);

            //com.ExecuteNonQuery();
            SqlDataReader item = com2.ExecuteReader();
            while (item.Read())
            {
                Output = item.GetValue(0).ToString();
            }
            conn.Close();
            if (!Output.Contains("Member"))
                Response.Redirect("Default.aspx");
            double cost = 0;
            string temp = "";
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery3 = "Select Cost from ShopingBag where Customer = '" + Session["Prog5_User"] + "'";

            SqlCommand com3 = new SqlCommand(insertQuery3, conn);

            //com.ExecuteNonQuery();
            SqlDataReader item2 = com3.ExecuteReader();
            while (item2.Read())
            {
                temp = item2.GetValue(0).ToString();
                cost += Double.Parse(temp);
            }
            txtTotal.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", cost);
            conn.Close();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UWPCS3870ConnectionString1"].ConnectionString);
            conn.Open();
            string insertQuery = "Delete from ShopingBag where Customer = @keyID";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@keyID", Session["Prog5_User"]);
            com.ExecuteNonQuery();
            conn.Close();
            Session["Prog3_Index"] = 0;
            Session["Prog3_ID"] = "";
            Session["Prog2_ProductID"] = "";
            Session["Prog2_ProductPrice"] = "";
            Session["Prog2_ProductQuantity"] = "";
            Session["Prog2_Computed"] = false;
            Session["Prog5_User"] = "";
            //Response.Redirect("Login.aspx");
        }
    }
}