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
    public partial class HistoriaClinicaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string n;


                n = Convert.ToString(Session["id"]);

                txtDato.Text = n;
                ConseguirHistorialClinico();
                listarEspecialidad();
                TablaListado.Visible = true;
                ActualizarVisible.Visible = false;

            }
        }

        private void listarEspecialidad()
        {
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listarEspecialidadPaciente();
            cboFiltro.DataSource = dt;
            cboFiltro.DataTextField = "especialidad";
            cboFiltro.DataValueField = "idEspecialidad";
            cboFiltro.DataBind();
            cboFiltro.Items.Insert(0, new ListItem("Seleccione", "0"));

        }


        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (cboFiltro.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatosFiltro()", true);
            }
            else
            {
                EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
                DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
                DataTable dt = new DataTable();
                if (txtDato.Text != null)
                {
                    rsd.usuario = txtDato.Text;
                    rsd.idEspecialidad = int.Parse(cboFiltro.Text);
                    dt = dao.listarFiltroEspecialidad(rsd);
                    if (dt.Rows.Count > 0)
                    {
                        gvSalida.DataSource = dt;
                        gvSalida.DataBind();
                    }


                }
            }


        }
        protected void btnFiltroCompleto_Click(object sender, EventArgs e)
        {
            ConseguirHistorialClinico();
        }



        protected void ConseguirHistorialClinico()
        {

            EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            if (txtDato.Text != null)
            {
                rsd.usuario = txtDato.Text;
                dt = dao.ListarHistorialPaciente(rsd);
                if (dt.Rows.Count > 0)
                {
                    gvSalida.DataSource = dt;
                    gvSalida.DataBind();
                };

            }
        }

        protected void RealizarPago_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;
            txtDignostico.Text = row.Cells[0].Text;
            txtMedicacion.Text = row.Cells[1].Text;
            txtMedico.Text = row.Cells[2].Text;
            txtEspecialidad.Text = row.Cells[3].Text;
            txtFecha.Text = row.Cells[4].Text;

        }
    }
}

