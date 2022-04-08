<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMedico.Master" AutoEventWireup="true" CodeBehind="HomeMedico.aspx.cs" Inherits="Proyecto.HomeMedico1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <style>

        .slider{
  width: 800px;
  height: 500px;
  border-radius: 10px;
  overflow: hidden;
}

.slides{
  width: 500%;
  height: 500px;
  display: flex;
}

.slides input{
  display: none;
}

.slide{
  width: 20%;
  transition: 2s;
}

.slide img{
  width: 800px;
  height: 500px;
}

/*css for manual slide navigation*/

.navigation-manual{
  position: absolute;
  width: 800px;
  margin-top: -40px;
  display: flex;
  justify-content: center;
}

.manual-btn{
  border: 2px solid #4e73df;
  padding: 5px;
  border-radius: 10px;
  cursor: pointer;
  transition: 1s;
}

.manual-btn:not(:last-child){
  margin-right: 40px;
}

.manual-btn:hover{
  background: #4e73df;
}

#radio1:checked ~ .first{
  margin-left: 0;
}

#radio2:checked ~ .first{
  margin-left: -20%;
}

#radio3:checked ~ .first{
  margin-left: -40%;
}

#radio4:checked ~ .first{
  margin-left: -60%;
}

/*css for automatic navigation*/

.navigation-auto{
  position: absolute;
  display: flex;
  width: 800px;
  justify-content: center;
  margin-top: 460px;
}

.navigation-auto div{
  border: 2px solid #4e73df;
  padding: 5px;
  border-radius: 10px;
  transition: 1s;
}

.navigation-auto div:not(:last-child){
  margin-right: 40px;
}

#radio1:checked ~ .navigation-auto .auto-btn1{
  background: #4e73df;
}

#radio2:checked ~ .navigation-auto .auto-btn2{
  background: #4e73df;
}

#radio3:checked ~ .navigation-auto .auto-btn3{
  background: #4e73df;
}

#radio4:checked ~ .navigation-auto .auto-btn4{
  background: #4e73df;
}

#cardd {position: absolute; z-index:10;}
    </style>

     <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6  class="m-0 font-weight-bold text-primary text-center">BIENVENIDO AL SISTEMA DE LA CLINICA VILLAMARIA DEL TRIUNFO</h6>
                                </div>
                                <div class="card-body">
                                    
                                   <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">



                                       <!---->

                                       <!--image slider start-->
    <div class="slider">
      <div class="slides">
        <!--radio buttons start-->
        <input type="radio" name="radio-btn" id="radio1">
        <input type="radio" name="radio-btn" id="radio2">
        <input type="radio" name="radio-btn" id="radio3">
        <input type="radio" name="radio-btn" id="radio4">
        <!--radio buttons end-->
        <!--slide images start-->
        <div class="slide first">
          <img src="https://cdn.pixabay.com/photo/2014/12/10/20/48/medic-563425_960_720.jpg" alt="">
        </div>
        <div class="slide">
          <img src="https://cdn.pixabay.com/photo/2014/12/10/20/48/laboratory-563423_960_720.jpg" alt="">
        </div>
        <div class="slide">
          <img src="https://media.istockphoto.com/photos/doctors-wear-protective-suits-picture-id1221952347?b=1&k=6&m=1221952347&s=170667a&w=0&h=5eeFBSzgElE7CoNcpsVdjcjit5AGT78kwf5gTN4RzZQ=" alt="">
        </div>
        <div class="slide">
          <img src="https://cdn.pixabay.com/photo/2016/11/06/10/35/hospital-1802680_960_720.jpg" alt="">
        </div>
        <!--slide images end-->
        <!--automatic navigation start-->
        <div class="navigation-auto">
          <div class="auto-btn1"></div>
          <div class="auto-btn2"></div>
          <div class="auto-btn3"></div>
          <div class="auto-btn4"></div>
        </div>
        <!--automatic navigation end-->
      </div>
      <!--manual navigation start-->
      <div class="navigation-manual">
        <label for="radio1" class="manual-btn"></label>
        <label for="radio2" class="manual-btn"></label>
        <label for="radio3" class="manual-btn"></label>
        <label for="radio4" class="manual-btn"></label>
      </div>
      <!--manual navigation end-->
    </div>
    <!--image slider end-->

    <script type="text/javascript">
    var counter = 1;
    setInterval(function(){
      document.getElementById('radio' + counter).checked = true;
      counter++;
      if(counter > 4){
        counter = 1;
      }
    }, 5000);
    </script>

                                       <!---->
<div style="position: absolute; z-index:10;width: 18rem; right:-920px; top:-2px" class="card" >
 
    <div class="card-body">
        <img  style="height:300px; width:250px; " src="https://image.freepik.com/vector-gratis/gente-concepto-manual-usuario-empresarial-alrededor-lectura-libros-manual-usuario-plantilla_25147-581.jpg" class="card-img-top" alt="...">
   <br /><br />
        <h5 class="card-title">Guia de Usuario</h5>
    <p class="card-text">Indicaciones de usabilidad del sistema</p>
    <center>
<a href="ManualMedico.pdf" download="Manual.pdf" class="btn btn-primary">Descargar</a>
    </center>
  </div>
</div>


                                </div>
                            </div>
           </div>


 
</asp:Content>
