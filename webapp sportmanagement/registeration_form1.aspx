<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registeration_form1.aspx.cs" Inherits="webapp_sportmanagement.registeration_form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTER FOR EVENTS</title>
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

                    <h3 class="text-center mx-auto d-block align-middle  ">NEW REGISTRATION FORM</h3>
                </div>
                <div class="col-sm-4">
                    <a href="index.aspx" id="home" class="btn btn-outline-success float-sm-right ">HOME</a>
                </div>
            </div>
            <br />
        </div>
        <div class="container-fluid bg-secondary">
            <br />
            <div class="card-group-vertical text-white">

                <div class="card bg-dark ">
                    <div class="card-body text-center ">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">

                                <asp:Button ID="individual" class="btn btn-lg  btn-success" runat="server" Text="INDIVIDUAL EVENT" OnClick="individual_Click" />
                                <asp:Button ID="Group" class="btn btn-lg btn-success " runat="server" Text="GROUP EVENT" OnClick="Group_Click" />


                            </asp:View>

                            <asp:View ID="View2" runat="server">

                                <div class="card bg-dark ">
                                    <div class="card-body text-center ">
                                        <asp:Label ID="Label1" runat="server" Text="TOURNAMENT NAME" ></asp:Label>
                                        <asp:DropDownList ID="DDL1" Width="30%" AutoPostBack="True" Height="50px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="DDL1_SelectedIndexChanged">
                                        </asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="float-right" runat="server" ErrorMessage="TOURNAMENT NAME REQUIRED *" InitialValue="0" ControlToValidate="DDL1" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="card bg-dark ">
                                    <div class="card-body text-center">
                                        <asp:Label ID="Label11" runat="server" Text="STUDENT ID"></asp:Label>
                                        <asp:TextBox ID="TextBox11" runat="server" Width="30%" Height="50" AutoPostBack="True" OnTextChanged="Textbox11_onTextchanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="btn-group  bg-outline-success">
                                    <div class="btn btn-lg w-100 text-center">
                                        <asp:Label ID="Label2" runat="server" Text="STUDENT NAME"></asp:Label>
                                        <asp:TextBox ID="TextBox2" Width="30%" Height="50" runat="server" Enabled="False"></asp:TextBox>
                                    </div>


                                    <div class="btn  btn-lg w-100 text-center">

                                        <asp:Label ID="Label3" runat="server" Text="DATE OF BIRTH"></asp:Label>
                                        <asp:TextBox ID="TextBox3" Width="40%" Height="50" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="btn-group bg-outline-success">

                                    <div class="btn btn-lg w-100 text-center">

                                        <asp:Label ID="Label4" runat="server" Text="MOBILE NUMBER"></asp:Label>
                                        <asp:TextBox ID="TextBox4" Width="40%" Height="50" runat="server" Enabled="False"></asp:TextBox>
                                    </div>




                                    <div class="btn btn-lg w-100 text-center">

                                        <asp:Label ID="Label5" runat="server" Text="COURSE ID"></asp:Label>
                                        <asp:TextBox ID="TextBox5" Width="30%" Height="50" runat="server" Enabled="False"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="card bg-dark text-center text-white">


                                    <h3>SELECT SPORT EVENT</h3>
                                    <br />
                                    <asp:CheckBoxList ID="CheckBoxList1" css="mx-auto" runat="server" RepeatDirection="Horizontal" DataSourceID="SqlDataSource1" DataTextField="sportname" DataValueField="sportid">
                                    </asp:CheckBoxList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ></asp:SqlDataSource>
                                    <br />
                                </div>
                                <div class="card-body text-center ">
                                    <asp:Button ID="Button1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="Button1_Click" />
                                    <asp:Button ID="back" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="back_Click" CausesValidation="False" />

                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="card bg-dark ">
                                    <div class="card-body text-center ">
                                        <asp:Label ID="deptname" runat="server" Text="DEPARTMENT" ></asp:Label>
                                        <asp:DropDownList ID="Deptlist" Width="10%" AutoPostBack="True" Height="40px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="Deptlist_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                        
                                   <span>&nbsp;</span>
                                        
                                        <asp:Label ID="tourname" runat="server" Text="TOURNAMENT" ></asp:Label>
                                        <asp:DropDownList ID="tourlist" Width="10%" AutoPostBack="True" Height="40px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="tourlist_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                       
                                   <span>&nbsp;</span>     

                                        <asp:Label ID="sportn" runat="server" Text="SPORT" ></asp:Label>
                                        <asp:DropDownList ID="toursportlist" Width="10%" AutoPostBack="True" Height="40px" runat="server" BackColor="white" ForeColor="black" OnSelectedIndexChanged="toursportlist_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                       
                                        <asp:Label ID="teamnamelabel" runat="server" Text="TEAM NAME" ></asp:Label>
                                        <asp:TextBox ID="teamname" Width="10%" Height="40px"  runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="teamval3" class="float-right" runat="server" ErrorMessage="TEAM NAME REQUIRED *" ControlToValidate="teamname" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:MultiView ID="MultiView2" runat="server">
                                    <asp:View ID="none" runat="server"></asp:View>
                                    <asp:View ID="FOOTBALL" runat="server">
                                        <div class="container">
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p1" AutoPostBack="true" placeholder="Roll No: 1" OnTextChanged="p1_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p2" AutoPostBack="true" placeholder="Roll No: 2" OnTextChanged="p2_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p3" AutoPostBack="true" placeholder="Roll No: 3" runat="server" OnTextChanged="p3_onTextchanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p4" AutoPostBack="true" placeholder="Roll No: 4" OnTextChanged="p4_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p5" AutoPostBack="true" placeholder="Roll No: 5" OnTextChanged="p5_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p6" AutoPostBack="true" placeholder="Roll No: 6" OnTextChanged="p6_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p7" AutoPostBack="true" placeholder="Roll No: 7" OnTextChanged="p7_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p8" AutoPostBack="true" placeholder="Roll No: 8" OnTextChanged="p8_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p9" AutoPostBack="true" placeholder="Roll No: 9" OnTextChanged="p9_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p10" AutoPostBack="true" placeholder="Roll No: 10" OnTextChanged="p10_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p11" AutoPostBack="true" placeholder="Roll No: 11" OnTextChanged="p11_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="p12" AutoPostBack="true" placeholder="Roll No: 12" OnTextChanged="p12_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="p13" AutoPostBack="true" placeholder="Roll No: 13" OnTextChanged="p13_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="p14" AutoPostBack="true" placeholder="Roll No: 14" OnTextChanged="p14_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="p15" AutoPostBack="true" placeholder="Roll No: 15" OnTextChanged="p15_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body text-center ">
                                            <asp:Button ID="grpbtnconfirmp1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="grpbtnconfirmp1_Click" />
                                            <asp:Button ID="grpbtnbackp1" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="grpbtnbackp1_Click" CausesValidation="False" />

                                        </div>
                                    </asp:View>
                                    <asp:View ID="CRICKET" runat="server">
                                         <div class="container">
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc1" AutoPostBack="true" placeholder="Roll No: 1" OnTextChanged="pc1_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc2" AutoPostBack="true" placeholder="Roll No: 2" OnTextChanged="pc2_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc3" AutoPostBack="true" placeholder="Roll No: 3" runat="server" OnTextChanged="pc3_onTextchanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc4" AutoPostBack="true" placeholder="Roll No: 4" OnTextChanged="pc4_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc5" AutoPostBack="true" placeholder="Roll No: 5" OnTextChanged="pc5_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc6" AutoPostBack="true" placeholder="Roll No: 6" OnTextChanged="pc6_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc7" AutoPostBack="true" placeholder="Roll No: 7" OnTextChanged="pc7_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc8" AutoPostBack="true" placeholder="Roll No: 8" OnTextChanged="pc8_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc9" AutoPostBack="true" placeholder="Roll No: 9" OnTextChanged="pc9_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc10" AutoPostBack="true" placeholder="Roll No: 10" OnTextChanged="pc10_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc11" AutoPostBack="true" placeholder="Roll No: 11" OnTextChanged="pc11_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pc12" AutoPostBack="true" placeholder="Roll No: 12" OnTextChanged="pc12_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="pc13" AutoPostBack="true" placeholder="Roll No: 13" OnTextChanged="pc13_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="pc14" AutoPostBack="true" placeholder="Roll No: 14" OnTextChanged="pc14_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4  ">
                                                    <asp:TextBox ID="pc15" AutoPostBack="true" placeholder="Roll No: 15" OnTextChanged="pc15_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body text-center ">
                                            <asp:Button ID="grpbtnconfirmpc1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="grpbtnconfirmpc1_Click" />
                                            <asp:Button ID="grpbtnbackpc1" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="grpbtnbackpc1_Click" CausesValidation="False" />

                                        </div>
                                    </asp:View>
                                    <asp:View ID="BASKETBALL" runat="server">
                                        <div class="container">
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb1" AutoPostBack="true" placeholder="Roll No: 1" OnTextChanged="pb1_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb2" AutoPostBack="true" placeholder="Roll No: 2" OnTextChanged="pb2_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb3" AutoPostBack="true" placeholder="Roll No: 3" runat="server" OnTextChanged="pb3_onTextchanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb4" AutoPostBack="true" placeholder="Roll No: 4" OnTextChanged="pb4_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb5" AutoPostBack="true" placeholder="Roll No: 5" OnTextChanged="pb5_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                               
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb6" AutoPostBack="true" placeholder="Roll No: 6" OnTextChanged="pb6_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb7" AutoPostBack="true" placeholder="Roll No: 7" OnTextChanged="pb7_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb8" AutoPostBack="true" placeholder="Roll No: 8" OnTextChanged="pb8_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb9" AutoPostBack="true" placeholder="Roll No: 9" OnTextChanged="pb9_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pb10" AutoPostBack="true" placeholder="Roll No: 10" OnTextChanged="pb10_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                              
                                            </div>
                                            <br />
                                          
                                        </div>
                                        <div class="card-body text-center ">
                                            <asp:Button ID="grpbtnconfirmpb1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="grpbtnconfirmpb1_Click" />
                                            <asp:Button ID="grpbtnbackpb1" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="grpbtnbackpb1_Click" CausesValidation="False" />

                                        </div>
                                    </asp:View>
                                    <asp:View ID="VOLLEYBALL" runat="server">
                                        <div class="container">
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv1" AutoPostBack="true" placeholder="Roll No: 1" OnTextChanged="pv1_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv2" AutoPostBack="true" placeholder="Roll No: 2" OnTextChanged="pv2_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv3" AutoPostBack="true" placeholder="Roll No: 3" runat="server" OnTextChanged="pv3_onTextchanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv4" AutoPostBack="true" placeholder="Roll No: 4" OnTextChanged="pv4_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv5" AutoPostBack="true" placeholder="Roll No: 5" OnTextChanged="pv5_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                               
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv6" AutoPostBack="true" placeholder="Roll No: 6" OnTextChanged="pv6_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv7" AutoPostBack="true" placeholder="Roll No: 7" OnTextChanged="pv7_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv8" AutoPostBack="true" placeholder="Roll No: 8" OnTextChanged="pv8_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv9" AutoPostBack="true" placeholder="Roll No: 9" OnTextChanged="pv9_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pv10" AutoPostBack="true" placeholder="Roll No: 10" OnTextChanged="pv10_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                              
                                            </div>
                                            <br />
                                          
                                        </div>
                                        <div class="card-body text-center ">
                                            <asp:Button ID="grpbtnconfirmpv1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="grpbtnconfirmpv1_Click" />
                                            <asp:Button ID="grpbtnbackpv1" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="grpbtnbackpv1_Click" CausesValidation="False" />

                                        </div>
                                    </asp:View>
                                    <asp:View ID="THROWBALL" runat="server">
                                        <div class="container">
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt1" AutoPostBack="true" placeholder="Roll No: 1" OnTextChanged="pt1_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt2" AutoPostBack="true" placeholder="Roll No: 2" OnTextChanged="pt2_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt3" AutoPostBack="true" placeholder="Roll No: 3" runat="server" OnTextChanged="pt3_onTextchanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt4" AutoPostBack="true" placeholder="Roll No: 4" OnTextChanged="pt4_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt5" AutoPostBack="true" placeholder="Roll No: 5" OnTextChanged="pt5_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                               
                                            </div>
                                            <br />
                                            <div class="row bg-dark ">
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt6" AutoPostBack="true" placeholder="Roll No: 6" OnTextChanged="pt6_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt7" AutoPostBack="true" placeholder="Roll No: 7" OnTextChanged="pt7_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt8" AutoPostBack="true" placeholder="Roll No: 8" OnTextChanged="pt8_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt9" AutoPostBack="true" placeholder="Roll No: 9" OnTextChanged="pt9_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-2  ">
                                                    <asp:TextBox ID="pt10" AutoPostBack="true" placeholder="Roll No: 10" OnTextChanged="pt10_onTextchanged" runat="server"></asp:TextBox>
                                                </div>
                                              
                                            </div>
                                            <br />
                                          
                                        </div>
                                        <div class="card-body text-center ">
                                            <asp:Button ID="grpbtnconfirmpt1" class="btn btn-lg btn-outline-success" runat="server" Text="CONFIRM" OnClick="grpbtnconfirmpt1_Click" />
                                            <asp:Button ID="grpbtnbackpt1" class="btn btn-lg btn-outline-danger" runat="server" Text="BACK" OnClick="grpbtnbackpt1_Click" CausesValidation="False" />

                                        </div>
                                    </asp:View>
                                    
                                </asp:MultiView>
                               
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>

                <br />
            </div>
        </div>

    </form>
</body>
</html>
