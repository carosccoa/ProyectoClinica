<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="ConsultarHisMedAdministrador.aspx.cs" Inherits="Proyecto.ConsultarHisMedAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">CONSULTAR HISTORIAL MEDICO</h6>
            </div>
            <br />
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Seleccione Tipo de Busqueda:"></asp:Label>
                <div class="row">
                    <div class="col-md-2">
                        <asp:DropDownList CssClass="form-control" ID="cboBusqueda" runat="server" OnSelectedIndexChanged="cboBusqueda_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtDato" CssClass="form-control" runat="server" placeholder="Ingrese DNI" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ingrese Paciente" runat="server" Visible="False"></asp:TextBox>
                    </div>
                </div>
                <br />
                <a runat="server" id="btnBuscar" class="btn btn-outline-primary" onserverclick="Button1_Click"><i class="fas fa-search"></i>Buscar</a>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-bordered" BorderStyle="Outset" ID="gvResultado" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


