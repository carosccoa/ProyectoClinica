using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.Dao;
using Proyecto.Entidades;


namespace Proyecto
{
    public partial class RegistrarCitaPaciente : System.Web.UI.Page
    {
        private void listarTurno()
        {
            DaoCitaPaciente dao = new DaoCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listarTurno();
            cboTurno.DataSource = dt;
            cboTurno.DataTextField = "nombreTurno";
            cboTurno.DataValueField = "idTurno";
            cboTurno.DataBind();
            cboTurno.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        private void ResultadoSegunDNI()
        {

            if (txtDni.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
            }
            else
            {
                EntidadCitaPaciente rsd = new EntidadCitaPaciente();
                DaoCitaPaciente dao = new DaoCitaPaciente();
                DataTable dt = new DataTable();
                if (txtDni.Text != null)
                {
                    rsd.DNIPaciente = txtDni.Text;
                    dt = dao.ResultadoSegunDNI(rsd);

                    if (dt.Rows.Count > 0)
                    {
                        txtCodigo.Text = dt.Rows[0]["idPaciente"].ToString();
                        txtdatos.Text = dt.Rows[0]["Paciente"].ToString();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "NohayDatos()", true);
                        btnBuscar.Visible = true;
                    }
                }
            }

        }


        private void RegistraCita()
        {



            string est = "";

            if (txtEstado.Text == "En Proceso")
            {
                est = " 1";
            };

            DaoCitaPaciente dao = new DaoCitaPaciente();
            EntidadCitaPaciente obj = new EntidadCitaPaciente();
            obj.idPaciente = txtCodigo.Text;
            obj.idTurno = cboTurno.SelectedValue;
            obj.fecha = txtFecha.Text;
            obj.descripcion = txtDescripcion.Text;
            obj.idEstado = est;

            string rpta = dao.insertar(obj);
            lblRpta.Text = rpta;
        }





        private void limpiar()
        {
            txtdatos.Text = String.Empty;
            txtCodigo.Text = String.Empty;
            txtDni.Text = String.Empty;
            txtFecha.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cboTurno.SelectedValue = "0";
            txtDni.Focus();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarTurno();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cboTurno.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "SeleccioneTurno()", true);
            }
            else if (txtFecha.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "VacioFecha()", true);
            }
            else if (txtDescripcion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "VacioDesc()", true);

            }
            else
            {
                RegistraCita();
                limpiar();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ResultadoSegunDNI();
        }


    }
}