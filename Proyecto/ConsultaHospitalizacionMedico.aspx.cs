using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Proyecto.Dao;
using Proyecto.Entidades;

namespace Proyecto
{
    public partial class ConsultaHospitalizacionMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["id"] != null)
                {
                    string n;
                    n = Convert.ToString(Session["id"]);
                    lblMedicoFijo.Text = n;
                }

                ListItem i;
                i = new ListItem("Seleccione...", "0");
                cboPrueba.Items.Add(i);
                i = new ListItem("DNI Paciente", "1");
                cboPrueba.Items.Add(i);
                i = new ListItem("Pabellon", "2");
                cboPrueba.Items.Add(i);
                i = new ListItem("Habitacion", "3");
                cboPrueba.Items.Add(i);
                i = new ListItem("Fecha Ingreso", "4");
                cboPrueba.Items.Add(i);

                cboPabellon.Items.Add("Elija una opción..");
                cboPabellon.Items.Add("A");
                cboPabellon.Items.Add("B");
                cboPabellon.Items.Add("C");

                /* Llamado de funciones */
                listarGrilla();
            }
        }

        private void listarGrilla()
        {
            if (lblMedicoFijo != null)
            {
                EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();
                DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                DataTable dt = new DataTable();

                objHospitalizacion.nombreUsuario = lblMedicoFijo.Text;
                dt = dao.listadoHospitalizacion(objHospitalizacion);

                /* Mostrar registro en una grilla */
                gvListaHospitalizacion.DataSource = dt;
                gvListaHospitalizacion.DataBind();
            }
        }

        private void noVisible()
        {
            /* DNI paciente */
            txtDniPaciente.Visible = false;
            btnDniPaciente.Visible = false;
            /* Pabellon */
            cboPabellon.Visible = false;
            btnPabellon.Visible = false;
            /* Habitacion */
            txtHabitacion.Visible = false;
            btnHabitacion.Visible = false;
            /* Fecha Ingreso */
            txtFechaIngreso.Visible = false;
            btnFechaIngreso.Visible = false;

            /* Campos Vacios y Combos en index = 0 */
            cboPrueba.SelectedIndex = 0;
            txtDniPaciente.Text = "";
            cboPabellon.SelectedIndex = 0;
            txtHabitacion.Text = "";
            txtFechaIngreso.Text = "";
        }

        protected void btnDniPaciente_Click(object sender, EventArgs e)
        {
            if (txtDniPaciente.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                if (txtDniPaciente.Text.Trim().Length == 8)
                {
                    EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();
                    DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                    DataTable dt = new DataTable();

                    objHospitalizacion.Paciente = txtDniPaciente.Text.Trim();
                    objHospitalizacion.nombreUsuario = lblMedicoFijo.Text;
                    dt = dao.consultaDNIpaciente(objHospitalizacion);

                    if (dt.Rows.Count > 0)
                    {
                        gvListaHospitalizacion.DataSource = dt;
                        gvListaHospitalizacion.DataBind();

                        /* Regresar al seleccionar metodo de busqueda */
                        noVisible();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "listaVacia()", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "muchosDatos()", true);
                }
            }
        }

        protected void btnPabellon_Click(object sender, EventArgs e)
        {
            if (cboPabellon.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();
                DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                DataTable dt = new DataTable();

                objHospitalizacion.pabellonHabitacion = cboPabellon.SelectedValue;
                objHospitalizacion.nombreUsuario = lblMedicoFijo.Text;
                dt = dao.consultaPabellon(objHospitalizacion);

                if (dt.Rows.Count > 0)
                {
                    gvListaHospitalizacion.DataSource = dt;
                    gvListaHospitalizacion.DataBind();

                    /* Regresar al seleccionar metodo de busqueda */
                    noVisible();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "listaVacia()", true);
                }
            }
        }

        protected void btnHabitacion_Click(object sender, EventArgs e)
        {
            if (txtHabitacion.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                if (txtHabitacion.Text.Trim().Length == 3)
                {
                    EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();
                    DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                    DataTable dt = new DataTable();

                    objHospitalizacion.numeroHabitacion = int.Parse(txtHabitacion.Text.Trim());
                    objHospitalizacion.nombreUsuario = lblMedicoFijo.Text;
                    dt = dao.consultaHabitacion(objHospitalizacion);

                    if (dt.Rows.Count > 0)
                    {
                        gvListaHospitalizacion.DataSource = dt;
                        gvListaHospitalizacion.DataBind();

                        /* Regresar al seleccionar metodo de busqueda */
                        noVisible();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "listaVacia()", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "muchosDatosHab()", true);
                }
            }
        }

        protected void btnFechaIngreso_Click(object sender, EventArgs e)
        {
            if (txtFechaIngreso.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();
                DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                DataTable dt = new DataTable();

                objHospitalizacion.FechaIngreso = DateTime.Parse(txtFechaIngreso.Text.Trim());
                objHospitalizacion.nombreUsuario = lblMedicoFijo.Text;
                dt = dao.consultaFechaIngreso(objHospitalizacion);

                if (dt.Rows.Count > 0)
                {
                    gvListaHospitalizacion.DataSource = dt;
                    gvListaHospitalizacion.DataBind();

                    /* Regresar al seleccionar metodo de busqueda */
                    noVisible();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "listaVacia()", true);
                }
            }
        }

        protected void btnBusquedaCompleta_Click(object sender, EventArgs e)
        {
            listarGrilla();
        }

        protected void cboPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrueba.SelectedValue == "1")
            {
                /* DNI paciente */
                txtDniPaciente.Visible = true;
                btnDniPaciente.Visible = true;
                /* Pabellon */
                cboPabellon.Visible = false;
                btnPabellon.Visible = false;
                /* Habitacion */
                txtHabitacion.Visible = false;
                btnHabitacion.Visible = false;
                /* Fecha Ingreso */
                txtFechaIngreso.Visible = false;
                btnFechaIngreso.Visible = false;
            }
            else if (cboPrueba.SelectedValue == "2")
            {
                /* DNI paciente */
                txtDniPaciente.Visible = false;
                btnDniPaciente.Visible = false;
                /* Pabellon */
                cboPabellon.Visible = true;
                btnPabellon.Visible = true;
                /* Habitacion */
                txtHabitacion.Visible = false;
                btnHabitacion.Visible = false;
                /* Fecha Ingreso */
                txtFechaIngreso.Visible = false;
                btnFechaIngreso.Visible = false;
            }
            else if (cboPrueba.SelectedValue == "3")
            {
                /* DNI paciente */
                txtDniPaciente.Visible = false;
                btnDniPaciente.Visible = false;
                /* Pabellon */
                cboPabellon.Visible = false;
                btnPabellon.Visible = false;
                /* Habitacion */
                txtHabitacion.Visible = true;
                btnHabitacion.Visible = true;
                /* Fecha Ingreso */
                txtFechaIngreso.Visible = false;
                btnFechaIngreso.Visible = false;
            }
            else if (cboPrueba.SelectedValue == "4")
            {
                /* DNI paciente */
                txtDniPaciente.Visible = false;
                btnDniPaciente.Visible = false;
                /* Pabellon */
                cboPabellon.Visible = false;
                btnPabellon.Visible = false;
                /* Habitacion */
                txtHabitacion.Visible = false;
                btnHabitacion.Visible = false;
                /* Fecha Ingreso */
                txtFechaIngreso.Visible = true;
                btnFechaIngreso.Visible = true;
            }
            else
            {
                /* DNI paciente */
                txtDniPaciente.Visible = false;
                btnDniPaciente.Visible = false;
                /* Pabellon */
                cboPabellon.Visible = false;
                btnPabellon.Visible = false;
                /* Habitacion */
                txtHabitacion.Visible = false;
                btnHabitacion.Visible = false;
                /* Fecha Ingreso */
                txtFechaIngreso.Visible = false;
                btnFechaIngreso.Visible = false;
            }
        }

        protected void lkEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            pModificar.Visible = true;
            pConsulta.Visible = false;

            if (row.Cells[7].Text == "&nbsp;")
            {
                txtIdE.Text = row.Cells[0].Text;
                txtPacienteE.Text = row.Cells[1].Text;
                txtFechaIngresoE.Text = row.Cells[2].Text;
                txtHabitacionE.Text = row.Cells[3].Text;
                txtEnfermeroE.Text = row.Cells[4].Text;
                txtDiagnosticoE.Text = row.Cells[5].Text;
                txtTratamientoE.Text = row.Cells[6].Text;
                txtFechaSalidaE.Text = row.Cells[7].Text;
            }
            else
            {
                string n = "";
                DateTime dat = Convert.ToDateTime(row.Cells[7].Text); /* Recupero fecha inicio y la convierto a datetime */
                n = dat.ToString("yyyy-MM-dd");

                txtIdE.Text = row.Cells[0].Text;
                txtPacienteE.Text = row.Cells[1].Text;
                txtFechaIngresoE.Text = row.Cells[2].Text;
                txtHabitacionE.Text = row.Cells[3].Text;
                txtEnfermeroE.Text = row.Cells[4].Text;
                txtDiagnosticoE.Text = row.Cells[5].Text;
                txtTratamientoE.Text = row.Cells[6].Text;
                txtFechaSalidaE.Text = n;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDiagnosticoE.Text == "" || txtTratamientoE.Text == "" || txtFechaSalidaE.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
                pModificar.Visible = true;
            }
            else
            {
                DaoConsultaHospitalizacionMedico dao = new DaoConsultaHospitalizacionMedico();
                EntidadConsultaHospitalizacionMedico objHospitalizacion = new EntidadConsultaHospitalizacionMedico();

                objHospitalizacion.idHospitalizacion = int.Parse(txtIdE.Text);
                objHospitalizacion.Diagnostico = txtDiagnosticoE.Text;
                objHospitalizacion.Tratamiento = txtTratamientoE.Text;
                objHospitalizacion.FechaSalida = DateTime.Parse(txtFechaSalidaE.Text);

                int i = dao.modificarHospitalizacion(objHospitalizacion);

                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "confirmacionHospitalizacion()", true);
                    pModificar.Visible = true;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaHospitalizacionMedico.aspx");
        }
    }
}

