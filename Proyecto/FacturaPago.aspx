<%@ Page Title="" Language="C#" MasterPageFile="~/HomePaciente.Master" AutoEventWireup="true" CodeBehind="FacturaPago.aspx.cs" Inherits="Proyecto.FacturaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <hr />
    <h2>REPORTE DE VERIFICACIÓN </h2>
    <hr />

    <asp:TextBox ID="txtDato" runat="server" Visible="false"></asp:TextBox>
    <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-Factura-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">VERIFICACION DE CÓDIGO</h1>
                            </div>

                            <asp:Label ID="Label1" runat="server" Text="Estimad@"></asp:Label>
                            <center>
                         <asp:TextBox ID="txtPaciente"  CssClass="form-control" Width="270px" runat="server" Enabled="false"></asp:TextBox>
                         
                            </center>
                            <br />
                            <p>Por medio del presente reporte,se le informa lo siguiente: </p>

                            <p>El código del pago realizado, por la reservación de su cita médica ha sido de manera satisfactoria. Así mismo informarle que se debe acercar a la clínica para que se pueda llevar a cabo la cita Médica según la fecha y el turno seleccionado. </p>

                            <p>Atentamente </p>
                            <p>Policlínico Villa María del Triunfo </p>

                            <hr />

                            <div class="text-center">
                                <a class="small" href="ConsultarReservacionCitaPaciente.aspx">Volver</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
