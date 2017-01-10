<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Incepe Pagina!!!!!!!!!!!!!!!!!!!!!
        <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Logare" LogoutText="Delogare" />
    <div>
        <asp:Login ID="Login1" runat="server"></asp:Login>

    </div>
    </form>
</body>
</html>
