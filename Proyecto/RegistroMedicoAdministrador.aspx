<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistroMedicoAdministrador.aspx.cs" Inherits="Proyecto.RegistroMedicoAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Registro Medico!</h1>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">

                                    <asp:DropDownList  ID="cboAreaMedica" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="especialidadSeleccionada"></asp:DropDownList>


                                </div>

                                <div class="col-sm-6">

                                    <asp:DropDownList ID="cboEspecialidad" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>


                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-4 mb-3 mb-sm-0">


                                    <asp:TextBox ID="txtNombre" placeholder="Ingrese Nombre" onkeypress="return soloLetras(event);" CssClass="form-control form-control-user" runat="server" ></asp:TextBox>

                                </div>
                                <div class="col-sm-4">


                                    <asp:TextBox placeholder="Apellido Paterno" onkeypress="return soloLetras(event);" class="form-control form-control-user" ID="txtAPaterno" runat="server"></asp:TextBox>
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
                                            <asp:RadioButton  ID="rbFemenino" runat="server" Text="Femenino" GroupName="gGenero" Checked="True" />
                                        </label>
                                        <label class="btn btn-secondary" style="padding-bottom: -30px;">
                                            <i class="fas fa-male"></i>
                                            <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="gGenero" />
                                        </label>

                                    </div>


                                </div>
                                <div class="col-sm-6">


                                    <asp:TextBox onkeypress="return justNumbers(event);" MaxLength="8" placeholder="Ingrese DNI" class="form-control form-control-user" ID="txtDNI" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-3 mb-3 mb-sm-0">
                                    <asp:TextBox onkeypress="return justNumbers(event);" placeholder="Celular" MaxLength="9" ID="txtCelular" CssClass="form-control form-control-user" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-5">
                                    <asp:TextBox  ID="txtConfirmacion" placeholder="Confirmacion Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="col-sm-4">
                                    <asp:TextBox  ID="txtContraseña" placeholder="Contraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                       
                               <asp:Button ID="btnRegistro" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Registrar" OnClick="btnRegistro_Click" />

                            







                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
