<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguarcionInicialUsuario.aspx.cs" Inherits="NavalWarsCliente.ConfiguarcionInicialUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style12 {
            height: 23px;
            width: 325px;
        }

        .auto-style13 {
            width: 325px;
        }

        .auto-style14 {
            width: 325px;
            height: 30px;
        }

        .auto-style15 {
            height: 23px;
            width: 243px;
        }

        .auto-style16 {
            width: 243px;
        }

        .auto-style17 {
            width: 243px;
            height: 30px;
        }

        .auto-style21 {
            height: 23px;
            width: 198px;
        }

        .auto-style22 {
            width: 198px;
        }

        .auto-style23 {
            width: 198px;
            height: 30px;
        }

        .auto-style24 {
            width: 565px;
        }

        .auto-style25 {
            height: 23px;
            width: 278px;
        }

        .auto-style26 {
            width: 278px;
        }

        .auto-style27 {
            width: 278px;
            height: 30px;
        }

        .auto-style28 {
            width: 243px;
            text-decoration: underline;
        }

        .auto-style29 {
            text-decoration: underline;
        }

        .auto-style30 {
            width: 118px;
        }

        .auto-style31 {
            width: 172px;
        }

        .auto-style32 {
            width: 148px;
        }

        .auto-style33 {
            width: 118px;
            height: 26px;
        }

        .auto-style34 {
            width: 172px;
            height: 26px;
        }

        .auto-style35 {
            width: 148px;
            height: 26px;
        }

        .auto-style36 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Configuaracion Inicial NavalWars" Font-Size="30pt"></asp:Label>
            <br />
            <br />
            <br />
            <table style="width: 116%; height: 316px;">
                <tr>
                    <td class="auto-style24">
                        <table style="width: 99%;">
                            <tr>
                                <td class="auto-style25">
                                    <asp:Label ID="Label2" runat="server" Text="ID Usuario: "></asp:Label>
                                </td>
                                <td class="auto-style15">
                                    <asp:TextBox ID="txtIDUsuario" runat="server" Width="145px" Enabled="False" CssClass="auto-style29"></asp:TextBox>
                                </td>
                                <td class="auto-style21"></td>
                                <td class="auto-style12"></td>
                            </tr>
                            <tr>
                                <td class="auto-style25"></td>
                                <td class="auto-style15"></td>
                                <td class="auto-style21"></td>
                                <td class="auto-style12"></td>


                            </tr>
                            <tr>
                                <td class="auto-style25"></td>
                                <td class="auto-style15"></td>
                                <td class="auto-style21">
                                    <asp:Label ID="Label3" runat="server" Text="Submarinos" Font-Size="18pt"></asp:Label>
                                </td>
                                <td class="auto-style12"></td>


                            </tr>
                            <tr>
                                <td class="auto-style26">&nbsp;</td>
                                <td class="auto-style16"><span class="auto-style29">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </span>
                                    <asp:Label ID="Label4" runat="server" Text="Cantidad Unidades: " CssClass="auto-style29"></asp:Label>
                                </td>
                                <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCantidadSubmarinos" runat="server" Width="38px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">&nbsp;</td>


                            </tr>
                            <tr>
                                <td class="auto-style26"></td>
                                <td class="auto-style16"><span class="auto-style29">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </span>
                                    <asp:Label ID="Label5" runat="server" Text="Nivel de la Unidad" CssClass="auto-style29"></asp:Label>
                                </td>
                                <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="0 "></asp:Label>
                                </td>
                                <td class="auto-style13"></td>


                            </tr>
                            <tr>
                                <td class="auto-style27"></td>
                                <td class="auto-style17"><span class="auto-style29">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </span>
                                    <asp:Label ID="Label7" runat="server" Text="Fila :" CssClass="auto-style29"></asp:Label>
                                </td>
                                <td class="auto-style23">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFilaSubmarinos" runat="server" Width="38px"></asp:TextBox>
                                </td>
                                <td class="auto-style14"></td>


                            </tr>
                            <tr>
                                <td class="auto-style26">&nbsp;</td>
                                <td class="auto-style16"><span class="auto-style29">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </span>
                                    <asp:Label ID="Label8" runat="server" Text="Columna: " CssClass="auto-style29"></asp:Label>
                                </td>
                                <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtColumnaSubmarinos" runat="server" Width="37px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">&nbsp;</td>


                            </tr>
                            <tr>
                                <td class="auto-style26">&nbsp;</td>
                                <td class="auto-style28">&nbsp;</td>
                                <td class="auto-style22">&nbsp;&nbsp;
                        <asp:Button ID="btnInsertarSubmarino" runat="server" Text="insertar" Width="109px" />
                                </td>
                                <td class="auto-style13">&nbsp;</td>


                            </tr>
                            <tr>
                                <td class="auto-style25"></td>
                                <td class="auto-style15"></td>
                                <td class="auto-style21"></td>
                                <td class="auto-style12"></td>
                            </tr>


                        </table>

                    </td>
                    <td>&nbsp;
                        <asp:Image ID="imgSubmarinos" runat="server" Height="291px" Width="459px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 97%;">
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label11" runat="server" Text="Barcos" Font-Size="20pt"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label10" runat="server" Text="Cantidad de Unidades: "></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCantidadUnidadesBarcos" runat="server" Width="44px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label13" runat="server" Text="Nivel de la Unidad :"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label14" runat="server" Text="1"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style33"></td>
                                <td class="auto-style34">
                                    <asp:Label ID="Label12" runat="server" Text="Escoger el tipo de Unidad: "></asp:Label>
                                </td>
                                <td class="auto-style35">
                                    <asp:DropDownList ID="ddLstUnidadBarcos" runat="server" Height="21px" Width="147px">
                                        <asp:ListItem>Crucero</asp:ListItem>
                                        <asp:ListItem>Fragata</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style36"></td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label15" runat="server" Text="Fila"></asp:Label>
                                    :</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFilaBarcos" runat="server" Width="39px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label16" runat="server" Text="Columna:"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtColumnaBarcos" runat="server" Width="40px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInsertarBarcos" runat="server" Text="Insertar " Width="114px" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Image ID="imgBarcos" runat="server" Height="291px" Width="459px" />
                    </td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                                <tr>
                    <td>
                        <table style="width: 97%; height: 277px;">
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label17" runat="server" Text="Aviones" Font-Size="20pt"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label18" runat="server" Text="Cantidad de Unidades: "></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCantidadUnidadesAviones" runat="server" Width="44px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label19" runat="server" Text="Nivel de la Unidad :"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label20" runat="server" Text="2"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style33"></td>
                                <td class="auto-style34">
                                    <asp:Label ID="Label21" runat="server" Text="Escoger el tipo de Unidad: "></asp:Label>
                                </td>
                                <td class="auto-style35">
                                    <asp:DropDownList ID="ddLstUnidadAviones" runat="server" Height="21px" Width="147px">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style36"></td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label22" runat="server" Text="Fila"></asp:Label>
                                    :</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFilaAvion" runat="server" Width="42px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label23" runat="server" Text="Columna:"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtColumnaAvion" runat="server" Width="40px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="bntInsertarAviones" runat="server" Text="Insertar" Width="114px" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                                    </td>
                    <td>
                        <asp:Image ID="imgAviones" runat="server" Height="291px" Width="459px" />
                                    </td>
                    <td></td>
                </tr>
                                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                                <tr>
                    <td>
                        <table style="width: 97%; height: 277px;">
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label24" runat="server" Text="NeoSatelites" Font-Size="20pt"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label25" runat="server" Text="Cantidad de Unidades: "></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCantidadUnidadesSatelites" runat="server" Width="44px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label26" runat="server" Text="Nivel de la Unidad :"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label27" runat="server" Text="3"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style33"></td>
                                <td class="auto-style34">
                                    <asp:Label ID="Label29" runat="server" Text="Fila"></asp:Label>
                                </td>
                                <td class="auto-style35">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtFilaSatelites" runat="server" Width="35px"></asp:TextBox>
                                </td>
                                <td class="auto-style36"></td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    <asp:Label ID="Label30" runat="server" Text="Columna:"></asp:Label>
                                </td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtColumnaSatelites" runat="server" Width="40px" Height="22px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">
                                    &nbsp;</td>
                                <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInsertarSatelites" runat="server" Text="Insertar" Width="114px" />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style30">&nbsp;</td>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style32">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                                    </td>
                    <td>
                        <asp:Image ID="imgSatelites" runat="server" Height="291px" Width="459px" />
                                    </td>
                    <td></td>
                </tr>

            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
