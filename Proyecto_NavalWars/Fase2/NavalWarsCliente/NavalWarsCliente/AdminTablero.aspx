<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTablero.aspx.cs" Inherits="NavalWarsCliente.AdminTablero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 248px;
        }

        .auto-style2 {
            width: 85px;
        }

        .auto-style5 {
            width: 99px;
        }

        .auto-style6 {
            width: 167px;
        }

        .auto-style7 {
            height: 23px;
        }

        .auto-style8 {
            width: 99px;
            height: 23px;
        }

        .auto-style9 {
            width: 167px;
            height: 23px;
        }

        .auto-style11 {
            width: 160px;
        }

        .auto-style12 {
            width: 160px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <asp:MultiView ID="MultiView1" runat="server">
                <br />
                <br />
                <asp:View ID="View1" runat="server">
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">
                                <asp:Button ID="btnConfigurarJuego" runat="server" Text="Configurar nuevo Juego" Width="216px" OnClick="btnConfigurarJuego_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">
                                <asp:Button ID="btnCargaDatosArbolB" runat="server" Text="Cargar Datos Arbol B" Width="216px" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">
                                <asp:Button ID="MostrarArbolB" runat="server" Text="Mostrar Arbol B" Width="218px" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">
                                <asp:Button ID="btnBack" runat="server" Text="Regresar Al menu" Width="218px" OnClick="btnBack_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View2" runat="server">
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label1" runat="server" Text="Nickname Oponente1: "></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:DropDownList ID="ddLstNickOp1" runat="server" Height="16px" Width="137px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label2" runat="server" Text="Nickname Opnente2: "></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:DropDownList ID="ddLstNickOp2" runat="server" Height="16px" Width="132px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label3" runat="server" Text="Naves nivel 0: "></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtNiv0" runat="server" Width="127px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7"></td>
                            <td class="auto-style8"></td>
                            <td class="auto-style9">
                                <asp:Label ID="Label4" runat="server" Text="Naves Nivel 1"></asp:Label>
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="txtNiv1" runat="server" Width="129px"></asp:TextBox>
                            </td>
                            <td class="auto-style7"></td>
                            <td class="auto-style7"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label5" runat="server" Text="Naves Nivel2"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtNiv2" runat="server" Width="126px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label6" runat="server" Text="Naves Nivel 3"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtNiv3" runat="server" Width="128px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label7" runat="server" Text="Tamanio Filas"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtTamanioFilas" runat="server" Width="123px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label8" runat="server" Text="Tamanio Columnas"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtTamanioColumnas" runat="server" Width="127px" Height="22px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label9" runat="server" Text="Tipo De Juego"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtTipoJuego" runat="server" Width="132px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label10" runat="server" Text="tiempo"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtTiempo" runat="server" Width="123px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">
                                <asp:Label ID="Label11" runat="server" Text="Orden Arbol B"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtOrdenB" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">
                                <asp:Button ID="BtnConfigurar2" runat="server" OnClick="BtnConfigurar2_Click" Text="Configurar" Width="131px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                                                <tr>
                            <td>
                                <asp:Button ID="btnBack2" runat="server" Text="Regresar" Width="101px" />
                            </td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:View>
                <br />
                <br />
            </asp:MultiView>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
