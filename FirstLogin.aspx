<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FirstLogin.aspx.cs" Inherits="FirstLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Text="Nume: "></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="LastName" runat="server">
                </asp:TextBox>
            </asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Prenume: "></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="FirstName" runat="server">
                </asp:TextBox>
            </asp:TableCell> 
        </asp:TableRow>
                <asp:TableRow>
            <asp:TableCell Text="Intimitate: "></asp:TableCell>
            <asp:TableCell>
                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Public</asp:ListItem>
                    <asp:ListItem>Privat</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell> 
        </asp:TableRow>
                <asp:TableRow>
            <asp:TableCell Text="Poza de profil: "></asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="ProfilePictureUpload" runat="server" />
            </asp:TableCell> 
        </asp:TableRow>
    </asp:Table>
</asp:Content>

