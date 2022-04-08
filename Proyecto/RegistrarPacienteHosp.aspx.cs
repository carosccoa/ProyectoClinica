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
    public partial class RegistrarPacienteHosp : System.Web.UI.Page
    {
        public void Registrar()
        {
            if (txtApeMaterno.Text != string.Empty && txtApePaterno.Text != string.Empty &&
                txtNombreP.Text != string.Empty && txtCelular.Text != string.Empty &&
                txtDNI.Text != string.Empty && txtFechaN.Text != string.Empty)
            {

                string edad = CalcEdad(txtFechaN.Text);
                string gen = "Masculino";
                if (rbFemenino.Checked)
                {
                    gen = "Femenino";
                }
                EntidadRegistrarHospitalizacion rph = new EntidadRegistrarHospitalizacion();
                DaoRegistrarAdministrador dao = new DaoRegistrarAdministrador();
                rph.nomPH = txtNombreP.Text;
                rph.apePH = txtApePaterno.Text;
                rph.apeMH = txtApeMaterno.Text;
                rph.genPH = gen;
                rph.dniPH = txtDNI.Text;
                rph.celPH = txtCelular.Text;
                rph.fecNH = txtFechaN.Text;
                rph.edaPH = edad;
                int res = dao.registrarPacienteHos(rph);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hi9", "RegistradoPH()", true);
                    btnRegistrar.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('Error al registrar!!!')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Hi2", "ValDatosReg()", true);
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        public static string CalcEdad(string fnac)
        {
            DateTime dat = Convert.ToDateTime(fnac);
            DateTime nacimiento = new DateTime(dat.Year, dat.Month, dat.Day);
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            return edad.ToString();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarHospitalizacionAdministrador.aspx");
        }
    }
}

