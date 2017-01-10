<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilePageOLD.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      
        
    </div>
    <asp:Panel ID="Panel1" runat="server">
          <asp:Image ID="ProfilePicture" runat="server" ImageUrl="~/Data/Images/Einstein.JPG">
        
        </asp:Image>

        <asp:Image ID="CoverPicture" runat="server" ImageUrl="~/Data/Images/EquationCover.PNG">
        
        </asp:Image>
    </asp:Panel>
</asp:Content>

