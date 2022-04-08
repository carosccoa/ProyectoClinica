using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.Dao;
using Proyecto.Entidades;
using System.Data;

namespace Proyecto
{
    public partial class ConsultarCitaAdministrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cboTipo.Items.Add("DNI");
                cboTipo.Items.Add("ESTADO");
                cboTipo.Items.Add("AREA");
                cboTipo.Items.Add("ESPECIALIDAD");
                llenarEspecialidad();
                listarArea();
                listarEstado();
                cargaTabla();
            }
        }
        public void listarArea()
        {
            DaoConsultaCita dao = new DaoConsultaCita();
            DataSet ds = new DataSet();
            ds = dao.cargarArea();
            this.cboArea.DataSource = ds;
            this.cboArea.DataValueField = "idAreaMedica";
            this.cboArea.DataTextField = "areaMedica";
            this.cboArea.DataBind();
            this.cboArea.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void listarEstado()
        {
            DaoConsultas dao = new DaoConsultas();
            DataSet ds = new DataSet();
            ds = dao.listarEstado();
            this.cboEstado.DataSource = ds;
            this.cboEstado.DataValueField = "idEstadoCita";
            this.cboEstado.DataTextField = "estado";
            this.cboEstado.DataBind();
            this.cboEstado.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void llenarEspecialidad()
        {
            DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
            DataTable dt = new DataTable();
            dt = dao.listarEspecialidad();
            cboEspecialidad.DataSource = dt;
            cboEspecialidad.DataTextField = "especialidad";
            cboEspecialidad.DataValueField = "idEspecialidad";
            cboEspecialidad.DataBind();
            cboEspecialidad.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void desactivadorCBO()
        {
            cboArea.Visible = false;
            cboEspecialidad.Visible = false;
            cboEstado.Visible = false;
            txtDato.Visible = false;
        }
        public void cargaTabla()
        {
            DaoConsultas dao = new DaoConsultas();
            DataTable dt = new DataTable();
            dt = dao.indexCita();
            gvSalida.DataSource = dt;
            gvSalida.DataBind();
        }
        public void buscarCitaMed()
        {
            EntidadConsulta ci = new EntidadConsulta();
            DaoConsultas dao = new DaoConsultas();
            ci.DNIPaciente = txtDato.Text.Trim();

            string tipo = cboTipo.Text.Trim();
            if (tipo == "DNI")
            {
                ci.DNIPaciente = txtDato.Text;
            }
            else if (tipo == "ESTADO")
            {
                if (cboEstado.SelectedValue != "0")
                {
                    ci.estado = cboEstado.SelectedItem.ToString();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            else if (tipo == "AREA")
            {
                if (cboArea.SelectedValue != "0")
                {
                    ci.areaMedica = cboArea.SelectedItem.ToString();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            else if (tipo == "ESPECIALIDAD")
            {
                if (cboEspecialidad.SelectedValue != "0")
                {
                    ci.especialidad = cboEspecialidad.SelectedItem.ToString();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                    return;
                }
            }
            DataTable dt = new DataTable();
            dt = dao.consultaCitaMed(ci);
            if (dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi3", "NoResultados()", true);
                txtDato.Text = string.Empty;
                cboEspecialidad.SelectedValue = "0";
                cboEstado.SelectedValue = "0";
                cboArea.SelectedValue = "0";
                cargaTabla();
                return;
            }
            //MOSTRAR DATO EN GRILLA
            gvSalida.DataSource = dt;
            gvSalida.DataBind();
            txtDato.Text = string.Empty;
            txtDato.Focus();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarCitaMed();
        }

        protected void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text == "DNI")
            {
                desactivadorCBO();
                txtDato.Visible = true;
            }
            else if (cboTipo.Text == "ESTADO")
            {
                desactivadorCBO();
                cboEstado.Visible = true;
            }
            else if (cboTipo.Text == "AREA")
            {
                desactivadorCBO();
                cboArea.Visible = true;
            }
            else if (cboTipo.Text == "ESPECIALIDAD")
            {
                desactivadorCBO();
                cboEspecialidad.Visible = true;
            }
        }
    }
}

