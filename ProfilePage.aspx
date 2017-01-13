<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal runat="server">Pagina de Profil</asp:Literal>
    <div id="ProfileZone">
        <asp:Image ID="CoverImg" runat="server" />
        <asp:Label ID="ProfileName" runat="server" Text="Label"></asp:Label>
        <asp:Image ID="ProfileImg" runat="server" />
    </div>
    <div id="FriendZone" style="float:right">
        <asp:Literal runat="server">Zona Prietenilor:</asp:Literal>
        <asp:Button ID="FriendshipRequestButton" Text="Cere prietenia" Visible="false" runat="server" OnClick="FriendshipRequestButton_Click" />
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
                <asp:HyperLink ID="FoundedFriend" runat="server" NavigateUrl='<%# "~/ProfilePage.aspx?Name=" + Eval("Nick_Cerut")%>'>
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
        <div id="FriendRequests" style="visibility:hidden" runat="server">
            <asp:Label runat="server">Cereri de prietenie:</asp:Label>
            <asp:Repeater ID="FriendRequestsRepeater" runat="server" DataSourceID="FriendRequestsDataSource">
                <ItemTemplate>
                    <br>
                    <asp:HyperLink ID="FoundedFriend" runat="server" NavigateUrl='<%# "~/ProfilePage.aspx?Name=" + Eval("Nick_Cerut")%>'>
                    <%# Eval("Nume_Cerut") %>,  
                    <%# Eval("Prenume_Cerut") %>
                    </asp:HyperLink>
                    (<asp:Label ID="FoundedNick" runat="server"><%#Eval("Nick_Cerut") %></asp:Label>)
                    
                    <asp:LinkButton ID="AcceptFriendButton" 
                        PostBackUrl='<%# "~/ProfilePage.aspx?Accepted=" + Eval("Nick_Cerut") + "&SName=" + Eval("Nume_Cerut") + "&FName=" + Eval("Prenume_Cerut") %>' Text="Acceptă Prietenia" runat="server" />
                    <br>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="FriendRequestsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume_Cerut], [Prenume_Cerut], [Nick_Cerut] FROM [Prieteni] WHERE (([Nick_Primit] = @Nick_Primit) AND [Acceptat] = 'False')">
                <SelectParameters>
                 <asp:SessionParameter Name="Nick_Primit" SessionField="Nick" Type="Object" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>

    <div id="AlbumsZone">
        <asp:Literal runat="server">Zona albumelor: </asp:Literal>
        <asp:Repeater ID="AlbumRepteater" runat="server" DataSourceID="SqlAlbumDataSource1">
                <ItemTemplate>
                    <br>
                    <asp:HyperLink ID="AlbumLink" 
                        NavigateUrl='<%# "~/Album.aspx?AlbumName=" + Eval("Nume_Album") + "&User_Id=" + Eval("Id_Utilizator")%>' runat="server">
                        <%# Eval("Nume_Album")%>  
                    </asp:HyperLink>
                </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlAlbumDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Nume_Album], [Id_Utilizator] FROM [Album] WHERE [Id_Utilizator] = @Id_Utilizator">
            <%--<SelectParameters>
                <asp:SessionParameter Name="Id_Utilizator" SessionField="User_Id" Type="Object" />
            </SelectParameters>--%>
        </asp:SqlDataSource>
        <asp:HyperLink ID="CreateNewAlbum" NavigateUrl="CreateNewAlbum.aspx" Visible="false" runat="server">
            Creează un nou album
        </asp:HyperLink>
    </div>


    <div id="GroupsZone">
        <asp:Literal runat="server">Zona grupurilor: </asp:Literal>
        <asp:HyperLink ID="CreateNewGroup" NavigateUrl="CreateNewGroup.aspx" Visible="false" runat="server">
            Creeaza un nou grup
        </asp:HyperLink>
    </div>
</asp:Content>

