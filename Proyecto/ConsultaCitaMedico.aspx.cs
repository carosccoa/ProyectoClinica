using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.Dao;
using Proyecto.Entidades;

namespace Proyecto
{
    public partial class ConsultaCitaMedico : System.Web.UI.Page
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

                /* Llamado de funciones */
                listarGrilla();
            }
        }

        /* BOTON DE DNI */
        protected void btnDni_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);

                /* Regresar campo al campo vacio */
                txtDni.Text = "";
            }
            else
            {
                if (txtDni.Text.Trim().Length == 8)
                {
                    EntidadConsultaCita objEst = new EntidadConsultaCita();
                    DaoConsultaCita dao = new DaoConsultaCita();
                    DataTable dt = new DataTable();

                    objEst.dniPaciente = txtDni.Text.Trim();
                    objEst.nombreUsuario = lblMedicoFijo.Text;
                    dt = dao.consultaDNI(objEst);

                    if (dt.Rows.Count > 0)
                    {
                        gvListaCita.DataSource = dt;
                        gvListaCita.DataBind();

                        /* Regresar campo al campo vacio */
                        txtDni.Text = "";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "listaVacia()", true);

                        /* Regresar campo al campo vacio */
                        txtDni.Text = "";
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "muchosDatos()", true);

                    /* Regresar campo al campo vacio */
                    txtDni.Text = "";
                }
            }
        }

        private void listarGrilla()
        {
            if (lblMedicoFijo != null)
            {
                EntidadConsultaCita objEst = new EntidadConsultaCita();
                DaoConsultaCita dao = new DaoConsultaCita();
                DataTable dt = new DataTable();

                objEst.nombreUsuario = lblMedicoFijo.Text;
                dt = dao.listadoCita(objEst);

                gvListaCita.DataSource = dt;
                gvListaCita.DataBind();
            }
        }

        protected void btnCitasActuales_ServerClick(object sender, EventArgs e)
        {
            listarGrilla();
        }

        protected void btnCitasProximas_ServerClick(object sender, EventArgs e)
        {
            EntidadConsultaCita objEst = new EntidadConsultaCita();
            DaoConsultaCita dao = new DaoConsultaCita();
            DataTable dt = new DataTable();

            objEst.nombreUsuario = lblMedicoFijo.Text;
            dt = dao.citasProximas(objEst);

            gvListaCita.DataSource = dt;
            gvListaCita.DataBind();
        }

        protected void lkEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            pModificar.Visible = true;
            pConsulta.Visible = false;

            txtIdE.Text = row.Cells[0].Text;
            txtDNIE.Text = row.Cells[1].Text;
            txtPacienteE.Text = row.Cells[2].Text;
        }

        protected void btnActualizar_ServerClick(object sender, EventArgs e)
        {
            if (txtResultadoCita.Text == "" || txtMedicacion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "ningunDato()", true);
                pModificar.Visible = true;
            }
            else
            {
                DaoConsultaCita dao = new DaoConsultaCita();
                EntidadConsultaCita objCita = new EntidadConsultaCita();

                objCita.idCita = int.Parse(txtIdE.Text);
                objCita.idEstado = 2; /* DE PENDIENTE A ATENDIDO */
                objCita.resultadoCita = txtResultadoCita.Text;
                objCita.medicacion = txtMedicacion.Text;

                int i = dao.modificarCitaMedica(objCita);
                int j = dao.agregarModCitaHC(objCita);

                if (i > 0 && j > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "confirmacionCita()", true);
                    pModificar.Visible = true;
                }
            }
        }

        protected void btnCancelar_ServerClick(object sender, EventArgs e)
        {
            pConsulta.Visible = true;
            pModificar.Visible = false;
        }
    }
}

