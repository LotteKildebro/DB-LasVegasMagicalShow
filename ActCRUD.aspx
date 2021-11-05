<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActCRUD.aspx.cs" Inherits="DB_Lasvegasmagicalshow.ActCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="style_boot.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
      <div>

            <h1>Create act</h1>

            <br />
            <!-- title, magician_fk, description, duration, picture -->
            <asp:Label ID="Label_title" runat="server" Text="title"></asp:Label>
            <asp:TextBox ID="TextBox_title" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="Label_magician_fk" runat="server" Text="Magician FK"></asp:Label>
            <asp:TextBox ID="TextBox_magician_fk" runat="server" CssClass="form-control"></asp:TextBox>

           <asp:Label ID="Label_description" runat="server" Text="description"></asp:Label>
            <asp:TextBox ID="TextBox_description" runat="server" CssClass="form-control"></asp:TextBox>

             <asp:Label ID="Label_duration" runat="server" Text="duration"></asp:Label>
            <asp:TextBox ID="TextBox_duration" runat="server" CssClass="form-control"></asp:TextBox>

           <asp:Label ID="Label_picture" runat="server" Text="picture"></asp:Label>
            <asp:TextBox ID="TextBox_picture" runat="server" CssClass="form-control"></asp:TextBox>


            <asp:Button ID="Button_Create" runat="server" Text="Create act" CssClass="btn btn-success" OnClick="Button_Create_Click" />

            <asp:Label ID="Label_msg" runat="server" Text="No error message"></asp:Label>

            <br /><br />

        
          <!-- read and update edit shippers -->

          <h1>Read & Update</h1>


            <asp:GridView ID="GridView_Shippers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No data" OnSelectedIndexChanged="GridView_Shippers_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField HeaderText="Edit" ShowHeader="True" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <asp:Label ID="Label_Message" runat="server" Text="No error message"></asp:Label>

            <br /><br />

            <h2>Update Shippers</h2>

            <br />
            <!-- title, magician_fk, description, duration, picture -->

            <asp:Label ID="Label_title1" runat="server" Text="title"></asp:Label>
            <asp:TextBox ID="TextBox_title1" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="Label_magician_fk1" runat="server" Text="magician_fk"></asp:Label>
            <asp:TextBox ID="TextBox_magician_fk1" runat="server" CssClass="form-control"></asp:TextBox>

          <asp:Label ID="Label_description1" runat="server" Text="description"></asp:Label>
            <asp:TextBox ID="TextBox_description1" runat="server" CssClass="form-control"></asp:TextBox>

          <asp:Label ID="Label_duration1" runat="server" Text="duration"></asp:Label>
            <asp:TextBox ID="TextBox_duration1" runat="server" CssClass="form-control"></asp:TextBox>

          <asp:Label ID="Label_picture1" runat="server" Text="picture"></asp:Label>
            <asp:TextBox ID="TextBox_picture1" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="Button_Update" runat="server" Text="Update act" CssClass="btn btn-primary" OnClick="Button_Update_Click" />

            <br /><br />

           <asp:Button ID="Delete" runat="server" Text="GO AND DELETE ACTS" CssClass="btn btn-success" PostBackUrl="~/Delete.aspx" />

        </div>
    </form>
</body>
</html>
