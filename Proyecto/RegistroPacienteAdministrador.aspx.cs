using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Proyecto.Dao;
using Proyecto.Entidades;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Proyecto
{
    public partial class RegistroPacienteAdministrador : System.Web.UI.Page
    {
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                cboEstadoCivil.Items.Add("Soltero");
                cboEstadoCivil.Items.Add("Casado");
                cboEstadoCivil.Items.Add("Viudo");
                cboEstadoCivil.Items.Add("Divorciado");
            }

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoNombre()", true);
            }
            else if (txtAPaterno.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoApellidoP()", true);
            }
            else if (txtAMaterno.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoApellidoM()", true);
            }
            else if (txtCorreo.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoCorreo()", true);
            }
            else if (txtCelular.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoCelular()", true);
            }
            else if (txtDNI.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoDNI()", true);
            }
            else if (txtFNacimiento.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoFecha()", true);
            }
            else if (txtContraseña.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoContraseña()", true);
            }
            else if (txtConfirmacion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi", "datoContraseñaConfirmacion()", true);
            }
            else
            {

                conex.Open();
                string query = "select CAST(COUNT(*) AS BIT) FROM Usuario WHERE DNIUsuario='" + txtDNI.Text + "'";
                SqlCommand command = new SqlCommand(query, conex);
                int n = Convert.ToInt32(command.ExecuteScalar());


                if (n == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi", "dniexistente()", true);
                }
                else
                {

                    if (txtConfirmacion.Text != txtContraseña.Text)
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "contraseñaComparacion()", true);

                    }
                    else
                    {

                        RegistroPaciente();
                        RegistroUsuario();
                        Limpiar();
                        ClientScript.RegisterStartupScript(this.GetType(), "Hi", "registro()", true);
                    }

                }
            }



        }

        void Limpiar()
        {

            txtNombre.Text = "";
            txtAPaterno.Text = "";
            txtAMaterno.Text = "";
            txtCorreo.Text = "";
            txtDNI.Text = "";
            txtCelular.Text = "";
            txtFNacimiento.Text = "";
            txtContraseña.Text = "";


        }

        void Correo(String nomusu, String contraseña, String nombre)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("fromaddress@gmail.com");
            mail.To.Add(txtCorreo.Text);

            mail.Subject = "Clinica Villa Maria del Triunfo";
            mail.Body += " <html>";
            mail.Body += "<body>";
            mail.Body += "<img src='https://cdn.pixabay.com/photo/2017/03/14/03/20/nurse-2141808_960_720.jpg' height='200' width='300'>";
            mail.Body += "<br><br>";
            mail.Body += "Estimad@ " + nombre;
            mail.Body += "<br>";
            mail.Body += " Su c&oacute;digo de validaci&oacute;n es personal, con este c&oacute;digo ud podra realizar sus consultas y acceder al Sistema";
            mail.Body += "<br><br>";
            mail.Body += "<table>";
            mail.Body += "<tr>";
            mail.Body += "<td>Usuario : </td><td> " + nomusu + " </td>";
            mail.Body += "</tr>";

            mail.Body += "<tr>";
            mail.Body += "<td>Password : </td><td>" + contraseña + "</td>";
            mail.Body += "</tr>";
            mail.Body += "</table>";
            mail.Body += "<br><br>";
            mail.Body += "Aviso de confidencialidad: El sistema de correo electr&oacute;nico del Instituto Nacional de Salud, as&iacute; como toda la informaci&oacute;n contenida en &eacute;ste, est&aacute;n destinados &uacute;nicamente para fines laborales, cualquier otro uso contraviene las pol&iacute;ticas del Instituto Nacional de Salud. Este correo electr&oacute;nico y/o material adjunto es para uso exclusivo de la entidad o de la persona / entidad a la que expresamente se le ha enviado, y puede contener informaci&oacute;n confidencial o material privilegiado. Si usted no es el destinatario leg&iacute;timo del mismo, por favor rep&oacute;rtelo inmediatamente al remitente del correo y b&oacute;rrelo. Cualquier revisi&oacute;n, retransmisi&oacute;n, difusi&oacute;n, divulgaci&oacute;n, copia y/o adulteraci&oacute;n o cualquier otro uso de este correo, por personas o entidades distintas a las del destinatario leg&iacute;timo, queda expresamente prohibido. Este correo electr&oacute;nico no pretende ni debe ser considerado como parte de ninguna relaci&oacute;n legal o contractual";
            mail.Body += "</body>";
            mail.Body += "</html>";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("clinicavillamariadeltriunfo@gmail.com", "Villa123");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        void RegistroUsuario()
        {

            String usu = this.txtNombre.Text;
            String app = this.txtAPaterno.Text;
            String apm = this.txtAMaterno.Text;

            String usu2;
            String app2;
            String apm2;

            usu2 = usu.Substring(0, 3);
            app2 = app.Substring(0, 4);
            apm2 = apm.Substring(0, 1);

            String usuario = usu2 + app2 + apm2;


            string queryy = "select CAST(COUNT(*) AS BIT) FROM Usuario WHERE nombreUsuario='" + usuario + "'";
            SqlCommand commandd = new SqlCommand(queryy, conex);
            int nn = Convert.ToInt32(commandd.ExecuteScalar());

            Random aleatorio = new Random();

            if (nn == 1)
            {
                int aleatorioDos = aleatorio.Next(1, 100);
                usuario = usuario + aleatorioDos;


                string query = "select CAST(COUNT(*) AS BIT) FROM Usuario WHERE nombreUsuario='" + usuario + "'";
                SqlCommand command = new SqlCommand(queryy, conex);
                int n = Convert.ToInt32(commandd.ExecuteScalar());

                if (n == 1)
                {
                    int aleatorioTres = aleatorio.Next(101, 200);
                    usuario = usuario + aleatorioTres;

                    DaoUsuario dao1 = new DaoUsuario();
                    EntidadUsuario objUsuario = new EntidadUsuario();


                    objUsuario.paswordUsuario = txtContraseña.Text.Trim();
                    objUsuario.nombreUsuario = usuario;
                    objUsuario.idRolUsuario = "1";
                    objUsuario.idPropietario = txtDNI.Text.Trim();


                    Correo(usuario, txtContraseña.Text, txtNombre.Text + " " + txtAPaterno.Text + " " + txtAMaterno.Text);

                    String rpta = dao1.insertarUsuario(objUsuario);


                }
                else
                {

                    DaoUsuario dao1 = new DaoUsuario();
                    EntidadUsuario objUsuario = new EntidadUsuario();


                    objUsuario.paswordUsuario = txtContraseña.Text.Trim();
                    objUsuario.nombreUsuario = usuario;
                    objUsuario.idRolUsuario = "1";
                    objUsuario.idPropietario = txtDNI.Text.Trim();

                    Correo(usuario, txtContraseña.Text, txtNombre.Text + " " + txtAPaterno.Text + " " + txtAMaterno.Text);


                    String rpta = dao1.insertarUsuario(objUsuario);
                }

            }
            else
            {

                DaoUsuario dao1 = new DaoUsuario();
                EntidadUsuario objUsuario = new EntidadUsuario();


                objUsuario.paswordUsuario = txtContraseña.Text.Trim();
                objUsuario.nombreUsuario = usuario;
                objUsuario.idRolUsuario = "1";
                objUsuario.idPropietario = txtDNI.Text.Trim();

                Correo(usuario, txtContraseña.Text, txtNombre.Text + " " + txtAPaterno.Text + " " + txtAMaterno.Text);


                String rpta = dao1.insertarUsuario(objUsuario);
            }




        }

        void RegistroPaciente()
        {


            DaoPaciente dao2 = new DaoPaciente();
            EntidadPaciente objPas = new EntidadPaciente();

            String txtGenero = "", txtEstadoCivil = "";

            if (rbFemenino.Checked)
            {
                txtGenero = "F";
            }
            else if (rbMasculino.Checked)
            {
                txtGenero = "M";
            }

            txtEstadoCivil = cboEstadoCivil.SelectedValue;


            DateTime now = DateTime.Today;
            DateTime na;
            string años;
            na = DateTime.Parse(txtFNacimiento.Text.Trim());
            int edad = now.Year - na.Year;
            if (na > now.AddYears(-edad)) edad--;
            años = edad.ToString();


            objPas.nombrePaciente = txtNombre.Text.Trim();
            objPas.apellidoPaternoPaciente = txtAPaterno.Text.Trim();
            objPas.apellidoMaternoPaciente = txtAMaterno.Text.Trim();
            objPas.correoPaciente = txtCorreo.Text.Trim();
            objPas.generoPaciente = txtGenero;
            objPas.DNIPaciente = txtDNI.Text.Trim();
            objPas.CelularPaciente = txtCelular.Text.Trim();
            objPas.estadoCivilPaciente = txtEstadoCivil;
            objPas.fechaNacimiento = txtFNacimiento.Text.Trim();
            objPas.edadPaciente = años;


            String rpta = dao2.insertarPaciente(objPas);


        }

        protected void txtFNacimiento_TextChanged(object sender, EventArgs e)
        {



        }
    }

}