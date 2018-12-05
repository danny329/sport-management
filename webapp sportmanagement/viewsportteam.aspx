<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewsportteam.aspx.cs" Inherits="webapp_sportmanagement.viewsportteam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>view sports team</title>
       <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--<link rel="stylesheet" href="assets/css/main.css" type="text/css" />-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="container shadow mb-2 bg-transparent">
            <br />
            <div class="row">
                <div class="col-sm-4">
                <img src="images/csmslogo.png" class="mx-auto d-block align-content-sm-center rounded-circle " alt="CSMS" height="60" width="60" />
                </div>
             <div class="col-sm-4">
                
                <h3 class="text-center mx-auto d-block align-middle text-white ">VIEW SPORT TEAM</h3>
                   </div>
             <div class="col-sm-4">
                 <a href="index.aspx" id="home"  class="btn btn-outline-success mx-5 float-sm-right ">HOME</a>
            </div>
            </div>
            <br />
        </div>
        <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical text-white">

                <div class="card bg-dark ">
                    <div class="card-body text-center ">
                        <asp:Label ID="Label25" runat="server" Text="SPORT NAME" Height="10" Width="200"></asp:Label>
                        <asp:DropDownList ID="DDL25"  Width="30%" AutoPostBack="True" Height="50px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="DDL25_SelectedIndexChanged" >
                        </asp:DropDownList>
                       
                    </div>
                </div>
               
               
                    <div class="card bg-dark text-center text-white">
                         <br />

                        <h3>SELECTED STUDENTS</h3>
                        <br />

                        <asp:GridView ID="GridView1" runat="server"  DataKeyNames="studentid" class="mx-auto" Width="90%" CellSpacing="2" CellPadding="4"  >
                      
                         </asp:GridView>
                        
                      <br /> 
                </div>
                <br />
                    
                </div>
        </div>
       
    </form>
</body>
</html>
