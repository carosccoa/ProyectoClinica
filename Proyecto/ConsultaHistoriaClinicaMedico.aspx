<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMedico.Master" AutoEventWireup="true" CodeBehind="ConsultaHistoriaClinicaMedico.aspx.cs" Inherits="Proyecto.ConsultaHistoriaClinicaMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pConsulta" runat="server" HorizontalAlign="Center">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h4 class="m-0 font-weight-bold text-primary">CONSULTA DE HISTORIAS CLÍNICAS</h4>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Label ID="lblMedicoFijo" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Table ID="Table2" runat="server" HorizontalAlign="Left">
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
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                </asp:TableCell>
                            <asp:TableCell runat="server">
                                <a runat="server" id="btnListaHC" class="btn btn-secondary" onserverclick="btnListaHC_ServerClick"><i class="fas fa-list-ul"></i>  Listado Completo</a>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                    <hr />
                    <h5>RESULTADO DE BUSQUEDA</h5>
                    <asp:GridView ID="gvListaHC" runat="server" CssClass="table table-bordered" BorderStyle="Outset" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="idHistoriaClinica" HeaderText="HC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="paciente" HeaderText="Paciente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="resultadoCita" HeaderText="Diagnostico" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="medicacion" HeaderText="Medicacion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>


