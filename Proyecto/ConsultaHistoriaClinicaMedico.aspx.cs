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
    public partial class ConsultaHistoriaClinicaMedico : System.Web.UI.Page
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
            }
            else
            {
                if (txtDni.Text.Trim().Length == 8)
                {
                    EntidadConsultaHistoriaClinicaMedico objHC = new EntidadConsultaHistoriaClinicaMedico();
                    DaoConsultaHistorialClinicoMedico dao = new DaoConsultaHistorialClinicoMedico();
                    DataTable dt = new DataTable();

                    objHC.dniPaciente = txtDni.Text.Trim();
                    objHC.nombreUsuario = lblMedicoFijo.Text;
                    dt = dao.consultaDNIhc(objHC);

                    if (dt.Rows.Count > 0)
                    {
                        gvListaHC.DataSource = dt;
                        gvListaHC.DataBind();

                        /* Regresar campo al campo vacio */
                        txtDni.Text = "";
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

        private void listarGrilla()
        {
            if (lblMedicoFijo != null)
            {
                EntidadConsultaHistoriaClinicaMedico objEst = new EntidadConsultaHistoriaClinicaMedico();
                DaoConsultaHistorialClinicoMedico dao = new DaoConsultaHistorialClinicoMedico();
                DataTable dt = new DataTable();

                objEst.nombreUsuario = lblMedicoFijo.Text;
                dt = dao.listadoHC(objEst);

                gvListaHC.DataSource = dt;
                gvListaHC.DataBind();
            }
        }

        protected void btnListaHC_ServerClick(object sender, EventArgs e)
        {
            listarGrilla();
        }
    }
}

