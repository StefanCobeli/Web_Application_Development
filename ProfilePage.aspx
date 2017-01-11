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
    <div id="AlbumsZone">
        <asp:Literal runat="server">Zona albumelor: </asp:Literal>
        <asp:HyperLink ID="CreateNewAlbum" NavigateUrl="CreateNewAlbum.aspx" runat="server">
            Creează un nou album
        </asp:HyperLink>
    </div>
    <div id="GroupsZone">
        <asp:Literal runat="server">Zona grupurilor: </asp:Literal>
        <asp:HyperLink ID="CreateNewGroup" NavigateUrl="CreateNewGroup.aspx" runat="server">
            Creeaza un nou grup
        </asp:HyperLink>
    </div>
</asp:Content>

