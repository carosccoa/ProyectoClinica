<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistrarPacienteHosp.aspx.cs" Inherits="Proyecto.RegistrarPacienteHosp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-PacienteHos-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Registrar Paciente Hospitalización!</h1>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="DNI:"></asp:Label>
                                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <asp:Label ID="Label1" runat="server" Text="Nombres:"></asp:Label>
                                    <asp:TextBox ID="txtNombreP" runat="server" CssClass="form-control" placeholder="Ingrese Nombres"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="Apellido Paterno:"></asp:Label>
                                    <asp:TextBox ID="txtApePaterno" runat="server" CssClass="form-control" placeholder="Ingrese Apellido Paterno"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Apellido Materno:"></asp:Label>
                                    <asp:TextBox ID="txtApeMaterno" runat="server" CssClass="form-control" placeholder="Ingrese Apellido Materno"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label4" runat="server" Text="Seleccione Género:"></asp:Label><br />
                                    <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="genero" Checked="True" CssClass="form-check" />
                                    <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" GroupName="genero" CssClass="form-check" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Celular:"></asp:Label>
                                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Ingrese Celular" onkeypress="javascript:return solonumeros(event)" MaxLength="9"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label7" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                    <asp:TextBox ID="txtFechaN" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <a runat="server" id="btnRegistrar" class="btn btn-primary" onserverclick="btnRegistrar_Click"><i class="far fa-save"></i>Registrar</a>
                            <a runat="server" id="btnRegresar" class="btn btn-danger" onserverclick="btnRegresar_Click"><i class="fas fa-backspace"></i>Regresar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


