using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSesion_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select idRolUsuario from Usuario where nombreUsuario='" + txtUsuario.Text + "'and paswordUsuario='" + txtContraseña.Text + "'", conex);
            conex.Open();
            String n = Convert.ToString(cmd.ExecuteScalar());

            SqlDataReader dr = cmd.ExecuteReader();




            if (dr.Read())
            {


                Session["id"] = txtUsuario.Text;

                if (n == "3")
                {

                    Response.Redirect("HomeAdministrador.aspx");
                }
                if (n == "2")
                {

                    Response.Redirect("HomeMedico.aspx");
                }
                if (n == "1")
                {

                    Response.Redirect("HomePaciente.aspx");
                }

      

            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(),"Hi", "datosErroneos()", true);
                txtContraseña.Text = "";
                txtUsuario.Text = "";


            }


        }


    }
}