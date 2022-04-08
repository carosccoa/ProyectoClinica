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
    public partial class ConsultarDisHabAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarDatos();
                indexDisHab();
            }
        }
        public void indexDisHab()
        {
            DaoConsultas dao = new DaoConsultas();
            DataTable dt = new DataTable();
            dt = dao.indexDisHab();
            gvSalidah.DataSource = dt;
            gvSalidah.DataBind();
        }
        public void buscarh()
        {
            EntidadConsulta ch = new EntidadConsulta();
            DaoConsultas dao = new DaoConsultas();
            ch.especialidad = cboEspecialidad.SelectedItem.Text;

            DataTable dt = new DataTable();
            dt = dao.consultaHabitacion(ch);
            if (cboEspecialidad.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi3", "NoResultados()", true);
                return;
            }
            //MOSTRAR DATO EN GRILLA
            gvSalidah.DataSource = dt;
            gvSalidah.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarh();
        }

        private void cargarDatos()
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

        protected void btnListar_Click(object sender, EventArgs e)
        {
            indexDisHab();
        }
    }
}

