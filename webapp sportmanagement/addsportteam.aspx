<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addsportteam.aspx.cs" Inherits="webapp_sportmanagement.addsportteam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>sports team</title>
       <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--<link rel="stylesheet" href="assets/css/main.css" type="text/css" />-->
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
                
                <h3 class="text-center mx-auto d-block align-middle text-white ">SPORT TEAM</h3>
                   </div>
             <div class="col-sm-4">
                 <asp:Button ID="home" runat="server" class="btn btn-outline-success float-sm-right " Text="HOME" OnClick="home_Click" CausesValidation="False" />
            </div>
            </div>
            <br />
        </div>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="container-fluid ">

                    <!-- Boxes -->
                    <div class="card-deck">
                        <div class="card invisible"></div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">ADD TEAM</h5>

                            </div>
                            <div class="card-footer">
                                <asp:Button ID="addteamviewbutton" class="btn btn-block btn-light" runat="server" Text="ADD" OnClick="addteam_Click" />
                            </div>
                        </div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">REMOVE TEAM</h5>

                            </div>
                            <div class="card-footer">
                                <asp:Button ID="removeteamviewbutton" class="btn btn-block btn-light" runat="server" Text="REMOVE" OnClick="removeteam_Click" />
                            </div>
                        </div>
                         <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">PAYMENT LIST</h5>

                            </div>
                            <div class="card-footer">
                                <asp:Button ID="paymentpage" class="btn btn-block btn-light" runat="server" Text="PAID LIST" OnClick="paymentpage_Click" />
                            </div>
                        </div>

                        <div class="card invisible"></div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="container-fluid bg-secondary">
                    <br />
                    <div class="card-group-vertical text-white">

                        <div class="card bg-dark ">
                            <div class="card-body text-center ">
                                <asp:Label ID="Label25" runat="server" Text="SPORT NAME" Height="10" Width="200"></asp:Label>
                                <asp:DropDownList ID="DDL25" Width="30%" AutoPostBack="True" Height="50px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="DDL25_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ErrorMessage="Sport event selection required*" ControlToValidate="DDL25" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="card bg-dark text-center text-white">
                            <br />

                            <h3>SELECT STUDENT</h3>
                            <br />

                            <asp:GridView ID="GridView1" runat="server" DataKeyNames="studentid" class="mx-auto" Width="90%" CellSpacing="2" CellPadding="4">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>

                            <br />
                        </div>

                        <div class="card-body text-center ">
                            <asp:Button ID="Button1" class="btn btn-block btn-warning" runat="server" Text="CONFIRM" OnClick="Button1_Click" />

                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="card-group-vertical text-white">

                <div class="card bg-dark ">
                    <div class="card-body text-center ">
                        <asp:Label ID="Label26" runat="server" Text="SPORT NAME" Height="10" Width="200"></asp:Label>
                        <asp:DropDownList ID="DDL26"  Width="30%" AutoPostBack="True" Height="50px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="DDL26_SelectedIndexChanged" >
                        </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" class="float-right" InitialValue="0" runat="server" ErrorMessage="Sport event selection required*" ControlToValidate="DDL26" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                </div>
               
               
                    <div class="card bg-dark text-center text-white">
                         <br />

                        <h3>SELECTED STUDENTS</h3>
                        <br />

                        <asp:GridView ID="GridView7" runat="server"  DataKeyNames="studentid" class="mx-auto text-white" Width="90%" CellSpacing="2" CellPadding="4"  >
                      <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:checkbox ID="CheckBox1"  runat="server" ></asp:checkbox>
                                    </ItemTemplate>
                            
                                </asp:TemplateField>

                            </Columns>
                         </asp:GridView>
                        
                      <br /> 
                </div>
                <br />
                      <div class="card-body text-center ">
                        <asp:Button ID="Button7" class="btn btn-block btn-warning" runat="server" Text="REMOVE" OnClick="Button7_Click" />

                    </div>
                </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
                 <div class="card bg-dark text-center text-white">
                            <br />

                            <h3>PAID STUDENT LIST</h3>
                            <br />

                            <asp:GridView ID="GridView2" runat="server" class="mx-auto" Width="90%" CellSpacing="2" CellPadding="4">
                               
                            </asp:GridView>

                            <br />
                        </div>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
