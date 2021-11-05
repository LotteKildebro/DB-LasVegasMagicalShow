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
    public partial class ActCRUD : System.Web.UI.Page

    {
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-FIN5MUC; integrated security = true; database = magicshow");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        //title, magician_fk, description, duration, picture
        string sqlsel = "INSERT INTO act VALUES (@title, @magician_fk, @description, @duration, @picture)";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Make our button un-clickable till we have selected a company from the gridview
                Button_Update.Enabled = false;
                UpdateGridView();
            }
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
            }

            catch (Exception ex)
            {
                Label_Message.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_title1.Text == "")
                {
                    Label_msg.Text = "Enter a title";
                }

                else if (TextBox_magician_fk1.Text == "")
                {
                    Label_msg.Text = "Enter your id number";
                }
                else if (TextBox_description1.Text == "")
                {
                    Label_msg.Text = "Enter description";
                }
                else if (TextBox_duration1.Text == "")
                {
                    Label_msg.Text = "Enter duration";
                }
                else if (TextBox_picture1.Text == "")
                {
                    Label_msg.Text = "enter name of picture";
                }
                else
                {
                    conn.Open();

                    sqlsel = "UPDATE act SET title = @title, magician_fk = @magician_fk, description = @description, duration = @duration, picture = @picture  WHERE id_act = @id_act";

                    cmd = new SqlCommand(sqlsel, conn);

                    //  GridView_Shippers.SelectedRow.Cells[1].Text == We take the row we select and get that id as string that we convert to int
                    cmd.Parameters.Add("@id_act", SqlDbType.Int).Value = Convert.ToInt32(GridView_Shippers.SelectedRow.Cells[1].Text);
                    cmd.Parameters.Add("@title", SqlDbType.Text).Value = TextBox_title1.Text;
                    cmd.Parameters.Add("@magician_fk", SqlDbType.Int).Value = TextBox_magician_fk1.Text;
                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = TextBox_description1.Text;
                    cmd.Parameters.Add("@duration", SqlDbType.Time).Value = TextBox_duration1.Text;
                    cmd.Parameters.Add("@picture", SqlDbType.Text).Value = TextBox_picture1.Text; 
                    

                    cmd.ExecuteNonQuery();

                    TextBox_title1.Text = "";
                    TextBox_magician_fk1.Text = "";
                    TextBox_description1.Text = "";
                    TextBox_duration1.Text = "";
                    TextBox_picture1.Text = "";
                    Label_Message.Text = "Company Updated";
                    Response.Redirect("ActCRUD.aspx");
                }
            }

            catch (Exception ex)
            {
                Label_Message.Text = ex.ToString();
            }

            finally
            {
                conn.Close();
            }

            UpdateGridView();
        }

        protected void GridView_Shippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_Update.Enabled = true;

            TextBox_title1.Text = GridView_Shippers.SelectedRow.Cells[2].Text;
            TextBox_magician_fk1.Text = GridView_Shippers.SelectedRow.Cells[3].Text;
            TextBox_description1.Text = GridView_Shippers.SelectedRow.Cells[4].Text;
            TextBox_duration1.Text = GridView_Shippers.SelectedRow.Cells[5].Text;
            TextBox_picture1.Text = GridView_Shippers.SelectedRow.Cells[6].Text;


            Label_Message.Text = "You have chosen id_act " + GridView_Shippers.SelectedRow.Cells[1].Text;
        }

       

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void Button_Create_Click(object sender, EventArgs e)
        {//title, magician_fk, description, duration, picture
            try
            {
                if (TextBox_title.Text == "")
                {
                    Label_msg.Text = "Enter a company name";
                }

                else if (TextBox_magician_fk.Text == "")
                {
                    Label_msg.Text = "Enter your id number";
                }
                else if (TextBox_description.Text == "")
                {
                    Label_msg.Text = "Enter description";
                }
                else if (TextBox_duration.Text == "")
                {
                    Label_msg.Text = "Enter duration";
                }
                else if (TextBox_picture.Text == "")
                {
                    Label_msg.Text = "enter name of picture";
                }

                else
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlsel, conn);
                    //title, magician_fk, description, duration, picture
                    cmd.Parameters.Add("@title", SqlDbType.Text).Value = TextBox_title.Text;
                    cmd.Parameters.Add("@magician_fk", SqlDbType.Int).Value = TextBox_magician_fk.Text;
                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = TextBox_description.Text;
                    cmd.Parameters.Add("@duration", SqlDbType.Time).Value = TextBox_duration.Text;
                    cmd.Parameters.Add("@picture", SqlDbType.Text).Value = TextBox_picture.Text;

                    cmd.ExecuteNonQuery();

                    TextBox_title.Text = "";
                    TextBox_magician_fk.Text = "";
                    TextBox_description.Text = "";
                    TextBox_duration.Text = "";
                    TextBox_picture.Text = "";
                    Label_msg.Text = "act Added";
                    Response.Redirect("ActCRUD.aspx");
                }
            }

            catch (Exception ex)
            {
                Label_msg.Text = ex.ToString();
            }

            finally
            {
                conn.Close();
            }
        }


    }
}