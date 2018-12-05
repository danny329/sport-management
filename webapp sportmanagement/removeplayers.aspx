<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="removeplayers.aspx.cs" Inherits="webapp_sportmanagement.removeplayers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REMOVE PLAYER FROM TOURNAMENT</title>
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

                    <h4 class="text-center mx-auto d-block align-middle  ">REMOVE PLAYER FROM TOURNAMENT</h4>
                </div>
                <div class="col-sm-4">
                      <asp:Button ID="home" runat="server" class="btn btn-outline-success float-sm-right " Text="HOME" OnClick="home_Click" CausesValidation="False" />
                </div>
            </div>
            <br />
        </div>
        <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical">


                <div class="card text-white text-center  bg-dark">
                    <div class="card-body  d-inline">

                        <asp:Label ID="Label1" runat="server" Text="TOURNAMENT NAME" Height="10" Width="200"></asp:Label>
                        <asp:DropDownList ID="DDLN" Width="350px" AutoPostBack="True" Height="50px" runat="server" BackColor="Black" ForeColor="White" OnSelectedIndexChanged="DDL1_SelectedIndexChanged"></asp:DropDownList>

                    </div>
                </div>
                <div class="card text-white text-center  bg-dark">
                    <div class="card-body  d-inline">
                        <asp:Label ID="Label23" runat="server" Text="STUDENT NAME"></asp:Label>
                        <asp:DropDownList ID="DDLN1" Width="350px" AutoPostBack="True" Height="50px" runat="server" BackColor="Black" ForeColor="White" OnSelectedIndexChanged="DDL2_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </div>
                <div class="card text-white text-center  bg-dark">
                    <div class="card-body  d-inline">
                        <h3>PLEASE REMOVE THE SELECTED PARTICIPANT FROM AN EVENT</h3>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="90%" class="mx-auto" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="sportid">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />

                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" Width="90%" class="mx-auto" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="token">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />

                            </Columns>
                        </asp:GridView>
                        <br />
                    </div>
                </div>
                

                <div class="card-body  d-inline">
                    <asp:Button ID="Button1" class="btn btn-block btn-primary" runat="server" Text="FINISH" OnClick="Button1_Click" />


                </div>
            </div>
        </div>


    </form>
</body>
</html>
