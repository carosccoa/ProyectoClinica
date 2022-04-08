<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="ConsultarCitaAdministrador.aspx.cs" Inherits="Proyecto.ConsultarCitaAdministrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">CONSULTAR CITA MEDICA</h6>
            </div>
            <br />
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Seleccione el tipo de Busqueda"></asp:Label><br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:DropDownList ID="cboTipo" CssClass="form-control" runat="server" OnSelectedIndexChanged="cboTipo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="cboEstado" CssClass="form-control" runat="server" Visible="False"></asp:DropDownList>
                        <asp:DropDownList ID="cboArea" CssClass="form-control" runat="server" Visible="False"></asp:DropDownList>
                        <asp:DropDownList ID="cboEspecialidad" CssClass="form-control" runat="server" Visible="False"></asp:DropDownList>
                        <asp:TextBox ID="txtDato" CssClass="form-control" runat="server" placeholder="Ingrese DNI" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div>
                    <a runat="server" id="btnBuscar" class="btn btn-outline-primary" onserverclick="btnBuscar_Click"><i class="fas fa-search"></i>Buscar</a>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="gvSalida" runat="server" CssClass="table table-bordered" Width="100%" CellSpacing="0"></asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


