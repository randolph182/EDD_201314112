<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLstJuegos.aspx.cs" Inherits="NavalWarsCliente.AdminLstJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 152px;
        }
        .auto-style5 {
            width: 160px;
        }
        .auto-style8 {
            width: 157px;
        }
        .auto-style9 {
            width: 148px;
        }
        .auto-style10 {
            width: 155px;
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
                <br />
                <asp:Label ID="Label2" runat="server" Font-Size="30pt" Text="Juegos de Usuarios"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnAgregarJuegosPrinc" runat="server" Text="Agregar Juegos Usuario" OnClick="btnAgregarJuegosPrinc_Click" />
                <br />
                <br />
                <asp:Button ID="btnModificarJuegosPrinc" runat="server" Text="Modificar Juegos Usuario" />
                <br />
                <br />
                <asp:Button ID="btnEliminarJuegosPrinc" runat="server" Text="Eliminar Juegos Usuario" />
                <br />
                <br />
                <asp:Button ID="Button4" runat="server" Text="Button" />
                <br />
                <br />
            </asp:View>
            <br />
            <asp:View ID="View2" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="30pt" Text="Agregar Juegos a Usuarios"></asp:Label>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">NickName Oponente:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtNickOponeteAddJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">unidades desplegadas: </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniDesplegAddJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">NickName Usuarios:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtNickUsuarioAddJuegos" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style4">unidades sobrevivientes:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniSobrevAddJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">
                            <br />
                        </td>
                        <td class="auto-style10">
                            <asp:Button ID="btnBuscarNickAddjuegos" runat="server" OnClick="btnBuscarNickAddjuegos_Click" Text="Buscar" Width="99px" />
                        </td>
                        <td class="auto-style4">unidades destruidas:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniDestruAddJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">
                            <asp:Label ID="lblMnsSearchUserAddjuegos" runat="server" Text="[ ]"></asp:Label>
                        </td>
                        <td class="auto-style4">gano :</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtGanoAddJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">
                            <br />
                            <asp:Button ID="btnAddJuegos" runat="server" OnClick="btnAddJuegos_Click" Text="Agregar" Width="131px" />
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Label ID="lblMnsjAddJugos" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">
                            <asp:Button ID="btnRegresarAddJuegos" runat="server" OnClick="btnRegresarAddJuegos_Click" Text="Regresar" Width="116px" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
            </asp:View>
            <br />
            <br />
            <asp:View ID="View3" runat="server">
                <br />
                <asp:Label ID="Label3" runat="server" Font-Size="30pt" Text="Modificar Juegos Usuarios"></asp:Label>
                <br />
                <table style="width:100%;">
                     <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">NickName Oponente:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="TextBox1" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">NickName Oponente:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtNickOponeteModJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id Juego:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtIdJuegoModJuegos" runat="server" Width="117px"></asp:TextBox>
                        </td>
                        <td class="auto-style4">unidades desplegadas: </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniDesplegModJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">NickName Usuarios:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtNickUsuarioModJuegos" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style4">unidades sobrevivientes:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniSobrevModJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">
                            <br />
                        </td>
                        <td class="auto-style10">
                            <asp:Button ID="btnBuscarNickModjuegos" runat="server" OnClick="btnBuscarNickModjuegos_Click" Text="Buscar" Width="99px" />
                        </td>
                        <td class="auto-style4">unidades destruidas:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtUniDestruModJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">
                            <asp:Label ID="lblMnsSearchUserModjuegos" runat="server" Text="[ ]"></asp:Label>
                        </td>
                        <td class="auto-style4">gano :</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtGanoModJuegos" runat="server" Width="140px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">
                            <br />
                            <asp:Button ID="btnModJuegos" runat="server" OnClick="btnModJuegos_Click" Text="Modificar" Width="131px" />
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Label ID="lblMnsjModJugos" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">
                            <asp:Button ID="btnRegresarModJuegos" runat="server" OnClick="btnRegresarModJuegos_Click" Text="Regresar" Width="116px" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
            </asp:View>
        </asp:MultiView>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
