<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webapp_sportmanagement.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">



    <title>college sports managament system</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/carousel.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">

                <img src="images/csmslogo.png" class="navbar-brand" alt="CSMS" height="60" width="60" />
                <a class="navbar-brand" href="#">CSMS</a>
                <a class="navbar-toggler bg-dark" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon bg-dark"></span>
                </a>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="viewsportteam.aspx">College Team</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="viewscoreboard.aspx">View ScoreBoard</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link " href="registeration_form1.aspx">Sports Day Registration</a>
                        </li>
                         <li class="nav-item">
                            <a class="nav-link " href="payment.aspx">Purchase</a>
                        </li>
                    </ul>
                   
                    <asp:Button ID="login"  class="btn btn-outline-success my-2 my-sm-0" runat="server" Text="login" OnClick="login_Click" />
                        
                   
                </div>
            </nav>
        </header>


        <div id="myCarousel" class="carousel slide d-block" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="first-slide" src="images/ban4.jpg" alt="First slide" />

                    <div class="carousel-caption text-left">
                        <h1>Kristu Jayanti College.</h1>
                        <p>Sports Management Portal</p>

                    </div>
                </div>

                <div class="carousel-item">
                    <img class="second-slide" src="images/ban2.jpg" alt="Second slide" />

                    <div class="carousel-caption text-black-50">
                        <h1>Sports. Athelete.</h1>
                        <p>Automated Results</p>
                        <!--<p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>-->
                    </div>
                </div>

                <div class="carousel-item">
                    <img class="third-slide" src="images/ban3.jpg" alt="Third slide" />

                    <div class="carousel-caption text-right">
                        <h1>Management Portal for college</h1>
                        <p>All sport activities included</p>
                        <%--<p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>--%>
                    </div>
                </div>

            </div>
            <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>


        <!-- FOOTER -->
        <footer id="foot" class="container-fluid card-body">

            <p class="mx-auto text-center">&copy; Daniel & Joel. &middot; <a href="#">Privacy</a> &middot; <a href="#">Terms</a></p>
        </footer>



    </form>
</body>
</html>
