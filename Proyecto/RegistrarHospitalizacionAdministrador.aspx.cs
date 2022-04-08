using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.Entidades;
using Proyecto.Dao;
namespace Proyecto
{
    public partial class RegistrarHospitalizacionAdministrador : System.Web.UI.Page
    {
        private int busPacHosp()
        {
            EntidadRegistrarHospitalizacion erh = new EntidadRegistrarHospitalizacion();
            DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
            DataTable dt = new DataTable();
            erh.dni = txtDNI.Text;
            dt = dao.resPacHosp(erh);
            int res = int.Parse(dt.Rows[0]["paciente"].ToString());
            return res;
        }

        private void resDNI()
        {
            EntidadRegistrarHospitalizacion erh = new EntidadRegistrarHospitalizacion();
            DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
            DataTable dt = new DataTable();
            if (txtDNI.Text != string.Empty)
            {
                erh.dni = txtDNI.Text;
                dt = dao.resDNI(erh);
                int con = busPacHosp();
                if (dt.Rows.Count > 0)
                {
                    if (con == 0)
                    {
                        txtID.Text = dt.Rows[0]["idPacienteHos"].ToString();
                        txtNombreP.Text = dt.Rows[0]["NombrePaciente"].ToString();
                        descloquearCam();
                    }
                    else if (con > 0)
                    {
                        txtDNI.Text = string.Empty;
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi6", "HospRegistrado()", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi6", "NoPacientesHos()", true);
                    btn_Paciente.Visible = true;
                    txtDNI.Text = string.Empty;
                    clear();
                    bloquearCampos();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosCbo()", true);
                clear();
                bloquearCampos();
            }
        }

        private void listarMedico()
        {
            DataTable dt = new DataTable();
            DaoRegistrarAdministrador dr = new DaoRegistrarAdministrador();
            dt = dr.listaMedico();
            cboMedico.DataSource = dt;
            cboMedico.DataTextField = "Nombre";
            cboMedico.DataValueField = "idMedico";
            cboMedico.DataBind();
            cboMedico.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void listarPabellon()
        {
            DataTable dt = new DataTable();
            DaoRegistrarAdministrador dr = new DaoRegistrarAdministrador();
            dt = dr.listarArea();
            cboPabellon.DataSource = dt;
            cboPabellon.DataTextField = "pabellonHabitacion";
            cboPabellon.DataBind();
            cboPabellon.Items.Insert(0, new ListItem("Seleccione", "0"));
            cboHabitacion.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void listarHabitacion()
        {
            EntidadRegistrarHospitalizacion erh = new EntidadRegistrarHospitalizacion();
            DaoRegistrarAdministrador dr = new DaoRegistrarAdministrador();
            erh.pabellon = cboPabellon.Text;
            DataTable dt = new DataTable();
            dt = dr.listarHabitacionDis(erh);
            cboHabitacion.DataSource = dt;
            cboHabitacion.DataTextField = "numeroHabitacion";
            cboHabitacion.DataValueField = "idHabitacion";
            cboHabitacion.DataBind();
            cboHabitacion.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void ingresaHospitalizacion()
        {
            if (txtDiagnostico.Text != string.Empty && txtEnfermero.Text != string.Empty &&
                txtTratamiento.Text != string.Empty && cboHabitacion.SelectedValue != "0" &&
                cboMedico.SelectedValue != "0" && cboPabellon.SelectedValue != "0")
            {
                EntidadRegistrarHospitalizacion rh = new EntidadRegistrarHospitalizacion();
                DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
                rh.enfermero = txtEnfermero.Text;
                rh.habitacion = int.Parse(cboHabitacion.SelectedValue);
                rh.diagnostico = txtDiagnostico.Text;
                rh.medico = int.Parse(cboMedico.SelectedValue);
                rh.paciente = int.Parse(txtID.Text);
                rh.tratamiento = txtTratamiento.Text;
                string res = dao.registrarHospitalizacion(rh);
                int res2 = dao.regHabO(rh);
                if (res2 == 1 && res == "¡Se registro con exito!")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi8", "Registrado()", true);
                    clear();
                    bloquearCampos();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosReg()", true);
            }
        }
        protected void clear()
        {
            txtDNI.Text = string.Empty;
            txtDiagnostico.Text = string.Empty;
            txtEnfermero.Text = string.Empty;
            txtID.Text = string.Empty;
            txtNombreP.Text = string.Empty;
            txtTratamiento.Text = string.Empty;
            cboMedico.ClearSelection();
            cboPabellon.Items.Clear();
            cboHabitacion.Items.Clear();
            listarPabellon();
        }
        protected void bloquearCampos()
        {
            txtEnfermero.Enabled = false;
            txtTratamiento.Enabled = false;
            txtDiagnostico.Enabled = false;
            cboHabitacion.Enabled = false;
            cboMedico.Enabled = false;
            cboPabellon.Enabled = false;
            btnRegistrar.Visible = false;
        }
        protected void descloquearCam()
        {
            txtEnfermero.Enabled = true;
            txtTratamiento.Enabled = true;
            txtDiagnostico.Enabled = true;
            cboHabitacion.Enabled = true;
            cboMedico.Enabled = true;
            cboPabellon.Enabled = true;
            btnRegistrar.Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listarMedico();
                listarPabellon();
                bloquearCampos();
                bloquearCampos();
            }
        }

        protected void seleccionPabellon(object sender, EventArgs e)
        {
            listarHabitacion();
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            resDNI();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ingresaHospitalizacion();
        }

        protected void btn_Paciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarPacienteHosp.aspx");
        }
    }
}

