using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace DB_Lasvegasmagicalshow
{
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();

        string name_magician, magician_id, magician_type;

        public string conString = "Data Source=DESKTOP-FIN5MUC;Initial Catalog=magicshow;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id_magician"] == null)
            {
                
                Button3.Visible = true; //login btn
                Button5.Visible = false; //logout btn

                Button2.Visible = false; //Hello user button message
                Button4.Visible = false; //Edit acts, Magicians
                Button6.Visible = false; //Edit magicians, Secretary
                Button7.Visible = false; //Edit Program, Manager
            }
            else {
            if (Session["type_magician"].ToString() == "magician")
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
        }
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if(con.State == ConnectionState.Closed){
                    con.Open();
                }

                /*variables for textbox, Use trim(); to cut empty spaces*/
                string Name = TextBoxName.Text.Trim();
                string Password = TextBoxPassword.Text.Trim();
                /*Password = CeasarEncryption.Encrypt(Password);*/

                
                SqlCommand cmd = new SqlCommand("SELECT * FROM magician WHERE name_magician='" + Name +
                                                "' AND password= '" + Password + "'", con);
            
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows){

                    while(dr.Read()){


                        /* Response.Write("<script>alert('Welcome "+dr.GetValue(1).ToString()+"');</script>");*/
                        /*storing values in session*/
                        /* Session["name_magician"] = dr.GetValue(1).ToString();
                         Session["magician_type"] = dr.GetValue(6).ToString();*/
                        magician_id = dr["id_magician"].ToString();
                        magician_type = dr["type_magician"].ToString();
                        name_magician = dr["name_magician"].ToString();

                        Session["id_magician"] = magician_id;
                        Session["type_magician"] = magician_type;
                        Session["name_magician"] = name_magician;



                        /* https:// www. youtube.com/watch?v=5bsBiTRu010 */
                        Response.Redirect("Home.aspx");
                    }

                }
                else{
                    Response.Write("<script>alert('invalid user');</script>");
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('"+ ex.Message +" ');", true);
            }

            /*Alert for testing*/
            /* Response.Write("<script>alert('Works');</script>");*/
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
    }
}