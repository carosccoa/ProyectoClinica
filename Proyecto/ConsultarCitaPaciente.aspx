<%@ Page Title="" Language="C#" MasterPageFile="~/HomePaciente.Master" AutoEventWireup="true" CodeBehind="ConsultarCitaPaciente.aspx.cs" Inherits="Proyecto.ConsultarCitaPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <h2>Consultar Cita Medica  </h2>

        <hr />
        <br />
        <asp:Table ID="Table3" runat="server" HorizontalAlign="Center">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <div class="row g-3">
                        <div class="col-3">

                            <asp:TextBox ID="txtDato" runat="server" Width="250px" placeholder="Ingrese su DNI" CssClass="form-control"></asp:TextBox>
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


    <asp:Panel ID="ActualizarVisible" runat="server" HorizontalAlign="Center">

        <hr />


        <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">


            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Fecha inicial"></asp:Label><br />
                    <asp:TextBox ID="txtFechaIni" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

                </asp:TableCell>
                <asp:TableCell runat="server">
                    
                    </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="Label4" runat="server" Text="Fecha final"></asp:Label>
                    <asp:TextBox ID="txtFechaFinal" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <br />
                      <a runat="server" id="btnFiltro" class="btn btn-primary" onserverclick="btnFiltro_Click"><i class="fas fa-sort-amount-down-alt"></i>Buscar</a>
                      </asp:TableCell>

            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <br />

       
     <asp:GridView ID="gvSalida" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered primary" BorderStyle="Outset">

        <Columns>
            
            
            <asp:BoundField  DataField="Codigo Paciente" HeaderText="Codigo " />
            <asp:BoundField DataField="DNIPaciente" HeaderText="Dni" />
            <asp:BoundField DataField="nombrePaciente" HeaderText="Datos del Paciente" />
            <asp:BoundField DataField="nombreTurno" HeaderText="Turno" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}"/>
           
        </Columns>

</asp:GridView>




   

</asp:Content>