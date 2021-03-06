<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="icon" href="icono.png"/>
     <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet"/>

     <!-- Alerta -->
    <script src="js/sweetalert2.all.min.js"></script>
    <script>
        function datosErroneos() {

            Swal.fire(
                'Error!',
                'Datos Incorrectos!',
                'error'
            )

        }


 

    </script>

    <title>Iniciar Sesion</title>


</head>
<body class="bg-gradient-primary">


    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Bienvenidos!</h1>
                                    </div>




                                    <form class="user" runat="server">

                                        <div class="form-group">

                                            <asp:TextBox ID="txtUsuario" placeholder="Ingresar Usuario" class="form-control form-control-user" aria-describedby="emailHelp" runat="server"></asp:TextBox>

                                        </div>

                                        <div class="form-group">

                                            <asp:TextBox ID="txtContraseña" class="form-control form-control-user" placeholder="Contraseña" runat="server" TextMode="Password"></asp:TextBox>

                                        </div>



                                        <div>

                                            <asp:Button ID="btnSesion" class="btn btn-primary btn-user btn-block" runat="server" Text="Ingresar" OnClick="btnSesion_Click" />

                                        </div>



                                    </form>


                                    <hr />
                                    <div class="text-center">
                                        <a class="small" href="index.html">Volver</a>
                                    </div>
                                    <div class="text-center">
                                        <a class="small" href="Registro.aspx">Crear Cuenta</a>
                                    </div>
                                </div>
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

    <!-- Alert-->
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>


</body>
</html>