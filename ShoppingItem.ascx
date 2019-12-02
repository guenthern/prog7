<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingItem.ascx.cs" Inherits="Prog3.ShoppingItem" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table class="auto-style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" OnTextChanged="txtID_TextChanged"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Cost"></asp:Label>
            <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Quantity"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Message"></asp:Label>
            <asp:TextBox ID="txtMess" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="txtID_TextChanged" Text="Button" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

