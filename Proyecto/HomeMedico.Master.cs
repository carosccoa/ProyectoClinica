﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace Proyecto
{
    public partial class HomeMedico : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string n;
                n = Convert.ToString(Session["id"]);
                SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

                SqlCommand cmd = new SqlCommand("select p.nombreMedico from Usuario u inner join Medico p on p.DNIMedico = u.DNIUsuario where u.nombreUsuario='" + n + "'", conex);
                conex.Open();

                String nn = Convert.ToString(cmd.ExecuteScalar());

                SqlDataReader dr = cmd.ExecuteReader();


                Label1.Text = nn;

            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
    }
}