<%@ Page Title="" Language="C#" MasterPageFile="~/HomeAdministrador.Master" AutoEventWireup="true" CodeBehind="AdministraHospitalización.aspx.cs" Inherits="Proyecto.AdministraHospitalización" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
  
    <asp:Panel ID="TablaListado" runat="server" HorizontalAlign="Center">
        
        <hr />

                <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h5 class="m-0 font-weight-bold text-primary">Administrar Hospitalizacion</h5>
            </div>
            <div class="card-body">
                <div class="table-responsive">

        <asp:GridView ID="gvSalida" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered primary" BorderStyle="Outset">

            <Columns>

                <asp:BoundField DataField="idHospitalizacion" HeaderText="Codigo" />
                  <asp:BoundField DataField="nombrePacienteH" HeaderText="Paciente" />
                <asp:BoundField DataField="Enfermero" HeaderText="Enfermero" />
                <asp:BoundField DataField="pabellonHabitacion" HeaderText="Pabellon" />
                <asp:BoundField DataField="numeroHabitacion" HeaderText="Habitacion" />
                <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="areaMedica" HeaderText="Area" />


                <asp:BoundField DataField="estadoHabitacion" HeaderText="Estado de Habitacion" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-primary" OnClick="lkbModificar_Click"><i class="far fa-edit"></i> Editar</asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
                    </div>
                </div>
                    </div>
        
    </asp:Panel>

    <asp:Panel ID="ActualizarVisible" runat="server" HorizontalAlign="Center">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-RegistraReservacion-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Actualizar Hospitalización</h1>
                            </div>

                            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">


                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label6" runat="server" Text="Paciente"></asp:Label>
                                        <asp:TextBox ID="txtCodigo" Width="200px" CssClass="form-control" runat="server" Enabled="False" Visible="false"></asp:TextBox>
                                             <asp:TextBox ID="txtPaciente" Width="200px" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        <br />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                    
                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label1" runat="server" Text="Enfermero"></asp:Label>
                                        <asp:TextBox ID="txtEnfermero" CssClass="form-control" runat="server"></asp:TextBox><br />
                                    </asp:TableCell>
                                </asp:TableRow>






                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label4" runat="server" Text="Pabellon"></asp:Label>
                                        <asp:TextBox ID="txtPabellon" CssClass="form-control" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                        <br />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                    
                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label10" runat="server" Text="Pabellon"></asp:Label>
                                        <asp:DropDownList ID="cboPabellon" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="seleccionPabellon"></asp:DropDownList><br />
                                    </asp:TableCell>
                                </asp:TableRow>



                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label3" runat="server" Text="Numero de Habitacion"></asp:Label>
                                        <asp:TextBox ID="txtHabitacion" runat="server" Width="200px" CssClass="form-control" Enabled="False"></asp:TextBox>
                                        <br />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                    
                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label9" runat="server" Text="Numero de Habitacion"></asp:Label>
                                        <asp:DropDownList ID="cboNumHabitacion" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        <br />
                                    </asp:TableCell>
                                </asp:TableRow>





                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label7" runat="server" Text="Especialidad"></asp:Label>
                                        <asp:TextBox ID="txtEspe" Width="200px" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                        <br />
                                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                    
                    </asp:TableCell>
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label2" runat="server" Text="Area Medica"></asp:Label>
                                        <asp:TextBox ID="txtAreaM" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                        <br />
                                    </asp:TableCell>
                                </asp:TableRow>


                                <asp:TableRow runat="server">
                                    <asp:TableCell>
                                        <asp:Label ID="Label5" runat="server" Text="Estado" Visible="False"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtEstadoOcupado" runat="server" Visible="False" Height="30px">Ocupado</asp:TextBox>
                                    </asp:TableCell>

                                </asp:TableRow>

                            </asp:Table>
                                                                    <hr />

                                        <a id="btnActualizar" class="btn btn-primary" runat="server" onserverclick="btnActualizar_Click"><i class="far fa-edit"></i>Actualizar</a>
                                        <a id="btnCancelar" class="btn btn-secondary" runat="server" onserverclick="btnCancelar_Click"><i class="fas fa-arrow-circle-left"></i>Cancelar</a>
                                        <hr />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>




</asp:Content>