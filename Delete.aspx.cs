using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Lasvegasmagicalshow
{
    public partial class Delete : System.Web.UI.Page
    {
        // SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = northwind");
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-FIN5MUC; integrated security = true; database = magicshow");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button_Delete.Enabled = false;
                UpdateGridView();
            }

            // As default the dropownlist will not display data unless the page refresh, so we use autopostback to get the data
            DropDownList_act.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            try
            {
                conn.Open();

                sqlsel = "select * from  act";

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();

                GridView_Shippers.DataSource = rdr;
                GridView_Shippers.DataBind();

                // Getting our data again (because reader is empty after we bind it to the gridview - only readable one time)
                // So we get our data again and put it into our dropdownlist
                rdr.Close();
                rdr = cmd.ExecuteReader();

                DropDownList_act.DataSource = rdr;

                // We want to display the company name (DataTextField = The data to display)
                DropDownList_act.DataTextField = "title";

                // But the data we select is the ID when we click (DataValueField = The data to save when clicked)
                DropDownList_act.DataValueField = "id_act";

                DropDownList_act.DataBind();

                // Default value for our dropdownlist
                DropDownList_act.Items.Insert(0, "Select act");
            }

            catch (Exception ex)
            {
                Label_Msg.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void DropDownList_act_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the selected value is NOT "Select a Shipper"
            if (DropDownList_act.SelectedIndex != 0)
            {
                Label_Msg.Text = "You have chosen Shipper (ID): " + DropDownList_act.SelectedValue;
                Button_Delete.Enabled = true;
            }

            else
            {
                Label_Msg.Text = "You have chosen none";
                Button_Delete.Enabled = false;
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                sqlsel = "DELETE FROM act WHERE id_act = @id_act";

                cmd = new SqlCommand(sqlsel, conn);

                cmd.Parameters.Add("@id_act", SqlDbType.Int).Value = Convert.ToInt32(DropDownList_act.SelectedValue);

                cmd.ExecuteNonQuery();

                Label_Msg.Text = "Deleted: " + DropDownList_act.SelectedItem.Text + " (ID: " + DropDownList_act.SelectedValue + ")";
            }

            catch (Exception ex)
            {
                Label_Msg.Text = ex.ToString();
            }

            finally
            {
                conn.Close();
            }

            Button_Delete.Enabled = false;
            UpdateGridView();
        }
    }
}