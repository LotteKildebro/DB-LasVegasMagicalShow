<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="DB_Lasvegasmagicalshow.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                      <!--delete-->
         <asp:GridView ID="GridView_Shippers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

            <br />

            <asp:DropDownList ID="DropDownList_act" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList_act_SelectedIndexChanged"></asp:DropDownList>

            <asp:Button ID="Button_Delete" runat="server" Text="Delete act" CssClass="btn btn-danger" OnClick="Button_Delete_Click" />

            <asp:Label ID="Label_Msg" runat="server" Text="No message"></asp:Label>


            <br /><br />

            <asp:Button ID="Button_Create" runat="server" Text="Go back to CRU" CssClass="btn btn-success" PostBackUrl="~/ActCRUD.aspx" />
            
        </div>
    </form>
</body>
</html>
