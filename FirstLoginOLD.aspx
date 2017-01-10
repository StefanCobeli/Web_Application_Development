<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FirstLoginOLD.aspx.cs" Inherits="FirstLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Nume" HeaderText="Nume" SortExpression="Nume" />
            <asp:BoundField DataField="Prenume" HeaderText="Prenume" SortExpression="Prenume" />
            <asp:BoundField DataField="Nick" HeaderText="Nick" SortExpression="Nick" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume], [Prenume], [Nick], [Email] FROM [Utilizator] WHERE ([Nume] = @Nume)">
        <SelectParameters>
            <asp:SessionParameter Name="Nume" SessionField="Utilizator" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Nume" runat="server" Text="Nume: "></asp:Label>
    <asp:Label ID="Prenume" runat="server" Text="Prenume: "></asp:Label>
    <asp:Label ID="Nick" runat="server" Text="Nick: "></asp:Label>
    <asp:Label ID="Parola" runat="server" Text="Parola: "></asp:Label>
    <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
    <asp:Label ID="Intimitate" runat="server" Text="Intimitate: "></asp:Label>
    <asp:Label ID="PozaProfil" runat="server" Text="Poza de Profil: "></asp:Label>
    <asp:Label ID="PozaCover" runat="server" Text="Poza de Copertă: "></asp:Label>


</asp:Content>

