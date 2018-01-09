<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableroConfiguado.aspx.cs" Inherits="NavalWarsCliente.TableroConfiguado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 144px;
        }
        .auto-style3 {
            width: 144px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="MostrarUnidades" runat="server" Text="Mostrar" Width="103px" OnClick="MostrarUnidades_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="137px">
                        <asp:ListItem>Unidades Destuidas Niv0</asp:ListItem>
                        <asp:ListItem>Unidades Destuidas Niv1</asp:ListItem>
                        <asp:ListItem>Unidades Destuidas Niv2</asp:ListItem>
                        <asp:ListItem>Unidades Destuidas Niv3</asp:ListItem>
                        <asp:ListItem>Unidades N0</asp:ListItem>
                        <asp:ListItem>Unidades N1</asp:ListItem>
                        <asp:ListItem>Unidades N2</asp:ListItem>
                        <asp:ListItem>Unidades N3</asp:ListItem>
                        <asp:ListItem>nivel0</asp:ListItem>
                        <asp:ListItem>Nivel1</asp:ListItem>
                        <asp:ListItem>Nivel2</asp:ListItem>
                        <asp:ListItem>Nivel3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar Al menu Principal" OnClick="btnRegresar_Click" Width="179px" />
                            </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
