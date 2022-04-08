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
    public partial class RegistrarReservacionPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string n;


                n = Convert.ToString(Session["id"]);



                txtDato.Text = n;

                ListarDatosPaciente();
                listarEspecialidadPaciente();
                listarTurno();
            }

        }
        private void limpiarCampos()
        {
            cboEspecialidad.SelectedValue = "0";
            cboMedico.SelectedValue = "0";
            cboTurno.SelectedValue = "0";
            txtFecha.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void RegistraCita()
        {

            string est = "";

            if (txtEstado.Text == "En Proceso")
            {
                est = " 1";
            };

            string estpag = "";

            if (txtEstadoPago.Text == "Pendiente")
            {
                estpag = " 1";
            };

            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            EntidadReservacionCitaPaciente obj = new EntidadReservacionCitaPaciente();
            obj.idPaciente = int.Parse(txtCodigo.Text);
            obj.idMedico = int.Parse(cboMedico.Text);
            obj.idTurno = int.Parse(cboTurno.SelectedValue);
            obj.fecha = txtFecha.Text;
            obj.idEstadoCita = est;
            obj.descripcion = txtDescripcion.Text;
            obj.idEstadoPago = estpag;
            obj.idCodPagos = txtCodPago.Text;

            string rpta = dao.insertar(obj);

            if (rpta == "¡Se registro con exito!")
            {


                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "Registrado()", true);
                Response.AddHeader("REFRESH", "1.5;URL=RegistrarReservacionPaciente.aspx");
            }

        }





        private void listarEspecialidadPaciente()
        {
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listarEspecialidadPaciente();
            cboEspecialidad.DataSource = dt;
            cboEspecialidad.DataTextField = "especialidad";
            cboEspecialidad.DataValueField = "idEspecialidad";
            cboEspecialidad.DataBind();
            cboEspecialidad.Items.Insert(0, new ListItem("Seleccione", "0"));
            cboMedico.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        protected void ListarDatosPaciente()
        {


            if (txtDato.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
                DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
                DataTable dt = new DataTable();
                if (txtDato.Text != null)
                {
                    rsd.usuario = txtDato.Text;
                    dt = dao.ListarDatosPaciente(rsd);

                    if (dt.Rows.Count > 0)
                    {
                        txtCodigo.Text = dt.Rows[0]["idPaciente"].ToString();
                        txtApeP.Text = dt.Rows[0]["apellidoPaternoPaciente"].ToString();
                        txtApeM.Text = dt.Rows[0]["apellidoMaternoPaciente"].ToString();
                        txtNombre.Text = dt.Rows[0]["nombrePaciente"].ToString();

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "NohayDatos()", true);


                    }
                }
            }
        }

        protected void especialidadSeleccionada(object sender, EventArgs e)
        {

            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            EntidadReservacionCitaPaciente erc = new EntidadReservacionCitaPaciente();
            DataTable dt = new DataTable();
            erc.idEspecialidad = int.Parse(cboEspecialidad.SelectedValue);
            dt = dao.listarMedicoPaciente(erc);
            cboMedico.DataSource = dt;
            cboMedico.DataTextField = "nombreMedico";
            cboMedico.DataValueField = "idMedico";
            cboMedico.DataBind();
            cboMedico.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        private void listarTurno()
        {
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listarTurnoPaciente();
            cboTurno.DataSource = dt;
            cboTurno.DataTextField = "nombreTurno";
            cboTurno.DataValueField = "idTurno";
            cboTurno.DataBind();
            cboTurno.Items.Insert(0, new ListItem("Seleccione", "0"));

        }


        protected void btnReservarCita_Click(object sender, EventArgs e)
        {
            if (cboEspecialidad.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatos1()", true);
            }
            else if (cboMedico.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatos2()", true);
            }
            else if (cboTurno.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatos3()", true);
            }
            else if (txtFecha.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatos4()", true);
            }
            else if (txtDescripcion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ErrorDatos5()", true);
            }
            else
            {

                RegistraCita();
                limpiarCampos();
            }

        }
    }
}

