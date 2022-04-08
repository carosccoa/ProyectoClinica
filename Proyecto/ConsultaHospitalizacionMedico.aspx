<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMedico.Master" AutoEventWireup="true" CodeBehind="ConsultaHospitalizacionMedico.aspx.cs" Inherits="Proyecto.ConsultaHospitalizacionMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="pConsulta" runat="server" HorizontalAlign="Center">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h4 class="m-0 font-weight-bold text-primary">CONSULTA DE HOSPITALIZACIONES MÉDICAS</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Label ID="lblMedicoFijo" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Table ID="Table3" runat="server" HorizontalAlign="Left">
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">
                                    <asp:Label ID="Label5" runat="server" Text="Buscar:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    &nbsp&nbsp&nbsp
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:DropDownList ID="cboPrueba" CssClass="form-control" runat="server" Width="200px" OnSelectedIndexChanged="cboPrueba_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                   &nbsp&nbsp&nbsp
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:TextBox ID="txtDniPaciente" CssClass="form-control" runat="server" Visible="False" Width="200px" TextMode="Number" placeholder="Ingrese DNI Paciente"></asp:TextBox>
                                    <asp:DropDownList ID="cboPabellon" CssClass="form-control" runat="server" Visible="False" Width="200px"></asp:DropDownList>
                                    <asp:TextBox ID="txtHabitacion" CssClass="form-control" runat="server" Visible="False" Width="200px" TextMode="Number" placeholder="Ingrese Habitacion"></asp:TextBox>
                                    <asp:TextBox ID="txtFechaIngreso" CssClass="form-control" runat="server" Visible="False" Width="200px" TextMode="Date"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                   &nbsp&nbsp&nbsp
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <a runat="server" id="btnDniPaciente" class="btn btn-primary" onserverclick="btnDniPaciente_Click" visible="False" width="100px"><i class="fas fa-search"></i>  Filtrar</a>
                                    <a runat="server" id="btnPabellon" class="btn btn-primary" onserverclick="btnPabellon_Click" visible="False" width="100px"><i class="fas fa-search"></i>  Filtrar</a>
                                    <a runat="server" id="btnHabitacion" class="btn btn-primary" onserverclick="btnHabitacion_Click" visible="False" width="100px"><i class="fas fa-search"></i>  Filtrar</a>
                                    <a runat="server" id="btnFechaIngreso" class="btn btn-primary" onserverclick="btnFechaIngreso_Click" visible="False" width="100px"><i class="fas fa-search"></i>  Filtrar</a>
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <a runat="server" id="btnBusquedaCompleta" class="btn btn-secondary" onserverclick="btnBusquedaCompleta_Click"><i class="fas fa-list-ul"></i>  Listado Completo</a>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <br />
                        <hr />
                        <h5>RESULTADO DE BUSQUEDA</h5>
                        <asp:GridView ID="gvListaHospitalizacion" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" BorderStyle="Outset">
                            <Columns>
                                <asp:BoundField DataField="idHospitalizacion" HeaderText="ID" />
                                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Habitacion" HeaderText="Habitacion" />
                                <asp:BoundField DataField="Enfermero" HeaderText="Enfermero" />
                                <asp:BoundField DataField="Diagnostico" HeaderText="Diagnostico" />
                                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                                <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" DataFormatString="{0:d}" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkEditar" runat="server" CssClass="btn btn-outline-primary" OnClick="lkEditar_Click"><i class="far fa-edit"></i>  Editar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pModificar" runat="server" Visible="false" HorizontalAlign="Center">
            <div class="container">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-7 d-none d-lg-block bg-ConsultaCitaMedico-image"></div>
                            <div class="col-lg-5">
                                <br />
                                <h2>HOSPITALIZACIÓN</h2>
                                <hr />
                                <table>
                                    <tr>
                                        <td class="col-12" colspan="2">
                                            <asp:Label ID="Label3" runat="server" Text="Paciente"></asp:Label>
                                            <asp:TextBox ID="txtPacienteE" CssClass="form-control" runat="server" Width="360px" Enabled="false"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col-2">
                                            <asp:Label ID="Label4" runat="server" Text="Habitacion"></asp:Label>
                                            <asp:TextBox ID="txtHabitacionE" CssClass="form-control" runat="server" Width="135px" Enabled="false"></asp:TextBox>
                                            <br />
                                        </td>
                                        <td class="col-10" colspan="2">
                                            <asp:Label ID="Label8" runat="server" Text="Enfermero"></asp:Label>
                                            <asp:TextBox ID="txtEnfermeroE" CssClass="form-control" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col-12" colspan="2">
                                            <asp:Label ID="Label10" runat="server" Text="Diagnostico"></asp:Label>
                                            <asp:TextBox ID="txtDiagnosticoE" CssClass="form-control" runat="server" Width="360px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col-12" colspan="2">
                                            <asp:Label ID="Label11" runat="server" Text="Tratamiento"></asp:Label>
                                            <asp:TextBox ID="txtTratamientoE" CssClass="form-control" runat="server" Width="360px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col-2">
                                            <asp:Label ID="Label7" runat="server" Text="Fecha de Ingreso"></asp:Label>
                                            <asp:TextBox ID="txtFechaIngresoE" CssClass="form-control" runat="server" Width="135px" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td class="col-10" colspan="2">
                                            <asp:Label ID="Label12" runat="server" Text="Fecha de Salida"></asp:Label>
                                            <asp:TextBox ID="txtFechaSalidaE" CssClass="form-control" runat="server" Width="200px" TextMode="Date"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <a runat="server" id="btnActualizar" class="btn btn-primary" onserverclick="btnActualizar_Click"><i class="fas fa-save"></i>  Guardar</a>
                                &nbsp&nbsp&nbsp
                                <a runat="server" id="btnCancelar" class="btn btn-secondary" onserverclick="btnCancelar_Click"><i class="fas fa-arrow-circle-left"></i>  Regresar</a>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="ID" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtIdE" CssClass="form-control" runat="server" Width="180px" Enabled="false" TextMode="Number" Visible="false"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text="Estado" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtEstadoE" CssClass="form-control" runat="server" Width="" Enabled="false" Visible="false"></asp:TextBox>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

</asp:Content>


