using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.Entidades;
using Proyecto.Dao;
using System.Data;

namespace Proyecto
{
    public partial class ConsultarCitaPaciente : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            if (txtDato.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                EntidadCitaPaciente rsd = new EntidadCitaPaciente();
                DaoCitaPaciente dao = new DaoCitaPaciente();
                DataTable dt = new DataTable();
                if (txtDato.Text != null)
                {
                    rsd.DNIPaciente = txtDato.Text;
                    dt = dao.consultadniCita(rsd);
                    if (dt.Rows.Count > 0)
                    {
                        gvSalida.DataSource = dt;
                        gvSalida.DataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "NohayDatos()", true);
                        btnBuscar.Visible = true;
                    }
                }
            }
        }



        protected void gvSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

            if (txtFechaIni.Text == "" && txtFechaFinal.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "SeleccioneFecha()", true);
            }
            else
            {
                EntidadCitaPaciente rsd = new EntidadCitaPaciente();
                DaoCitaPaciente dao = new DaoCitaPaciente();
                DataTable dt = new DataTable();
                if (txtDato.Text != null)
                {
                    rsd.DNIPaciente = txtDato.Text.Trim();
                    rsd.fecha = txtFechaIni.Text.Trim();
                    rsd.fechaRef = txtFechaFinal.Text.Trim();
                    dt = dao.ConsultarFiltroCita(rsd);
                    if (dt.Rows.Count > 0)
                    {
                        gvSalida.DataSource = dt;
                        gvSalida.DataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "NoFiltro()", true);

                    }
                }
            }
        }
    }

}