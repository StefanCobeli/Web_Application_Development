<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilPrivat.aspx.cs" Inherits="ProfilPrivat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br>
    Profilul lui <asp:Label ID="SearchedName" runat="server"></asp:Label> este privat.
    <asp:Button ID="FriendRequestButton" Text="Trimite cere de prietenie!" Visible="false" runat="server" OnClick="FriendRequestButton_Click"/>
</asp:Content>

