<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CsvRead.aspx.cs" Inherits="NetLab202107_4fw.CsvRead" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>CSVからLINQで検索</h1>
    <a href="Default.aspx">DB版へ</a><br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="検索" OnClick="Button1_Click" /><br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-condensed table-hover"></asp:GridView>
</asp:Content>
