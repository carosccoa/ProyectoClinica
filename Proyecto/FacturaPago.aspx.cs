using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.Dao;
using Proyecto.Entidades;

namespace Proyecto
{
    public partial class FacturaPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string n;


                n = Convert.ToString(Session["id"]);

                Response.Write(n);

                txtDato.Text = n;

                ListarDatosPaciente();

            }

        }


        protected void ListarDatosPaciente()
        {


            EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            if (txtDato.Text != null)
            {
                rsd.usuario = txtDato.Text;
                dt = dao.ListadoFacturaPaciente(rsd);

                if (dt.Rows.Count > 0)
                {
                    txtPaciente.Text = dt.Rows[0]["Paciente"].ToString();



                };
            }
        }
    }
}

