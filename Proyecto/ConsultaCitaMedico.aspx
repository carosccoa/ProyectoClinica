<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMedico.Master" AutoEventWireup="true" CodeBehind="ConsultaCitaMedico.aspx.cs" Inherits="Proyecto.ConsultaCitaMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pConsulta" runat="server" HorizontalAlign="Center">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h4 class="m-0 font-weight-bold text-primary">CONSULTA DE CITAS MÉDICAS</h4>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Label ID="lblMedicoFijo" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Table ID="Table1" runat="server" HorizontalAlign="Left">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="Label3" runat="server" Text="Buscar:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                    &nbsp&nbsp
                                </asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Center">
                                <asp:TextBox ID="txtDni" CssClass="form-control" runat="server" TextMode="Number" Width="200px" placeholder="Ingrese DNI Paciente"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                    &nbsp&nbsp&nbsp
                                </asp:TableCell>
                            <asp:TableCell runat="server">
                                <a runat="server" id="btnDni" class="btn btn-primary" onserverclick="btnDni_Click" validationgroup="validacionDni" width="100px"><i class="fas fa-search"></i>  Filtrar</a>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                </asp:TableCell>
                            <asp:TableCell runat="server">
                                <a runat="server" id="btnCitasActuales" class="btn btn-success" onserverclick="btnCitasActuales_ServerClick"><i class="fas fa-list-ul"></i>  Citas de Hoy</a>
                                &nbsp&nbsp&nbsp
                                    <a runat="server" id="btnCitasProximas" class="btn btn-secondary" onserverclick="btnCitasProximas_ServerClick"><i class="fas fa-list-ul"></i>  Citas Proximas</a>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                    <hr />
                    <h5>RESULTADO DE BUSQUEDA</h5>
                    <asp:GridView ID="gvListaCita" runat="server" CssClass="table table-bordered" BorderStyle="Outset" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="idCita" HeaderText="Cita" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DNIPaciente" HeaderText="DNI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="paciente" HeaderText="Paciente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="especialidad" HeaderText="Especialidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha de Cita" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                            <h2>HISTORIA CLINICA</h2>
                            <hr />
                            <table>
                                <tr>
                                    <td class="col-4">
                                        <asp:Label ID="Label9" runat="server" Text="DNI"></asp:Label>
                                        <asp:TextBox ID="txtDNIE" CssClass="form-control" runat="server" Width="105px" Enabled="false"></asp:TextBox>
                                        <br />
                                    </td>
                                    <td class="col-8" colspan="2">
                                        <asp:Label ID="Label1" runat="server" Text="Paciente"></asp:Label>
                                        <asp:TextBox ID="txtPacienteE" CssClass="form-control" runat="server" Width="245px" Enabled="false"></asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-12" colspan="2">
                                        <asp:Label ID="Label10" runat="server" Text="Diagnostico"></asp:Label>
                                        <asp:TextBox ID="txtResultadoCita" CssClass="form-control" runat="server" Width="380px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-12" colspan="2">
                                        <asp:Label ID="Label11" runat="server" Text="Medicacion"></asp:Label>
                                        <asp:TextBox ID="txtMedicacion" CssClass="form-control" runat="server" Width="380px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <a runat="server" id="btnActualizar" class="btn btn-primary" onserverclick="btnActualizar_ServerClick"><i class="fas fa-save"></i>  Guardar</a>
                            &nbsp&nbsp           
                            <a runat="server" id="btnCancelar" class="btn btn-secondary" onserverclick="btnCancelar_ServerClick"><i class="fas fa-arrow-circle-left"></i>  Regresar</a>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="ID" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtIdE" CssClass="form-control" runat="server" Width="" Enabled="false" TextMode="Number" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server" Text="Estado" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtEstadoE" CssClass="form-control" runat="server" Width="" Enabled="false" Visible="false"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>


