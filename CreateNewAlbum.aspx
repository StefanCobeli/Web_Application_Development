<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateNewAlbum.aspx.cs" Inherits="AddNewAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <th>
                <asp:Label>Creează un nou album:</asp:Label>
            </th>
        </tr>
        <tr>
            <td>
                <asp:Label>Numele albumului:</asp:Label>
                <asp:RequiredFieldValidator ControlToValidate="AlbumName" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </td>
            <td>
                <asp:TextBox ID="AlbumName" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label>Încarcă o fotografie:</asp:Label>
                 <asp:RequiredFieldValidator ControlToValidate="UploadPicture" runat="server" ErrorMessage="*" ForeColor="OrangeRed" />
            </td>
            <td>
                <asp:FileUpload ID="UploadPicture" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="CreateAlbumButton" Text="Creează Albumul" runat="server" OnClick="CreateAlbumButton_Click" />
            </td>
        </tr> 
    </table>
</asp:Content>

