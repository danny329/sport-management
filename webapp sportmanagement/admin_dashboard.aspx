<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_dashboard.aspx.cs" Inherits="webapp_sportmanagement.admin_dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMIN DASHBOARD</title>

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

                    <h3 class="text-center mx-auto d-block align-middle  ">WELCOME ADMIN</h3>
                </div>
                <div class="col-sm-4">
                     <asp:Button ID="logout" class="btn btn-outline-success float-sm-right " runat="server" Text="" OnClick="logout_Click" />
                </div>
            </div>
            <br />
        </div>
        <br />

        <!-- Main -->
        <div id="main">
            <div class="container-fluid">

                <!-- Boxes -->
                <div class="card-deck">

                    <div class="card bg-warning">

                        <img src="images/pc01.jpg" class="card-img-top img-fluid" alt="" />

                        <div class="card-body card-text">
                            <h4 class="text-center card-title">SPORTS</h4>
                            <p class="text-center">Sport event Adding and removing</p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="sporteventbutton" class="btn btn-block bg-secondary" runat="server" Text="SPORT" OnClick="sporteventbutton_Click" />
                        </div>
                    </div>

                    <div class="card bg-warning">

                        <img src="images/pc02.jpg" class="card-img-top img-fluid" alt="" />

                        <div class="card-body card-text">
                            <h4 class="text-center card-title">TOURNAMENT</h4>
                            <p class="text-center">Tournament should be authorized by the college and respective sport event should be added.</p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="Button2" class="btn btn-block bg-secondary" runat="server" Text="TOURANMENT" OnClick="Button2_Click" />
                        </div>
                    </div>

                    <div class="card  bg-warning">

                        <img src="images/pc03.jpg" class="card-img-top img-fluid" alt="" />

                        <div class="card-body card-text">
                            <h4 class="text-center card-title">SCOREBOARD</h4>
                            <p class="text-center">Scoreboard will be specific to an tournaments sport event, it displays tally of each player.</p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="Button3" class="btn btn-block bg-secondary" runat="server" Text="SCOREBOARD" OnClick="Button3_Click" />
                        </div>
                    </div>
                     <div class="card bg-warning">

                        <img src="images/pc02.jpg" class="card-img-top" style="width: 100%" alt="" />

                        <div class="card-body card-text">
                            <h4 class="text-center card-title">SPORT TEAM</h4>
                            <p class="text-center">PLAYERS FOR COLLEGE TEAM.</p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="Button7" class="btn btn-block bg-secondary" runat="server" Text="SPORT TEAM" OnClick="Button7_Click" />
                        </div>
                    </div>
                      <div class="card bg-warning">

                        <img src="images/pc02.jpg" class="card-img-top" style="width: 100%" alt="" />

                        <div class="card-body card-text">
                            <h4 class="text-center card-title">REMOVE PLAYER</h4>
                            <p class="text-center">Remove a player from particular sport event in a tournament.</p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="Button5" class="btn btn-block bg-secondary" runat="server" Text="REMOVE PLAYER" OnClick="Button5_Click" />
                        </div>
                    </div>
                </div>


                <br />

               


            </div>
        </div>
        <br />
        <!-- Footer -->
        <footer id="footer" class="container-fluid " style="height: 5%;">

            <p class="text-center bg-transparent text-white">&copy; SPORT MANAGEMENT SYSTEM. Design:  Daniel & Joel.</p>

        </footer>


    </form>
</body>
</html>
