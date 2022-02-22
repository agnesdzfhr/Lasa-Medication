<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_page.aspx.cs" Inherits="Login_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Login - Lasa Medication</title>
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

	<link rel="stylesheet" href="~/Content/Custom.css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

	<!-- Bootstrap 4.0.0 -->
	<link rel="stylesheet" href="~/Content/bootstrap.css" />
	<link rel="stylesheet" href="~/Content/Site.css" />
	<link rel="stylesheet" href="~/Content/dist/css/AdminLTE.min.css" />

	<!-- Font Awesome -->
	<link rel="stylesheet" href="~/Content/font-awesome/css/font-awesome.css" />
	<link rel="stylesheet" href="~/Content/font-awesome/css/style.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

	<!-- Toast -->
	<link rel="stylesheet" href="~/Content/plugins/toast/toastr.css" />

	<style>
		body {
			background-image: url("<%=Page.ResolveClientUrl("~/Assets/img/Login/bg-image2.svg")%>") !important;
			height: auto;
			background-repeat: no-repeat;
			background-size: cover;
			background-position: center;
		}

		.login-area {
			margin: 10% auto;
			width: 392px;
			height: 299px;
			background: #FFFFFF 0% 0% no-repeat padding-box;
			box-shadow: 0px 8px 16px #00000026;
			border-radius: 8px;
			opacity: 1;
		}

		.login-text {
			margin-top: 24px;
			margin-left: 148.5px;
			width: 95px;
			height: 36px;
			text-align: left;
			font: normal normal bold 30px/36px Helvetica;
			letter-spacing: 0px;
			color: #1A2268;
			opacity: 1;
			display: inline-block;
		}


		#togglePassword {
			position: relative;
			margin-top: 10px;
			margin-left: -30px;
			cursor: pointer
		}

		.button-login {
			max-width: 296px;
			width: 296px;
			height: 40px;
			background: #2A3593 0% 0% no-repeat padding-box;
			border-radius: 30px;
			opacity: 1;
			color: white;
			border: 0;
			font: normal normal bold 12px/18px Helvetica;
		}

		.button-login:hover {
			background-color: #1D2567;
		}

		#forgotPassword:hover {
			text-decoration: underline;
		}

		.input-group:focus-within {
			outline: 1px solid #2A3593;
			border-radius: 4px;
		}

		.input-group:focus-within *:focus {
			outline: 0;
			border-radius: 4px;
		}





	</style>

	<script type="text/javascript">
		function Toggle() {
			var temp = document.getElementById('<%= txtPassword.ClientID %>');
			if (temp.type === "password") {
				temp.type = "text";
				$('.mata').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
			}
			else {
				temp.type = "password";
				$('.mata').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
			}
		}

	</script>
</head>
<body>
	<form id="FormLogin" runat="server">
		<!-- untuk melengkapi update panel ID upError -->
		<asp:ScriptManager ID="ScriptManager1" runat="server">
			<Scripts>
				<asp:ScriptReference Path="~/Content/plugins/jQuery/jQuery-2.2.0.min.js" />
				<asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
				<asp:ScriptReference Path="~/Content/plugins/toast/toastr.min.js" />
			</Scripts>
		</asp:ScriptManager>

		<!-- loading progress modal -->
		<asp:UpdateProgress ID="uProgLogin" runat="server">
			<ProgressTemplate>
				<div class="modal-backdrop" style="background-color: white; opacity: 0.4; vertical-align: middle; text-align: center; padding-top: 200px;">
					<img alt="" height="200px" width="200px" src="<%= Page.ResolveClientUrl("~/Assets/loading.gif") %>" />
				</div>
			</ProgressTemplate>
		</asp:UpdateProgress>
		<!-- login form -->
		<div class="login-area">
			<div class="login-text">LOGIN</div>
			<div class="mt-3 mx-5">
				<div class="input-group mb-4">
					<div class="input-group-prepend">
						<span class="input-group-text">
							<img src="<%=Page.ResolveClientUrl("~/Assets/img/Login/atom-icon-a-icon-user.png")%>" alt="Alternate Text" />
						</span>
					</div>
					<asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" required="required" oninvalid="this.setCustomValidity('Username is required')" oninput="this.setCustomValidity('')"></asp:TextBox>
				</div>
				<div class="input-group mb-1">
					<div class="input-group-prepend">
						<span class="input-group-text">
							<img src="<%=Page.ResolveClientUrl("~/Assets/img/Login/atom-icon-a-icon-lock.png")%>" alt="Alternate Text" />
						</span>
					</div>
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" onkeypress="return isUserName(event)" placeholder="Password" required="required" oninvalid="this.setCustomValidity('Password is required')" oninput="this.setCustomValidity('')"></asp:TextBox>
					<a href="#" onclick="Toggle()" style="text-decoration: none; color: #171717"><i class="fa fa-eye-slash mata" id="togglePassword"></i></a>
				</div>
				<div class="input-group d-flex justify-content-end">
					<a id="forgotPassword" href="#modalForgotPass" data-toggle="modal" style="text-align: left; color: #4D9B35; font: normal normal normal 12px/17px Helvetica; cursor: pointer">Forgot Password?</a>
				</div>
				<asp:Button ID="btnSignIn" runat="server" OnClick="btnSignIn_Click" CssClass="btn btn-primary button-login mt-4" Text="LOGIN" />
			</div>
		</div>
	</form>
</body>
</html>
