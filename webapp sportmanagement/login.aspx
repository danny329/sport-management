<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="webapp_sportmanagement.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</head>
<body class="bg-transparent text-dark">
    <form id="form1" runat="server">
        <div class="container shadow mb-2 bg-transparent">
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <img src="images/csmslogo.png" class="mx-auto d-block align-content-sm-center rounded-circle " alt="CSMS" height="60" width="60" />
                </div>
                <div class="col-sm-4">

                    <h3 class="text-center mx-auto d-block align-middle  ">ADMIN LOGIN</h3>
                </div>
                <div class="col-sm-4">
                    <a href="index.aspx" id="home" class="btn btn-outline-success float-sm-right ">HOME</a>
                </div>
            </div>
            <br />
        </div>

        <div id="loginbox" class="container">
           
            <div class="row w-50 mx-auto">
                

                <div class="col-sm" >
                    <div class="mx-auto d-block">
                         <br />
                        <asp:Label ID="Label1" class="mx-sm-5" runat="server" Text="USERNAME"></asp:Label>
                        <asp:TextBox ID="TextBox1" class="mx-5 py-2 border border-primary rounded h-100" runat="server"></asp:TextBox>
                       
                    </div> <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  class="float-right"  runat="server" ErrorMessage="USERNAME REQUIRED *" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <div class="mx-auto d-block">
                        <asp:Label ID="Label2" class="mx-sm-5" runat="server" Text="PASSWORD"></asp:Label>
                        <asp:TextBox ID="TextBox2" class="mx-5 py-2  border border-primary rounded h-100" runat="server" TextMode="Password"></asp:TextBox>
                       
                    </div> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="float-right" runat="server" ErrorMessage="PASSWORD REQUIRED*" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br/>
                     <div class=" mx-auto d-block">
                         <asp:Button ID="Button1" class=" mx-auto d-block btn btn-outline-success btn-block w-25" runat="server" Text="login" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
