<%@ Page Title="" Language="C#" MasterPageFile="~/HomePaciente.Master" AutoEventWireup="true" CodeBehind="RegistrarReservacionPaciente.aspx.cs" Inherits="Proyecto.RegistrarReservacionPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <asp:Panel ID="buscar" runat="server" HorizontalAlign="Center">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-4 d-none d-lg-block bg-RegistraReservacion-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Reservacion de Cita Médica</h1>
                            </div>
                                <asp:Table ID="Table2" runat="server" HorizontalAlign="Center" Width="692px">
                                    <asp:TableRow runat="server">
                                        <asp:TableCell runat="server">
                                            <div class="row">
                                                <div class="col">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Label ID="Label1" runat="server" Text="Apellido Paterno"></asp:Label>
                                                            <asp:TextBox ID="txtApeP" runat="server" CssClass="form-control" Width="180px" Enabled="False"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                        <div class="col">
                                                            <asp:Label ID="Label8" runat="server" Text="Apellido Materno"></asp:Label>
                                                            <asp:TextBox ID="txtApeM" runat="server" CssClass="form-control" Width="180px" Enabled="False"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">

                                                            <asp:Label ID="Label9" runat="server" Text="Nombre"></asp:Label>
                                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="180px" Enabled="False"></asp:TextBox><br />

                                                        </div>
                                                        <div class="col">
                                                            <asp:Label ID="Label3" runat="server" Text="Especialidad:"></asp:Label>
                                                            <asp:DropDownList ID="cboEspecialidad" AutoPostBack="true" runat="server" OnSelectedIndexChanged="especialidadSeleccionada" CssClass="form-control" Width="180px"></asp:DropDownList>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">

                                                            <asp:Label ID="Label4" runat="server" Text="Medico"></asp:Label>
                                                            <asp:DropDownList ID="cboMedico" runat="server" CssClass="form-control" Width="180px"></asp:DropDownList><br />
                                                        </div>
                                                        <div class="col">
                                                            <asp:Label ID="Label2" runat="server" Text="Turno"></asp:Label>
                                                            <asp:DropDownList ID="cboTurno" runat="server" CssClass="form-control" Width="180px"></asp:DropDownList><br />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:TableCell>
                                        <asp:TableCell runat="server">

                                       </asp:TableCell>
                                        <asp:TableCell runat="server">
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col">

                                                        <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label><br />
                                                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control" Width="250px"></asp:TextBox><br />
                                                        <asp:Label ID="Label7" runat="server" Text="Descripcion de Malestar"></asp:Label><br />
                                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Width="250px" Height="120px" TextMode="MultiLine"></asp:TextBox><br />
                                                    </div>

                                                </div>
                                            </div>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                </asp:Table>

                                <hr />
                                <a runat="server" id="btnReservarCita" class="btn btn-primary" onserverclick="btnReservarCita_Click"><i class="fas fa-plus"></i>Reservar Cita</a><br />

                                <asp:Label ID="lblRpta" runat="server" Text=""></asp:Label>
                                <hr />

                                <asp:TextBox ID="txtDato" runat="server" Visible="False"></asp:TextBox><br />
                                <asp:TextBox ID="txtCodigo" runat="server" Visible="False"></asp:TextBox><br />
                                <asp:TextBox ID="txtEstado" Enabled="False" runat="server" Visible="False">En Proceso</asp:TextBox>
                                <asp:TextBox ID="txtEstadoPago" Enabled="False" runat="server" Visible="False">Pendiente</asp:TextBox>
                                <asp:TextBox ID="txtCodPago" Enabled="False" runat="server" Visible="False"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </asp:Panel>



</asp:Content>
