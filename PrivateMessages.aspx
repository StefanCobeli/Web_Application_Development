<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrivateMessages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Meajele private aici sunt.
    
    
    <asp:Repeater ID="FriendRepeater" runat="server" DataSourceID="SqlFriendsDataSource">
        <ItemTemplate>
                <br>
                <asp:HyperLink ID="FoundedFriend" runat="server" NavigateUrl='<%# "~/PrivateMessages.aspx?Name=" + Eval("Nick_Primit")%>'>
                <%# Eval("Nume_Primit") %>,  
                <%# Eval("Prenume_Primit") %>
            </asp:HyperLink>
           (<asp:Label ID="FoundedNick" runat="server"><%#Eval("Nick_Primit") %></asp:Label>)
            <br>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlFriendsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand ="With UserFriends 
            as
        (
        SELECT [Nume_Primit], [Prenume_Primit], [Nick_Primit] 
        FROM [Prieteni] 
        WHERE ([Nick_Cerut] = @Name) AND [Acceptat] = 'True'

        Union ALL

        SELECT [Nume_Cerut], [Prenume_Cerut], [Nick_Cerut] 
        FROM [Prieteni] 
        WHERE ([Nick_Primit] = @Name) AND [Acceptat] = 'True'
        )
        Select *
        From UserFriends" >
            <%-- <SelectParameters>
                 <asp:SessionParameter Name="Name"  SessionField="Name" Type="Object" />
             </SelectParameters>--%>
    </asp:SqlDataSource>

</asp:Content>

