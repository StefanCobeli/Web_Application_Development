<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:Repeater ID="SearchResultsRepeater" runat="server" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            <asp:HyperLink ID="UserGasit" runat="server" NavigateUrl="~/Default.aspx">
                <%# Eval("Nume") %>,  
                <%# Eval("Prenume") %> (<%#Eval("Nick") %>)
            </asp:HyperLink>
            (<asp:Label ID="FoundedNick" runat="server"><%#Eval("Nick") %></asp:Label>)
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume], [Prenume], [Nick] FROM [Utilizator] WHERE ([Prenume] LIKE '%' + @Prenume + '%') OR ([Nume] LIKE '%' + @Prenume + '%') OR ([Nick] LIKE '%' + @Prenume + '%')">
        <SelectParameters>
            <asp:QueryStringParameter Name="Prenume" QueryStringField="Name" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    
    <asp:TextBox ID="numeleeeeeeee" runat="server">dasdad</asp:TextBox>
</asp:Content>

