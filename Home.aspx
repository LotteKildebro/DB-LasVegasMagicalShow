<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DB_Lasvegasmagicalshow.Home1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home of las vegas magical show</title>
        <link href="Style.css" rel="stylesheet" />
</head>
<body>
    

  
   
    <form id="form1" runat="server">
   
  <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Hello " OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Login" OnClick="Button3_Click" />
    <asp:Button ID="Button5" runat="server" Text="Log out" OnClick="Button5_Click" />
    <asp:Button ID="Button4" runat="server" Text="Edit Acts" OnClick="Button4_Click" />
    <asp:Button ID="Button6" runat="server" Text="Edit Magicians" OnClick="Button6_Click" />
    <asp:Button ID="Button7" runat="server" Text="Edit Program" OnClick="Button7_Click" /> 

        <div>
            <h2>Welcome to Las Vegas MagicShow!</h2>
            <h1>Program</h1>
            <asp:GridView ID="GridView1" CssClass="mygridview" runat="server">
            </asp:GridView>
        </div>
        <div id="center"> <asp:Button id="loginBtn" runat="server" Text="LOGIN" OnClick="button1Clicked" /></div>
    </form>
</body>
</html>
