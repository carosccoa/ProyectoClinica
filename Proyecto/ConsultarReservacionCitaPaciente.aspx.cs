using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.Entidades;
using Proyecto.Dao;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto
{
    public partial class ConsultarReservacionCitaPaciente : System.Web.UI.Page
    {

        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);


        private void listarEstadoPago()
        {
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            dt = dao.listarEstado();
            cboFiltro.DataSource = dt;
            cboFiltro.DataTextField = "nombreEstado";
            cboFiltro.DataValueField = "nombreEstado";
            cboFiltro.DataBind();
            cboFiltro.Items.Insert(0, new ListItem("Seleccione", "0"));

        }

        protected void ConseguirListaRecervacion()
        {

            EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            if (txtDato.Text != null)
            {
                rsd.usuario = txtDato.Text;
                dt = dao.listarTabla(rsd);
                if (dt.Rows.Count > 0)
                {
                    gvSalida.DataSource = dt;
                    gvSalida.DataBind();
                };

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string n;


                n = Convert.ToString(Session["id"]);

                Response.Write(n);

                txtDato.Text = n;
                listarCompletoFiltro();

                listarEstadoPago();
                TablaListado.Visible = true;
                ActualizarVisible.Visible = false;
            }
        }

        void Limpiar()
        {

            txtCodigoPago.Text = "";



        }

        protected void RealizarPago_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;
            txtCodigo.Text = row.Cells[0].Text;
            txtDNI.Text = row.Cells[1].Text;
            txtPaciente.Text = row.Cells[2].Text;
            txtMedico.Text = row.Cells[3].Text;
            txtEspecialidad.Text = row.Cells[4].Text;
            txtFecha.Text = row.Cells[5].Text;
            txtEstadoPag.Text = row.Cells[6].Text;

            TablaListado.Visible = false;
            ActualizarVisible.Visible = true;
        }

        protected void ModificarEstado()
        {
            EntidadReservacionCitaPaciente obj = new EntidadReservacionCitaPaciente();
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();

            obj.idCita = int.Parse(txtCodigo.Text);
            obj.idCodPagos = txtCodigoPago.Text;

            int i = dao.ModificarEstado(obj);
            if (i > 0)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "confirmacionA()", true);

            };
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {

            if (txtCodigoPago.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "CampoVacio()", true);
            }
            else
            {
                conex.Open();
                string query = "select  CAST(COUNT(*) AS BIT) FROM CodigoPagos WHERE codigoPago ='" + txtCodigoPago.Text + "'";
                SqlCommand command = new SqlCommand(query, conex);
                int n = Convert.ToInt32(command.ExecuteScalar());

                if (n == 1)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "CodVerificado()", true);
                    ModificarEstado();
                    Response.AddHeader("REFRESH", "1.5;URL=FacturaPago.aspx");


                }

                if (n == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "NoExiste()", true);
                    Limpiar();
                    ActualizarVisible.Visible = true;
                    TablaListado.Visible = false;

                };
            }





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
                    rsd.idEstadoPago = cboFiltro.Text;
                    dt = dao.listarFiltroPago(rsd);
                    if (dt.Rows.Count > 0)
                    {
                        gvSalida.DataSource = dt;
                        gvSalida.DataBind();
                    }


                }
            }


        }

        protected void listarCompletoFiltro()
        {
            EntidadReservacionCitaPaciente rsd = new EntidadReservacionCitaPaciente();
            DaoReservacionCitaPaciente dao = new DaoReservacionCitaPaciente();
            DataTable dt = new DataTable();
            if (txtDato.Text != null)
            {
                rsd.usuario = txtDato.Text;
                dt = dao.listarReservacionCitaCompleto(rsd);
                if (dt.Rows.Count > 0)
                {
                    gvSalida.DataSource = dt;
                    gvSalida.DataBind();
                };



            }

        }



        protected void btn_ListarTodo_Click(object sender, EventArgs e)
        {

            listarCompletoFiltro();
        }
    }
}


