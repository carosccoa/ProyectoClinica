<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="ConsultarHospAdministrador.aspx.cs" Inherits="Proyecto.ConsultarHospAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">CONSULTAR HOSPITALIZACION</h6>
            </div>
            <br />
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Seleccione Tipo de Busqueda:"></asp:Label>
                <div class="row">
                    <div class="col-md-2">
                        <asp:DropDownList ID="cboBusqueda" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboBusqueda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtDNI" CssClass="form-control" placeholder="Ingrese DNI" runat="server" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                        <asp:TextBox ID="txtPaciente" CssClass="form-control" runat="server" placeholder="Ingrese Paciente" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtMedico" CssClass="form-control" runat="server" placeholder="Ingrese Medico" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtHabitacion" CssClass="form-control" placeholder="Ingrese Habitación" Visible="False" runat="server" onkeypress="javascript:return solonumeros(event)"></asp:TextBox>
                    </div>
                </div>
                <br />
                <a runat="server" id="btnBuscar" class="btn btn-outline-primary" onserverclick="Button1_Click"><i class="fas fa-search"></i>Buscar</a>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="gvResultado" runat="server" CssClass="table table-bordered" BorderStyle="Outset"></asp:GridView>
                </div>
            </div>
        </div>
    </div>



</asp:Content>


