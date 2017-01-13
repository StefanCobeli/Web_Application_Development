<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrivateMessages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Meajele private aici sunt.
    <asp:Repeater ID="FriendRepeater" runat="server" DataSourceID="SqlFriendsDataSource">
            <ItemTemplate>
                <br>
                <asp:HyperLink ID="FoundedFriend" runat="server" NavigateUrl='<%# "~/ProfilePage.aspx?Name=" + Eval("Nick_Primit")%>'>
                <%# Eval("Nume_Primit") %>,  
                <%# Eval("Prenume_Primit") %>
            </asp:HyperLink>
           (<asp:Label ID="FoundedNick" runat="server"><%#Eval("Nick_Primit") %></asp:Label>)
            <br>
            </ItemTemplate>
        </asp:Repeater>
         <asp:SqlDataSource ID="SqlFriendsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume_Primit], [Prenume_Primit], [Nick_Primit] FROM [Prieteni] WHERE ([Nick_Cerut] = @Nick_Cerut) AND [Acceptat] = 'True'">
             <SelectParameters>
                 <asp:SessionParameter Name="Nick_Cerut" SessionField="Nick" Type="Object" />
             </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater ID="FriendRepeater_Send" runat="server" DataSourceID="SqlFriendsDataSource_Send">
            <ItemTemplate>
                <br>
                <asp:HyperLink ID="FoundedFriend" runat="server" NavigateUrl='<%# "~/PrivateMessages.aspx?Nick_To=" + Eval("Nick_Cerut") %>'>
                <%# Eval("Nume_Cerut") %>,  
                <%# Eval("Prenume_Cerut") %>
            </asp:HyperLink>
           (<asp:Label ID="FoundedNick" runat="server"><%#Eval("Nick_Cerut") %></asp:Label>)
            <br>
            </ItemTemplate>
        </asp:Repeater>
         <asp:SqlDataSource ID="SqlFriendsDataSource_Send" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume_Cerut], [Prenume_Cerut], [Nick_Cerut] FROM [Prieteni] WHERE ([Nick_Primit] = @Nick_Primit) AND [Acceptat] = 'True'">
             <SelectParameters>
                 <asp:SessionParameter Name="Nick_Primit" SessionField="Nick" Type="Object" />
             </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>

