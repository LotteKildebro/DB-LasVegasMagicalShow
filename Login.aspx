<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_Lasvegasmagicalshow.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>
       <link href="Style.css" rel="stylesheet" />
</head>
<body>
   
    <h1>Login</h1>
    <form id="form1" runat="server">
       <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Hello " OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Login" OnClick="Button3_Click" />
    <asp:Button ID="Button5" runat="server" Text="Log out" OnClick="Button5_Click" />
    <asp:Button ID="Button4" runat="server" Text="Edit Acts" OnClick="Button4_Click" />
    <asp:Button ID="Button6" runat="server" Text="Edit Magicians" OnClick="Button6_Click" />
    <asp:Button ID="Button7" runat="server" Text="Edit Program" OnClick="Button7_Click" /> 

        <div class="center">
            <asp:TextBox ID="TextBoxName" runat="server" value="Pedro"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server" value="123"></asp:TextBox>
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <br />
            <asp:Button ID="buttonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
            
        </div>
    </form>
</body>
</html>
