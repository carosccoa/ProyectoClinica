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
    public partial class AdministraHospitalización : System.Web.UI.Page
    {
        private void listarGrilla()
        {

            DaoHospitalizacionAdministrador dao = new DaoHospitalizacionAdministrador();
            DataTable dt = new DataTable();
            dt = dao.listar();
            gvSalida.DataSource = dt;
            gvSalida.DataBind();

        }

        protected void lkbModificar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;

            txtCodigo.Text = row.Cells[0].Text;
            txtPaciente.Text = row.Cells[1].Text;
            txtEnfermero.Text = row.Cells[2].Text;
            txtPabellon.Text = row.Cells[3].Text;
            txtHabitacion.Text = row.Cells[4].Text;
            txtEspe.Text = row.Cells[5].Text;
            txtAreaM.Text = row.Cells[6].Text;

        }

        private void listarPabellon()
        {

            DataTable dt = new DataTable();
            DaoHospitalizacionAdministrador dr = new DaoHospitalizacionAdministrador();
            dt = dr.listarPabellonAdministrador();
            cboPabellon.DataSource = dt;
            cboPabellon.DataTextField = "pabellonHabitacion";
            cboPabellon.DataBind();
            cboPabellon.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        private void listarHabitacion()
        {
            EntidadHospitalizacionAdministrador erh = new EntidadHospitalizacionAdministrador();
            DaoHospitalizacionAdministrador dr = new DaoHospitalizacionAdministrador();
            DataTable dt = new DataTable();
            dt = dr.listarHabitacion(erh);
            cboNumHabitacion.DataSource = dt;
            cboNumHabitacion.DataTextField = "numeroHabitacion";
            cboNumHabitacion.DataValueField = "idHabitacion";
            cboNumHabitacion.DataBind();
            cboNumHabitacion.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        private void listarHabitacionDisponible()
        {
            EntidadHospitalizacionAdministrador erh = new EntidadHospitalizacionAdministrador();
            DaoHospitalizacionAdministrador dr = new DaoHospitalizacionAdministrador();
            DataTable dt = new DataTable();
            erh.pabellon = cboPabellon.Text;
            dt = dr.listarHabitacionDisponible(erh);
            cboNumHabitacion.DataSource = dt;
            cboNumHabitacion.DataTextField = "numeroHabitacion";
            cboNumHabitacion.DataValueField = "idHabitacion";
            cboNumHabitacion.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                TablaListado.Visible = true;
                ActualizarVisible.Visible = false;
                listarHabitacion();
                listarPabellon();
                listarGrilla();
            }


        }

        protected void seleccionPabellon(object sender, EventArgs e)
        {
            listarHabitacionDisponible();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/AdministraHospitalización.aspx");
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;
            modificarhabitacion();
        }




        private void modificarhabitacion()
        {
            if (cboPabellon.SelectedValue == "0" || cboNumHabitacion.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "SeleccionePabellon()", true);

                TablaListado.Visible = false;
                ActualizarVisible.Visible = true;
            }
            else if (txtEnfermero.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "IngreseDatosEnfermero()", true);

                TablaListado.Visible = false;
                ActualizarVisible.Visible = true;
            }
            else
            {


                int est = 0;
                if (txtEstadoOcupado.Text == "Ocupado")
                {
                    est = 2;
                };


                EntidadHospitalizacionAdministrador obj = new EntidadHospitalizacionAdministrador();
                DaoHospitalizacionAdministrador dao = new DaoHospitalizacionAdministrador();

                obj.idHospitalizacion = int.Parse(txtCodigo.Text);
                obj.Enfermero = txtEnfermero.Text;
                obj.habitaciondis = txtHabitacion.Text;
                obj.idHabitacion = int.Parse(cboNumHabitacion.SelectedValue);
                obj.estadoHabitacion = est;

                int i = dao.modificarHabitacion(obj);


                if (i > 0)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "confirmacionA()", true);

                };
            }

        }




    }
}

