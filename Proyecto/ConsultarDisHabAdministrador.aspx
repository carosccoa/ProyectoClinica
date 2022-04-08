<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="ConsultarDisHabAdministrador.aspx.cs" Inherits="Proyecto.ConsultarDisHabAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">CONSULTAR DISPONIBILIDAD DE HABITACIÓN</h6>
            </div>
            <br />
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Seleccione Especialidad"></asp:Label>
                <div class="row">
                    <div class="col-md-3">
                        <asp:DropDownList ID="cboEspecialidad" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div>
                    <a runat="server" id="btnBuscar" class="btn btn-outline-primary" onserverclick="btnBuscar_Click"><i class="fas fa-search"></i>Buscar</a>
                    &nbsp&nbsp
           
                    <a runat="server" id="btnListar" class="btn btn-primary" onserverclick="btnListar_Click"><i class="far fa-list-alt"></i>Listar Todo</a>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="gvSalidah" CssClass="table table-bordered" BorderStyle="Outset" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


