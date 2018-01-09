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

        .auto-style13 {
            width: 116px;
        }

        .auto-style14 {
            width: 116px;
            height: 23px;
        }

        .auto-style15 {
            width: 116px;
            height: 34px;
        }

        .auto-style16 {
            width: 99px;
            height: 34px;
        }

        .auto-style17 {
            width: 167px;
            height: 34px;
        }

        .auto-style18 {
            width: 160px;
            height: 34px;
        }

        .auto-style19 {
            height: 34px;
        }

        .auto-style20 {
            width: 116px;
            height: 42px;
        }

        .auto-style21 {
            width: 99px;
            height: 42px;
        }

        .auto-style22 {
            width: 167px;
            height: 42px;
        }

        .auto-style23 {
            width: 160px;
            height: 42px;
        }

        .auto-style24 {
            height: 42px;
        }
        .auto-style25 {
            height: 23px;
            width: 229px;
        }
        .auto-style26 {
            width: 285px;
        }
        .auto-style27 {
            width: 97px;
            height: 23px;
        }
        .auto-style28 {
            width: 97px;
        }
        .auto-style30 {
            height: 23px;
            width: 112px;
        }
        .auto-style31 {
            width: 112px;
        }
        .auto-style32 {
            height: 23px;
            width: 106px;
        }
        .auto-style33 {
            width: 106px;
        }
        .auto-style37 {
            width: 147px;
        }
        .auto-style38 {
            height: 23px;
            width: 111px;
        }
        .auto-style39 {
            width: 111px;
        }
        .auto-style40 {
            width: 229px;
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
                                <asp:Button ID="btnCargaDatosArbolB" runat="server" Text="Cargar Datos Arbol B" Width="216px" OnClick="btnCargaDatosArbolB_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">
                                <asp:Button ID="MostrarArbolB" runat="server" Text="Mostrar Arbol B" Width="218px" OnClick="MostrarArbolB_Click" />
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
                            <td class="auto-style15"></td>
                            <td class="auto-style16"></td>
                            <td class="auto-style17">
                                <asp:Label ID="Label1" runat="server" Text="Nickname Oponente1: "></asp:Label>
                            </td>
                            <td class="auto-style18">
                                <asp:DropDownList ID="ddLstNickOp1" runat="server" Height="22px" Width="130px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style19"></td>
                            <td class="auto-style19"></td>
                        </tr>
                        <tr>
                            <td class="auto-style20"></td>
                            <td class="auto-style21"></td>
                            <td class="auto-style22">
                                <asp:Label ID="Label2" runat="server" Text="Nickname Opnente2: "></asp:Label>
                            </td>
                            <td class="auto-style23">
                                <asp:DropDownList ID="ddLstNickOp2" runat="server" Height="23px" Width="132px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style24"></td>
                            <td class="auto-style24"></td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style14"></td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
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
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">
                                <asp:Button ID="BtnConfigurar2" runat="server" OnClick="BtnConfigurar2_Click" Text="Configurar" Width="131px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">
                                <asp:Button ID="btnBack2" runat="server" Text="Regresar" Width="101px" OnClick="btnBack2_Click" />
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
                <asp:View ID="View3" runat="server">
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style7"></td>
                            <td class="auto-style27"></td>
                            <td class="auto-style25"></td>
                            <td class="auto-style7"></td>
                            <td class="auto-style7"></td>
                        </tr>
                        <tr>
                            <td class="auto-style39">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style28">
                                <asp:Button ID="btnSubirArchivoArbolB" runat="server" Text="Cargar Datos Al Historial" OnClick="btnSubirArchivoArbolB_Click" Width="196px" />
                            </td>
                            <td class="auto-style40">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style39">
                                <asp:Button ID="btnBack3" runat="server" Text="Regresar" Width="85px" OnClick="btnBack3_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style40">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View4" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style32"></td>
                            <td class="auto-style30"></td>
                            <td class="auto-style30"></td>
                        </tr>
                        <tr>
                            <td class="auto-style33">
                                <asp:Label ID="Label12" runat="server" Text="Oponente1"></asp:Label>
                            </td>
                            <td class="auto-style31">
                                <asp:DropDownList ID="ddLstGrafoOp1" runat="server" Height="16px" Width="132px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style31">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label13" runat="server" Text="Oponente2"></asp:Label>
                            </td>
                            <td class="auto-style37">
                                <asp:DropDownList ID="ddLstGrafoOp2" runat="server" Height="16px" Width="134px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style33">
                                <asp:Button ID="btnBack4" runat="server" Text="Regresar" Width="73px" OnClick="btnBack4_Click" />
                            </td>
                            <td class="auto-style31">&nbsp;</td>
                            <td class="auto-style31">
                                <asp:Button ID="btnGraficarB" runat="server" Text="GraficarArbol" Width="110px" OnClick="btnGraficarB_Click" />
                            </td>
                            <td class="auto-style37">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" />
                    <br />
                    <br />
                </asp:View>
                <br />
                <br />
                <br />
            </asp:MultiView>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
