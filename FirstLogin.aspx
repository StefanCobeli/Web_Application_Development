<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FirstLogin.aspx.cs" Inherits="FirstLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell Text="Nume: ">
                <asp:RequiredFieldValidator ID="RequireLastName" ControlToValidate="LastName" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="LastName" runat="server">
                </asp:TextBox>
            </asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Prenume: ">
                <asp:RequiredFieldValidator ID="RequireFirstName" ControlToValidate="FirstName" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="FirstName" runat="server">
                </asp:TextBox>
            </asp:TableCell> 
        </asp:TableRow>
                <asp:TableRow>
            <asp:TableCell Text="Intimitate: ">
                <asp:RequiredFieldValidator ID="RequirePrivacy" ControlToValidate="Privacy" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButtonList ID="Privacy" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Public</asp:ListItem>
                    <asp:ListItem>Privat</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Poza de profil: ">
                <asp:RequiredFieldValidator ID="RequireProfilePic" ControlToValidate="ProfilePictureUpload" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="ProfilePictureUpload" runat="server" />
            </asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Text="Poza de Copertă: ">
                <asp:RequiredFieldValidator ID="RequireCoverPic" ControlToValidate="CoverPictureUpload" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="CoverPictureUpload" runat="server" />
            </asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="SubmitButton" OnClick="OnSubimt_Click" runat="server" Text="Încarcă informațiile" />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>

