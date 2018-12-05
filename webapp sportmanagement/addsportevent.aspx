<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addsportevent.aspx.cs" Inherits="webapp_sportmanagement.addsportevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SPORTS EVENT PAGE</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

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

                    <h3 class="text-center mx-auto d-block align-middle  ">SPORTS PAGE</h3>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="home" runat="server" class="btn btn-outline-success float-sm-right " Text="HOME" OnClick="home_Click" CausesValidation="False" />
                </div>
            </div>
            <br />
        </div>
        <div class="container-fluid ">
            <br />
            <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="container-fluid ">

                    <!-- Boxes -->
                    <div class="card-deck">
                        <div class="card invisible"></div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">ADD SPORT</h5>
                               
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="addsportviewbutton" class="btn btn-block btn-light" runat="server" Text="ADD" OnClick="addsport_Click" />
                            </div>
                        </div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">REMOVE SPORT</h5>
                                
                            </div>
                            <div class="card-footer">
                               <asp:Button ID="removesportviewbutton" class="btn btn-block btn-light" runat="server" Text="REMOVE" OnClick="removesport_Click" />
                            </div>
                        </div>

                       
                        <div class="card invisible"></div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="container-fluid ">
                <div class="card-group-vertical">
                <div class="row row-centered card-body">

                    <div class="col col-centered bg-dark text-center text-white ">
                        <div class="card-body">
                            <asp:Label ID="SN" class="card-text text-center text-white d-inline" runat="server" Text="SPORT NAME"></asp:Label>

                            <asp:TextBox ID="TB1" class="card-text text-center d-inline" Height="50px" Width="45%" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="SPORT NAME REQUIRED*" ControlToValidate="TB1" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                    </div>
                    <div class="col col-centered bg-dark text-center text-white ">
                        <div class="card-body">
                            <asp:Label ID="SD" class="card-text text-center text-white d-inline" runat="server" Text="SPORT DESCRIPTION"></asp:Label>
                            <asp:TextBox ID="TB2" class="card-text text-center d-inline" Height="50px" Width="45%" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="SPORT DESC REQUIRED*" ControlToValidate="TB2" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col col-centered bg-dark text-center text-white ">
                        <div class="card-body">
                            <asp:Label ID="SM" class="card-text text-center text-white d-inline" runat="server" Text="MAX No. PLAYERS"></asp:Label>
                            <asp:TextBox ID="TB3" class="card-text text-center d-inline" Height="50px" Width="45%" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="MAX No. PLAYERS REQUIRED*" ControlToValidate="TB3" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                
                <div class="card-body text-center bg-transparent">
                    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="ADD SPORT EVENT" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="BACK" OnClick="Backsportview_Click" CausesValidation="False" />
                </div>

                    <br />

                
            </div>
                    </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical">


                <div class="card text-white text-center  bg-dark">
                    <div class="card-body  d-inline">

                        <h3>REMOVE SPORT</h3>
                        <br />
                        <asp:GridView ID="GridView3" runat="server" class="mx-auto" Width="90%" CellPadding="4" OnRowDeleting="GridView3_RowDeleting" DataKeyNames="sportid">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <div class="card text-white text-center  bg-transparent">


                    <asp:Button ID="finish_rvm_sport" class="btn btn-block btn-success" runat="server" Text="FINISH" OnClick="Button3_Click" />
                   


                </div>
            </div>
        </div>
            </asp:View>
        </asp:MultiView>
            
        </div>
        
    </form>
</body>
</html>
