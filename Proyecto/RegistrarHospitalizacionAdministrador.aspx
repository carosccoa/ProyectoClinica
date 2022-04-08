<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="RegistrarHospitalizacionAdministrador.aspx.cs" Inherits="Proyecto.RegistrarHospitalizacionAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-RegistroHos-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Registrar Hospitalización!</h1>
                            </div>
                            <div class="form-group row">
                                <strong>
                                    <p>Por favor Ingrese el DNI del paciente para ver si esta registrado.</p>
                                </strong>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                                </div>
                                <br />
                                <a runat="server" id="btnBuscar" class="btn btn-primary" onserverclick="btnBuscar_Click" validationgroup="valDni"><i class="fas fa-search"></i>Buscar</a>&nbsp&nbsp
                                <a runat="server" id="btn_Paciente" class="btn btn-secondary" onserverclick="btn_Paciente_Click"><i class="fas fa-user-plus"></i>Ingresar Paciente</a>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="label" runat="server" Text="Nombre Paciente:"></asp:Label>
                                    <asp:TextBox ID="txtNombreP" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="ID Paciente:" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtID" runat="server" Enabled="False" CssClass="form-control" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Medico:"></asp:Label>
                                    <asp:DropDownList ID="cboMedico" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Enfermero:"></asp:Label>
                                    <asp:TextBox ID="txtEnfermero" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label4" runat="server" Text="Pabellon de Habitacion:"></asp:Label>
                                    <asp:DropDownList ID="cboPabellon" AutoPostBack="true" runat="server" OnSelectedIndexChanged="seleccionPabellon" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="Numero Habitacion:"></asp:Label>
                                    <asp:DropDownList ID="cboHabitacion" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <asp:Label ID="Label7" runat="server" Text="Diagnostico:"></asp:Label>
                                    <asp:TextBox ID="txtDiagnostico" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <asp:Label ID="Label8" runat="server" Text="Tratamiento:"></asp:Label>
                                    <asp:TextBox ID="txtTratamiento" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <a runat="server" id="btnRegistrar" class="btn btn-primary" onserverclick="btnRegistrar_Click"><i class="far fa-save"></i> Registrar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


