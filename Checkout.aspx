<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Prog3.Checkout" %>
<%@ Register src="ShoppingItem.ascx" tagname="ShoppingItem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" Width="950px">
</asp:GridView>
    <br />
    <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Checkout" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
    <uc1:ShoppingItem ID="ShoppingItem1" runat="server" />
</asp:Content>
