using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DB_Lasvegasmagicalshow
{
   
    public partial class Home1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public string conString = "Data Source=DESKTOP-FIN5MUC;Initial Catalog=magicshow;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id_magician"] == null)
            {
                
                Button3.Visible = true; //login btn
                Button5.Visible = false; //logout btn

                Button2.Visible = false; //Hello user button message
                Button4.Visible = false; //Edit acts, Magicians
                Button6.Visible = false; //Edit magicians, Secretary
                Button7.Visible = false; //Edit Program, Manager
            } else 
            { 
         
                if(Session["type_magician"].ToString() == "magician")
                {
                    Button3.Visible = false; //login btn
                    Button5.Visible = true; //logout btn

                    Button2.Visible = true; //Hello user button message
                    Button2.Text = "Hello " + Session["name_magician"].ToString();

                    Button4.Visible = true; //Edit acts, Magicians
                    Button6.Visible = false; //Edit magicians, Secretary
                    Button7.Visible = false; //Edit Program, Manager
                }

                if (Session["type_magician"].ToString() == "secretary")
                {
                    Button3.Visible = false; //login btn
                    Button5.Visible = true; //logout btn

                    Button2.Visible = true; //Hello user button message
                    Button2.Text = "Hello " + Session["name_magician"].ToString();

                    Button4.Visible = false; //Edit acts, Magicians
                    Button6.Visible = true; //Edit magicians, Secretary
                    Button7.Visible = false; //Edit Program, Manager
                }

                if (Session["type_magician"].ToString() == "manager")
                {
                    Button3.Visible = false; //login btn
                    Button5.Visible = true; //logout btn

                    Button2.Visible = true; //Hello user button message
                    Button2.Text = "Hello " + Session["name_magician"].ToString();

                    Button4.Visible = false; //Edit acts, Magicians
                    Button6.Visible = false; //Edit magicians, Secretary
                    Button7.Visible = true; //Edit Program, Manager
                }
            }
            /* if(Session["magician_id"].Equals("user"))
            {
                Button3.Visible = false; //login btn
                Button5.Visible = true; //logout btn

                Button2.Visible = true; //Hello user button message
                Button2.Text = "Hello " + Session["magician_name"].ToString();

                Button4.Visible = true; //Edit acts, Magicians
                Button6.Visible = false; //Edit magicians, Secretary
                Button7.Visible = false; //Edit Program, Manager
            }*/



            SqlConnection con = new SqlConnection(conString);

            con.Open();
            ds = new DataSet();
            cmd.CommandText = "SELECT title, artist_name, description, sequence, duration FROM act " +
                                    "INNER JOIN program ON act.id_act = program.act_fk " +
                                    "INNER JOIN magician ON act.magician_fk = magician.id_magician " +
                            "ORDER BY id_program ASC";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //Home btn
            Response.Redirect("Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Hello user
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Edit Acts
            Response.Redirect("ActCRUD.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Logout
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("home.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Edit Magicians
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //Edit Program
        }

        protected void button1Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}