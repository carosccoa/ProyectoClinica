using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.Entidades;
using Proyecto.Dao;
namespace Proyecto
{
    public partial class ConsultarHospAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cboBusqueda.Items.Add("DNI");
                cboBusqueda.Items.Add("PACIENTE");
                cboBusqueda.Items.Add("MEDICO");
                cboBusqueda.Items.Add("NUM. HABITACION");
                indexHospitalizacion();
            }
        }
        private void indexHospitalizacion()
        {
            DaoConsultas dao = new DaoConsultas();
            DataTable dt = new DataTable();
            dt = dao.indexHospitalizacion();
            gvResultado.DataSource = dt;
            gvResultado.DataBind();
        }
        private void buscar()
        {
            EntidadConsulta ech = new EntidadConsulta();
            DaoConsultas dao = new DaoConsultas();
            if (cboBusqueda.Text == "DNI")
            {
                ech.DNIPaciente = txtDNI.Text;
                if (txtDNI.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            else if (cboBusqueda.Text == "MEDICO")
            {
                ech.medico = txtMedico.Text;
                if (txtMedico.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            else if (cboBusqueda.Text == "PACIENTE")
            {
                ech.paciente = txtPaciente.Text;
                if (txtPaciente.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            else if (cboBusqueda.Text == "NUM. HABITACION")
            {
                ech.numeroHabitacion = txtHabitacion.Text;
                if (txtHabitacion.Text == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            DataTable dt = new DataTable();
            dt = dao.consultaHospitalizacion(ech);
            if (dt.Rows.Count != 0)
            {
                //MOSTRAR DATO EN GRILLA
                gvResultado.DataSource = dt;
                gvResultado.DataBind();
            }
            else
            {
                txtDNI.Text = string.Empty;
                ClientScript.RegisterStartupScript(this.GetType(), "Hi4", "NoResultados()", true);

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            buscar();
        }
        public void desactivador()
        {
            txtDNI.Visible = false;
            txtHabitacion.Visible = false;
            txtMedico.Visible = false;
            txtPaciente.Visible = false;
        }

        protected void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBusqueda.Text == "DNI")
            {
                desactivador();
                txtDNI.Visible = true;
            }
            else if (cboBusqueda.Text == "MEDICO")
            {
                desactivador();
                txtMedico.Visible = true;
            }
            else if (cboBusqueda.Text == "PACIENTE")
            {
                desactivador();
                txtPaciente.Visible = true;
            }
            else if (cboBusqueda.Text == "NUM. HABITACION")
            {
                desactivador();
                txtHabitacion.Visible = true;
            }
        }

    }

}

