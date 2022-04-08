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
    public partial class ConsultarHisMedAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cboBusqueda.Items.Add("DNI");
                cboBusqueda.Items.Add("PACIENTE");
                indexHisMed();
            }
        }
        private void indexHisMed()
        {
            DaoConsultas dao = new DaoConsultas();
            DataTable dt = new DataTable();
            dt = dao.indexHisMedico();
            gvResultado.DataSource = dt;
            gvResultado.DataBind();
        }
        private void buscar()
        {
            EntidadConsulta echm = new EntidadConsulta();
            DaoConsultas dao = new DaoConsultas();
            if (cboBusqueda.Text == "DNI")
            {
                if (txtDato.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
                echm.DNIPaciente = txtDato.Text;
            }
            else if (cboBusqueda.Text == "PACIENTE")
            {
                if (txtNombre.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
                echm.paciente = txtNombre.Text;
            }
            DataTable dt = new DataTable();
            dt = dao.conHisMedtaHospitalizacion(echm);
            if (dt.Rows.Count != 0)
            {
                //MOSTRAR DATO EN GRILLA
                gvResultado.DataSource = dt;
                gvResultado.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi4", "NoResultados()", true);
                txtDato.Text = string.Empty;
                txtNombre.Text = string.Empty;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "DNI")
            {
                txtNombre.Visible = false;
                txtDato.Visible = true;
            }
            else if (cboBusqueda.Text == "PACIENTE")
            {
                txtNombre.Visible = true;
                txtDato.Visible = false;
            }
        }
    }
}

