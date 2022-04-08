<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="AdministraCitaAdministrador.aspx.cs" Inherits="Proyecto.AdministraCitaAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Panel ID="TablaListado" runat="server" HorizontalAlign="Center">
        <h2>Historial de Citas</h2>

        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered primary" BorderStyle="Outset">

            <Columns>


                <asp:BoundField DataField="idCita" HeaderText="Codigo Cita" />
                <asp:BoundField DataField="DNIPaciente" HeaderText="Dni" />
                <asp:BoundField DataField="nombrePaciente" HeaderText="Datos del Paciente" />
                <asp:BoundField DataField="nombreTurno" HeaderText="Turno" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>

                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-primary" OnClick="lkbModificar_Click"><i class="far fa-edit"></i>  Modificar </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </asp:Panel>


    <asp:Panel ID="ActualizarVisible" runat="server" HorizontalAlign="Center">
        <h2>Actualizacion del Estado de la Citas</h2>
        <hr />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Codigo" Enabled="False"></asp:Label><br />
                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" Enabled="False" EnableTheming="True" ReadOnly="True"></asp:TextBox><br />
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Dni Paciente"></asp:Label><br />

                    <asp:TextBox ID="txtDni" CssClass="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox><br />
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label><br />
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox><br />
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Turno"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTurno" CssClass="form-control" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <br />
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>

                    <br />
                    <asp:DropDownList ID="cboEstado" CssClass="form-control" runat="server">
                    </asp:DropDownList>

                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>

                    <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label><br />
                    <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox><br />
                </asp:TableCell>

            </asp:TableRow>


        </asp:Table>
         <hr />
                    <a id="btnActualizar" class="btn btn-primary" runat="server" onserverclick="btnActualizar_Click"><i class="far fa-edit"></i>Actualizar</a>
                    <a id="btnCancelar" class="btn btn-secondary" runat="server" onserverclick="btnCancelar_Click"><i class="fas fa-arrow-circle-left"></i>Cancelar</a>
                    <hr />
    </asp:Panel>


</asp:Content>