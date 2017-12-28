<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="NavalWarsCliente.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 523px;
        }
    </style>
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
                <asp:Button ID="btnAdminUsuarios" runat="server" Text="Administrar Usuarios" OnClick="btnAdminUsuarios_Click" Width="240px" />
                <br />
                <br />
                <asp:Button ID="btnJuegos" runat="server" Text="Administrar Lista de Juegos" OnClick="btnJuegos_Click" />
                <br />
                <br />
                <asp:Button ID="btnCargaMasiva" runat="server" Text="Carga Masiva" Width="235px" OnClick="btnCargaMasiva_Click" />
                <br />
                <br />
            </asp:View>
            <br />
            <br />
            <asp:View ID="View2" runat="server">
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Font-Size="30pt" Text="Carga Masiva"></asp:Label>
                <br />
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSubirUsuarios" runat="server" Text="subirArchivoUsuarios" OnClick="btnSubirUsuarios_Click" />
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                                        <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                                        <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                                        <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
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
