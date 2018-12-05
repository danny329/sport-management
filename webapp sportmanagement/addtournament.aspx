<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtournament.aspx.cs" Inherits="webapp_sportmanagement.addtournament" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TOURNAMENT PAGE</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
   
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <style>
        .row-centered {
    text-align:center;
}
.col-centered {
    display:inline-block;
    float:none;
    /* reset the text-align */
    text-align:left;
    /* inline-block space fix */
    margin-right:-4px;
    text-align: center;
    background-color: #ccc;
    border: 1px solid #ddd;
}
    </style>
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

                    <h3 class="text-center mx-auto d-block align-middle  ">TOURNAMENT PAGE</h3>
                </div>
                <div class="col-sm-4">
                    
                    <asp:Button ID="home" runat="server" class="btn btn-outline-success float-sm-right " Text="HOME" OnClick="home_Click" CausesValidation="False" />
                </div>
            </div>
            <br />
        </div>
     
        <br />
        <br />
        
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="tournamentinitialview" runat="server">
                <div class="container-fluid">

                    <!-- Boxes -->
                    <div class="card-deck">
                        <div class="card invisible"></div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">ADD TOURNAMENT</h5>
                               
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="addtournamentviewbutton" class="btn btn-block btn-light" runat="server" Text="ADD" OnClick="addtournamentviewbutton_Click" />
                            </div>
                        </div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">EDIT TOURNAMENT</h5>
                                
                            </div>
                            <div class="card-footer">
                               <asp:Button ID="edittournamentviewbutton" class="btn btn-block btn-light" runat="server" Text="EDIT" OnClick="edittournamentviewbutton_Click" />
                            </div>
                        </div>

                        <div class="card bg-warning">

                            <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                            <div class="card-body card-text">
                                <h5 class="text-center card-title">REMOVE TOURNAMENT</h5>
                               
                            </div>
                            <div class="card-footer">
                               <asp:Button ID="deletetournamentviewbutton" class="btn btn-block btn-light" runat="server" Text="REMOVE" OnClick="deletetournamentviewbutton_Click" />
                            </div>
                        </div>
                        <div class="card invisible"></div>
                    </div>
                </div>
                
                
                
            </asp:View>
            <asp:View ID="addtournamentview" runat="server">
                <div class="container-fluid bg-secondary">
                    <br />
                    
                    <div class="card-group-vertical ">
                        <div class="row row-centered card-body">

                            <div class="col col-centered bg-dark text-center text-white ">
                                <div class="card-body">
                                    <asp:Label ID="Label1" runat="server" Text="TOURNAMENT NAME" Height="10" Width="200"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="40%" Height="50"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="float-right" runat="server" ErrorMessage="TOURNAMENT NAME REQUIRED *" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col col-centered bg-dark text-center text-white ">
                                <div class="card-body">
                                    <asp:Label ID="Label2" runat="server" Text="TOURNAMENT DESCRIPTION"></asp:Label>
                                    <asp:TextBox ID="TextBox2" Width="50%" Height="40" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="float-right" runat="server" ErrorMessage="TOURNAMENT DESC REQUIRED *" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                          <div class="row row-centered card-body">

                            <div class="col col-centered bg-dark text-center text-white ">
                                <div class="card-body">
                                   <asp:Label ID="Label3" runat="server" Text="TOURNAMENT START DATE"></asp:Label>

                                <asp:TextBox ID="TextBox3" Width="50%" Height="50" Enabled="false" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" class="align-middle" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/images/cal.png" CausesValidation="False" />
                                <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" BorderStyle="Solid" Height="180px" Width="200px" >
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  class="float-right" runat="server" ErrorMessage="START DATE REQUIRED *" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$" ErrorMessage="  Invalid date format." ControlToValidate="TextBox3"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col col-centered bg-dark text-center text-white ">
                                <div class="card-body">
                                   <asp:Label ID="Label4" runat="server" Text="TOURNAMENT END DATE"></asp:Label>

                                <asp:TextBox ID="TextBox4" Width="50%" Enabled="false" Height="50" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" class="align-middle" runat="server" OnClick="ImageButton2_Click" ImageUrl="~/images/cal.png" CausesValidation="False" />
                                <asp:Calendar ID="Calendar2" runat="server" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged" Height="180px" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" class="float-right" runat="server" ErrorMessage="END DATE REQUIRED *" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$" ErrorMessage="  Invalid date format." ControlToValidate="TextBox4"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    
                     
                     

                        <br />

                        <div class="card bg-dark text-center text-white">
                            <h3>SELECT SPORT EVENT</h3>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" DataSourceID="SqlDataSource1" DataTextField="sportname" DataValueField="sportid">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [sportid], [sportname] FROM [sporteventtable]"></asp:SqlDataSource>
                            <br />
                        </div>
                        <br />
                        <div class="card-body text-center text-white">
                            <asp:Button ID="Button1" class="btn btn btn-success" runat="server" Text="ADD TOURNAMENT" OnClick="Button1_Click" />
                            <asp:Button ID="backinadtour" class="btn btn-danger" runat="server" Text="BACK" OnClick="backinadtour_Click" CausesValidation="False" />
                        </div>
                    </div>

                </div>

            </asp:View>
            <asp:View ID="edittournamentview" runat="server">
                <div class="container-fluid bg-secondary">
                            <br />
                            <div class="card-group-vertical">


                                <div class="card text-white text-center  bg-dark">
                                    <div class="card-body  d-inline">
                                        <asp:Label ID="Label12" runat="server" Text="TOURNAMENT NAME" Height="10" Width="200"></asp:Label>
                                        <asp:DropDownList ID="TTN" Width="50%" AutoPostBack="True" Height="50px" runat="server" BackColor="Black" ForeColor="White" OnSelectedIndexChanged="TTN_SelectedIndexChanged"></asp:DropDownList>
                                        <br />
                                    </div>

                                </div>
                              
                                <br />
                            </div>
                        </div>
                 <br />
                <asp:MultiView ID="edittournamentmultiview" runat="server">
                    <asp:View ID="tile2" runat="server">
                         <div class="row text-white text-center  bg-dark">
                                    <div class="card-body ">
                                        <asp:Label ID="Label5" runat="server" Text="START DATE" Height="10" Width="200"></asp:Label>
                                        <asp:TextBox ID="DATESTART" placeholder="dd-mm-yy" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"  ErrorMessage="  Invalid date format." ControlToValidate="DATESTART"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                              <div class="card-body ">
                                        <asp:Label ID="label" runat="server" Text="END DATE" Height="10" Width="200"></asp:Label>
                                        <asp:TextBox ID="ENDDATE" placeholder="dd-mm-yy" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"  ErrorMessage="  Invalid date format." ControlToValidate="ENDDATE"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                                </div>
                        
                          <div class="card text-white text-center  bg-dark">
                                    <br />
                                    <h6>ADD SPORT EVENT TO THE TOURNAMENT</h6>
                                    <br />
                                    <asp:GridView ID="GV1" runat="server" DataKeyNames="sportid" class="mx-auto text-white" Width="90%" CellSpacing="2" CellPadding="4">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="GV1_OnCheckedChanged" runat="server"></asp:CheckBox>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </div>
                                <div class="card text-white text-center  bg-dark">
                                    <br />
                                    <h6>REMOVE THE SPORT EVENT FROM THE TOURNAMENT</h6>
                                    <br />
                                    <asp:GridView ID="GV2" class="mx-auto" Width="90%" CellSpacing="2" CellPadding="4" runat="server" OnRowDeleting="GV2_RowDeleting" DataKeyNames="sportid">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />

                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </div>
                                <div class="card bg-transparent">
                                    <br />
                                    <asp:Button ID="B2" class="btn btn-block btn-info" runat="server" Text="FINISH" OnClick="B2_Click" />
                                    <br />
                                </div>
                    </asp:View>
                </asp:MultiView>
                <br />
             </asp:View>
            <asp:View ID="deletetournamentview" runat="server">
                <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical">


                <div class="card text-white text-center  bg-dark">
                    <div class="card-body  d-inline">

                        <h3>PLEASE REMOVE TOURNAMENT</h3>
                        <br />
                        <asp:GridView ID="GridView3" runat="server" class="mx-auto" Width="90%" CellPadding="4" OnRowDeleting="GridView3_RowDeleting" DataKeyNames="tournamentid">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <div class="card text-white text-center  bg-transparent">


                    <asp:Button ID="finish_rvm_tournament" class="btn btn-block btn-success" runat="server" Text="FINISH" OnClick="Button3_Click" />
                   


                </div>
            </div>
        </div>
            </asp:View>
        </asp:MultiView>
        <br />
    </form>
</body>
</html>
