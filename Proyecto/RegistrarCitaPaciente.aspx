<%@ Page Title="" Language="C#" MasterPageFile="~/HomePaciente.Master" AutoEventWireup="true" CodeBehind="RegistrarCitaPaciente.aspx.cs" Inherits="Proyecto.RegistrarCitaPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <asp:Panel ID="buscar" runat="server" HorizontalAlign="Center">
        <h2>REGISTRAR CITA MÉDICA</h2>

        <hr />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <div class="row g-3">
                        <div class="col-3">
                            <asp:TextBox ID="txtDni" runat="server" Width="250px" placeholder="Ingrese su DNI" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </asp:TableCell>

                <asp:TableCell>


                    <a runat="server" id="btnBuscar" class="btn btn-primary" onserverclick="btnBuscar_Click"><i class="fas fa-search"></i>Buscar</a>

                </asp:TableCell>
                <asp:TableCell>
                      <hr />
                </asp:TableCell>

            </asp:TableRow>


        </asp:Table>
    </asp:Panel>
    <hr />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">


            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label7" runat="server" Text="Codigo"></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label3" runat="server" Text="Paciente"></asp:Label>
                    <asp:TextBox ID="txtdatos" Enabled="False" CssClass="form-control" runat="server"></asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label2" runat="server" Text="Turno"></asp:Label>
                    <asp:DropDownList ID="cboTurno" runat="server" CssClass="form-control" required=""></asp:DropDownList>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label8" runat="server" Text="Estado"></asp:Label>
                    <asp:TextBox ID="txtEstado" Enabled="False" CssClass="form-control" runat="server" ValidateRequestMode="Enabled">En Proceso</asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server">
                <asp:TableCell runat="server">

                    <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label><br />
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox><br />

                </asp:TableCell>
            </asp:TableRow>
          

        </asp:Table>
         <a runat="server" id="btnRegistrar" class="btn btn-primary" onserverclick="btnRegistrar_Click"><i class="fas fa-plus"></i>Registrar</a><br />
          <asp:Label ID="lblRpta" runat="server"></asp:Label>
    </asp:Panel>





</asp:Content>