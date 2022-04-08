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
    public partial class AdministraCitaAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listarGrilla();
            ActualizarVisible.Visible = false;
        }

        private void listarGrilla()
        {

            DaoCitaPaciente dao = new DaoCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listar();
            gvProductos.DataSource = dt;
            gvProductos.DataBind();

        }

        private void ComboModf()
        {
            DaoEstadoCitaPaciente dao = new DaoEstadoCitaPaciente();
            DataTable dt = new DataTable();

            dt = dao.listar();

            int ica;
            string nm;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nm = dt.Rows[i]["estado"].ToString();

                if (txtEstado.Text == nm)
                {
                    ica = int.Parse(dt.Rows[i]["idEstadoCita"].ToString());
                    cboEstado.SelectedIndex = ica;/*
                    lblCategoriaPrueba.Text = "ID: " + ica + " Categoria: " + nm;*/
                }

            }
        }

        protected void lkbModificar_Click(object sender, EventArgs e)
        {
            DatosEstado();

            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;
            txtCodigo.Text = row.Cells[0].Text;
            txtDni.Text = row.Cells[1].Text;
            txtNombre.Text = row.Cells[2].Text;
            if (row.Cells[3].Text == "MA&#209;ANA")
            {
                txtTurno.Text = "MAÑANA";
            }
            else
            {
                txtTurno.Text = row.Cells[3].Text;
            }
            txtEstado.Text = row.Cells[4].Text;
            txtFecha.Text = row.Cells[5].Text;
            ComboModf();
        }

        private void DatosEstado()
        {
            DaoEstadoCitaPaciente dao = new DaoEstadoCitaPaciente();
            DataTable dt = new DataTable(); ;
            dt = dao.listar();

            cboEstado.DataSource = dt;
            cboEstado.DataTextField = "estado";
            cboEstado.DataValueField = "idEstadoCita";
            cboEstado.DataBind();
            cboEstado.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void ValidacionDatoVacio()
        {
            if (cboEstado.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "SeleccioneValor()", true);

                TablaListado.Visible = false;
                ActualizarVisible.Visible = true;
            }
            else
            {

                DaoCitaPaciente dao = new DaoCitaPaciente();
                EntidadCitaPaciente objC = new EntidadCitaPaciente();
                objC.idCita = int.Parse(txtCodigo.Text);
                objC.idEstado = cboEstado.SelectedValue;
                int i = dao.modificarEstado(objC);

                TablaListado.Visible = false;
                ActualizarVisible.Visible = true;

                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "confirmacion()", true);


                };
            }

        }




        protected void btnCancelar_Click(object sender, EventArgs e)
        {


            Response.Redirect("~/AdministraCitaAdministrador.aspx");



        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {


            ValidacionDatoVacio();



        }

    }
}