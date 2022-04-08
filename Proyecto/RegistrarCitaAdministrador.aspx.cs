using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Proyecto.Dao;
using Proyecto.Entidades;
namespace Proyecto
{
    public partial class RegistrarCitaAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
                cargarTurno();
                desactivadorCampos();
                txtDatoDNI.Focus();
                btnRegistrar.Visible = false;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPacienteAdministrador.aspx");
        }

        public DataSet consultar(string consql)
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-NEP51I9; database=clinicamedica; integrated security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand(consql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
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
            cboMedico.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void cargarTurno()
        {
            cboTurno.DataSource = consultar("select * from turno");
            cboTurno.DataTextField = "nombreTurno";
            cboTurno.DataValueField = "idTurno";
            cboTurno.DataBind();
            cboTurno.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void desactivadorCampos()
        {
            txtDescripcion.Enabled = false;
            txtFecha.Enabled = false;
            cboEspecialidad.Enabled = false;
            cboMedico.Enabled = false;
            cboTurno.Enabled = false;
        }
        private void activadorCampos()
        {
            txtDescripcion.Enabled = true;
            txtFecha.Enabled = true;
            cboEspecialidad.Enabled = true;
            cboMedico.Enabled = true;
            cboTurno.Enabled = true;
        }
        private void limpiador()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtFecha.Text = string.Empty;
            cboTurno.SelectedIndex = 0;
            cboEspecialidad.Items.Clear();
            cboMedico.Items.Clear();
            cargarDatos();
            txtDatoDNI.Text = string.Empty;
            txtDatoDNI.Focus();
            desactivadorCampos();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            if (txtDatoDNI.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS; database=clinicamedica; integrated security=true");
                cmd = new SqlCommand("select idPaciente, concat(nombrePaciente,' ',apellidoPaternoPaciente,' ',apellidoMaternoPaciente)as Paciente from Paciente where DNIPaciente=@dni", con);
                cmd.Parameters.AddWithValue("@dni", txtDatoDNI.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblResultado.Text = "Encontrado";
                    txtCodigo.Text = dr["idPaciente"].ToString();
                    txtPaciente.Text = dr["Paciente"].ToString();
                    activadorCampos();
                    btnRegistrar.Visible = true;
                }
                else
                {
                    btnRegistrar.Visible = false;
                    desactivadorCampos();
                    lblResultado.Text = "No se encontro";
                    btnIngresar.Visible = true;
                    txtDatoDNI.Text = string.Empty;
                    txtCodigo.Text = string.Empty;
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi6", "NoPacientesHos()", true);
                }

                con.Close();

            }
        }

        protected void especialidadSeleccionada(object sender, EventArgs e)
        {
            DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
            EntidadRegistrarCita erc = new EntidadRegistrarCita();
            DataTable dt = new DataTable();
            erc.idEspecialidad = int.Parse(cboEspecialidad.SelectedValue);
            dt = dao.listarMedicoEsp(erc);
            cboMedico.DataSource = dt;
            cboMedico.DataTextField = "nombreMedico";
            cboMedico.DataValueField = "idMedico";
            cboMedico.DataBind();
            cboMedico.Items.Insert(0, new ListItem("Seleccione", "0"));

        }
        /*@idPaciente,@idMedico,@idTurno,@fecha,@idEstado,@descripcion*/
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != string.Empty && txtFecha.Text != string.Empty &&
                cboEspecialidad.SelectedValue != "0" && cboMedico.SelectedValue != "0" &&
                cboTurno.SelectedValue != "0")
            {
                int estado = 3;
                if (txtEstado.Text == "PENDIENTE")
                {
                    estado = 1;
                }
                else if (txtEstado.Text == "ATENDIDO")
                {
                    estado = 2;
                }
                EntidadRegistrarCita rgc = new EntidadRegistrarCita();
                DaoRegistrarAdministrador drg = new DaoRegistrarAdministrador();
                rgc.idPaciente = int.Parse(txtCodigo.Text.Trim());
                rgc.idMedico = Convert.ToInt32(cboMedico.SelectedValue);
                rgc.idTurno = Convert.ToInt32(cboTurno.SelectedValue);
                rgc.fecha = txtFecha.Text;
                rgc.estadoCita = estado;
                rgc.descripcion = txtDescripcion.Text;

                string rpta = drg.registrarCita(rgc);

                if (rpta == "¡Se registro con exito!")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi6", "Registrado()", true);
                    Response.AddHeader("REFRESH", "1.5;URL=RegistrarCitaAdministrador.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi6", "ValDatosReg()", true);
            }
        }
    }
}

