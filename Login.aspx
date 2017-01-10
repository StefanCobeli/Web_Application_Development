<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_v2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/ProfilePage.aspx" FailureText="Autentificarea a eșuat. Mai încearcă o dată." LoginButtonText="Intru în contul meu" PasswordLabelText="Parolă:" RememberMeText="Păstrează-mă autentificat." TitleText="Autentificare" UserNameLabelText="Nume Utilizator:"></asp:Login>
    <asp:LoginView ID="LoginView1" runat="server"></asp:LoginView>
</asp:Content>

