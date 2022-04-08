<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistrarCitaAdministrador.aspx.cs" Inherits="Proyecto.RegistrarCitaAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-RegisCita-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Registrar Cita!</h1>
                            </div>
                            <div class="form-group row">
                                <strong>
                                    <p>Por favor Ingrese el DNI del paciente para ver si esta registrado.</p>
                                </strong>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtDatoDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                                </div>
                                <br />
                            <a runat="server" id="Button1" class="btn btn-primary" onserverclick="btnBuscar_Click"><i class="fas fa-search"></i>Buscar</a>&nbsp&nbsp
                                <a runat="server" id="btnIngresar" class="btn btn-secondary" onserverclick="btnIngresar_Click" visible="False"><i class="fas fa-user-plus"></i>Ingresar Paciente</a>

                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="RESULTADO DE BUSQUEDA:"></asp:Label>
                                    <asp:Label ID="lblResultado" CssClass="form-control" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Paciente:"></asp:Label>
                                    <asp:TextBox ID="txtPaciente" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Enabled="False" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label4" runat="server" Text="Especialidad:"></asp:Label>
                                    <asp:DropDownList ID="cboEspecialidad" AutoPostBack="true" runat="server" OnSelectedIndexChanged="especialidadSeleccionada" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="Medico:"></asp:Label>
                                    <asp:DropDownList ID="cboMedico" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Turno:"></asp:Label>
                                    <asp:DropDownList ID="cboTurno" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label7" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Estado:"></asp:Label>
                                    <asp:TextBox ID="txtEstado" runat="server" Enabled="False" CssClass="form-control">PENDIENTE</asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <asp:Label ID="Label9" runat="server" Text="Descripción de la Cita:"></asp:Label>
                                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" ValidationGroup="valRegistrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>


