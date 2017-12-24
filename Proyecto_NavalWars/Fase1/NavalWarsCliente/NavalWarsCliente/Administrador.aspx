<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="NavalWarsCliente.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:MultiView ID="MultiView1" runat="server">
            <br />
            <asp:View ID="View1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Administrador" Font-Size="30pt"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnAdminUsuarios" runat="server" Text="Administrar Usuarios" OnClick="btnAdminUsuarios_Click" />
                <br />
                <br />
                <br />
                <br />
            </asp:View>
            <br />
            <br />
            <asp:View ID="View2" runat="server">
            </asp:View>
            <br />
        </asp:MultiView>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
