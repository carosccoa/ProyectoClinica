
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

        <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" href="icono.png"/>
        <!-- Alerta -->
    <script src="js/sweetalert2.all.min.js"></script>

    <title>Registro</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet"/>

    <script>

        function soloLetras(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;

            return false;
        }

        function justNumbers(e) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8 || keynum == 48))
                return true;
            if (keynum <= 47 || keynum >= 58) return false;
            return /\d/.test(String.fromCharCode(keynum));
        }



        function dniexistente() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'El DNI ya esta siendo usado'
            })

        }

        function datoNombre() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de nombre'
            })

        }

        function datoApellidoP() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de apellido paterno'
            })

        }

        function datoApellidoM() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de apellido materno'
            })

        }

        function datoCorreo() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de correo electronico'
            })

        }

        function datoDNI() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de DNI'
            })

        }

        function datoCelular() {

            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de celular'
            })

        }

        function datoFecha() {
            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de fecha'
            })

        }

        function datoContraseña() {
            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de contraseña'
            })

        }

        function datoContraseñaConfirmacion() {
            Swal.fire({
                icon: 'info',
                title: 'Oops...',
                text: 'Complete el campo de confirmacion de contraseña'
            })

        }



         function contraseñaComparacion() {

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Las contraseñas no coinciden'
            })

        }

        function registro() {

            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Registro Exitoso',
                showConfirmButton: false,
                timer: 1500

            })

        }

    </script>

</head>


<body class="bg-gradient-primary">

    


        <div class="container">
            
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Crea una Cuenta!</h1>
                                </div>
                                <form id="form1" runat="server">
                                <div class="form-group row">
                                    <div class="col-sm-4 mb-3 mb-sm-0">


                                        <asp:TextBox ID="txtNombre" placeholder="Ingrese Nombre" onkeypress="return soloLetras(event);" CssClass="form-control form-control-user" runat="server" ></asp:TextBox>

                                    </div>
                                    <div class="col-sm-4">


                                        <asp:TextBox placeholder="Apellido Paterno" onkeypress="return soloLetras(event);" class="form-control form-control-user"  ID="txtAPaterno" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">

                                        <asp:TextBox onkeypress="return soloLetras(event);" placeholder="Apellido Materno" class="form-control form-control-user" ID="txtAMaterno" runat="server"></asp:TextBox>



                                    </div>
                                </div>
                                <div class="form-group">

                                    <asp:TextBox ID="txtCorreo"  placeholder="Ingrese Correo Electronico" class="form-control form-control-user" runat="server" TextMode="Email"></asp:TextBox>

                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">

                                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                            <label class="btn btn-secondary active" style="padding-bottom: -30px;">
                                                <i class="fas fa-female"></i>
                                                <asp:RadioButton required="required" ID="rbFemenino" runat="server" Text="Femenino" GroupName="gGenero" Checked="True" />
                                            </label>
                                            <label class="btn btn-secondary" style="padding-bottom: -30px;">
                                                <i class="fas fa-male"></i>
                                                <asp:RadioButton required="required" ID="rbMasculino" runat="server" Text="Masculino" GroupName="gGenero" />
                                            </label>

                                        </div>


                                    </div>
                                    <div class="col-sm-6">


                                        <asp:TextBox  onkeypress="return justNumbers(event);" MaxLength="8" placeholder="Ingrese DNI" class="form-control form-control-user" ID="txtDNI" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-sm-4 mb-3 mb-sm-0">



                                        <asp:TextBox  onkeypress="return justNumbers(event);" placeholder="Celular" MaxLength="9" ID="txtCelular" CssClass="form-control form-control-user" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList  ID="cboEstadoCivil" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-5">
                                        <asp:TextBox ID="txtFNacimiento" CssClass="form-control" runat="server" TextMode="Date" OnTextChanged="txtFNacimiento_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">

                                    <div class="col-sm-3">
                                        <asp:TextBox  ID="txtContraseña" placeholder="Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-5">
                                        <asp:TextBox  ID="txtConfirmacion" placeholder="Confirmacion Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        <div class="text-right">
                                            <a href="#" class="btn btn-primary btn-icon-split">
                                                <span class="icon ">
                                                    <i class="fas fa-user-plus"></i>
                                                </span>
                                                <asp:Button ID="btnRegistro" CssClass="text btn btn-primary btn-icon-split" runat="server" Text="Registrar" OnClick="btnRegistro_Click" />

                                            </a>
                                        </div>


                                    </div>
                                </div>


                                    
    </form>



                                <hr />

                                <div class="text-center">
                                    <a class="small" href="Login.aspx">Ya tienes una cuenta? Inicia Sesion!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin-2.min.js"></script>



</body>
</html>

