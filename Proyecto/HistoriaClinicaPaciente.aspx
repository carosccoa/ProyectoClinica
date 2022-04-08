<%@ Page Title="" Language="C#" MasterPageFile="~/HomePaciente.Master" AutoEventWireup="true" CodeBehind="HistoriaClinicaPaciente.aspx.cs" Inherits="Proyecto.HistoriaClinicaPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="TablaListado" runat="server" HorizontalAlign="Center">
        <asp:TextBox ID="txtDato" runat="server" Visible="false"></asp:TextBox>
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h5 class="m-0 font-weight-bold text-primary">Listado de Historial Clínico</h5>
            </div>
            <div class="card-body">
                <div class="table-responsive">

                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="Label4" runat="server" Text="Seleccione Filtro:"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList CssClass="form-control" ID="cboFiltro" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <a id="A1" class="btn btn-primary" runat="server" onserverclick="btnFiltro_Click" ><i class="fas fa-stream"></i>Filtrar</a>
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <a id="A2" class="btn btn-secondary" runat="server" onserverclick="btnFiltroCompleto_Click" ><i class="fas fa-list-ol"></i>Listar Todo</a>

                        </div>

                    </div>
                    <hr />
                    <br />
                    <asp:GridView ID="gvSalida" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" BorderStyle="Outset">

                        <Columns>

                            <asp:BoundField DataField="resultadoCita" HeaderText="Diagnostico" />
                            <asp:BoundField DataField="medicacion" HeaderText="Medicación" />
                            <asp:BoundField DataField="Medico" HeaderText="Medico" />
                            <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}" />


                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>

                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-outline-primary" OnClick="RealizarPago_Click"><i class="fas fa-eye"></i>Ver Historial</asp:LinkButton>

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

                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-CodigoValido-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Historia Clínica </h1>
                            </div>
                            <asp:Table ID="Table2" runat="server" HorizontalAlign="Center" Width="591px">
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <div class="row">
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col">

                                                        <asp:Label ID="Label6" runat="server" Text=" Diagnostico"></asp:Label><br />
                                                        <asp:TextBox ID="txtDignostico" runat="server" Enabled="false" Width="200px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                    <div class="col">

                                                        <asp:Label ID="Label1" runat="server" Text="Medicacion"></asp:Label>
                                                        <asp:TextBox ID="txtMedicacion" runat="server" Enabled="False" Width="200px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox><br />

                                                    </div>


                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:Label ID="Label2" runat="server" Text="Medico"></asp:Label>
                                                        <asp:TextBox ID="txtMedico" runat="server" Enabled="False" Width="140px" CssClass="form-control"></asp:TextBox><br />
                                                        <br />
                                                    </div>
                                                    <div class="col">

                                                        <asp:Label ID="Label7" runat="server" Text="Especialidad"></asp:Label>
                                                        <asp:TextBox ID="txtEspecialidad" runat="server" Enabled="False" Width="140px" CssClass="form-control"></asp:TextBox><br />
                                                        <br />
                                                    </div>
                                                    <div class="col">
                                                        <asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label>
                                                        <asp:TextBox ID="txtFecha" runat="server" Enabled="False" Width="140px" CssClass="form-control"></asp:TextBox><br />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <hr />

                                                    <div class="text-center">
                                                        <a class="small" href="HistoriaClinicaPaciente.aspx">Volver</a>
                                                    </div>
                                                    <br />
                                                    <hr />

                                                </div>


                                            </div>
                                        </div>
                                    </asp:TableCell>

                                </asp:TableRow>

                            </asp:Table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>


</asp:Content>
