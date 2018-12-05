<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewscoreboard.aspx.cs" Inherits="webapp_sportmanagement.viewscoreboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>VIEW SCOREBOARD</title>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</head>
<body class="bg-dark text-white">
  <form id="form1" runat="server">
        
      <div class="container shadow mb-2 bg-transparent">
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <img src="images/csmslogo.png" class="mx-auto d-block align-content-sm-center rounded-circle " alt="CSMS" height="60" width="60" />
                </div>
                <div class="col-sm-4">

                    <h2 class="text-center mx-auto d-block align-middle  ">VIEW SCOREBOARD</h2>
                </div>
                <div class="col-sm-4">
                    <a href="index.aspx" id="home" class="btn btn-outline-success float-sm-right ">HOME</a>
                </div>
            </div>
            <br />
        </div>
        <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical">

                <div class="card bg-dark ">
                   
                    <div class="card-body text-center ">
                          <asp:Label ID="Label1" runat="server" class=" text-white" Text="TOURNAMENT NAME" Height="10" Width="200"></asp:Label>
                   <asp:DropDownList ID="Tour" Width="50%" AutoPostBack="True"  Height="50px" runat="server" OnSelectedIndexChanged="Tour_SelectedIndexChanged" BackColor="Black" ForeColor="White"></asp:DropDownList>
                  
                    </div>
                 </div>
                  
                    
                <div class="card bg-dark ">
                    <div class="card-body text-center ">
                       <asp:Label ID="Label21" runat="server" class=" text-white"  Text="SPORT NAME"></asp:Label>
                       <asp:DropDownList ID="DDL2" Width="350px" AutoPostBack="True" Height="50px" runat="server" OnSelectedIndexChanged="DDL2_SelectedIndexChanged" BackColor="Black" ForeColor="White"></asp:DropDownList>
                   
                    </div>
                 </div> 
                   
                   

         
                 <br />
                        <asp:GridView ID="GridView1" class="mx-auto text-center text-white" runat="server" Width="100%">
                         
                        </asp:GridView>
                         <asp:GridView ID="GridView2" class="mx-auto text-center text-white" runat="server" Width="100%">
                          
                        </asp:GridView>
                   
                <br />
                    
               
                </div>
           
        </div>

    </form>
</body>
</html>
