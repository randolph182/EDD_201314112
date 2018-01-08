<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminContactosUsuarios.aspx.cs" Inherits="NavalWarsCliente.AdminContactosUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 281px;
        }

        .auto-style5 {
            width: 226px;
        }

        .auto-style7 {
            height: 23px;
            width: 167px;
        }

        .auto-style11 {
            width: 407px;
        }

        .auto-style13 {
            height: 23px;
            width: 150px;
        }

        .auto-style14 {
            width: 150px;
        }

        .auto-style16 {
            height: 23px;
            width: 72px;
        }

        .auto-style18 {
            height: 23px;
            width: 248px;
        }

        .auto-style22 {
            width: 72px;
        }

        .auto-style26 {
            width: 74px;
        }

        .auto-style27 {
            height: 23px;
            width: 74px;
        }

        .auto-style28 {
            width: 69px;
        }

        .auto-style29 {
            height: 23px;
            width: 69px;
        }

        .auto-style32 {
            width: 248px;
        }

        .auto-style36 {
            width: 138px;
        }
        .auto-style38 {
            width: 138px;
            height: 30px;
        }
        .auto-style39 {
            height: 30px;
        }
        .auto-style52 {
            width: 146px;
        }
        .auto-style53 {
            width: 146px;
            height: 30px;
        }
        .auto-style54 {
            width: 101px;
        }
        .auto-style55 {
            width: 101px;
            height: 30px;
        }
        .auto-style56 {
            width: 78px;
        }
        .auto-style57 {
            width: 78px;
            height: 30px;
        }
        .auto-style58 {
            width: 84px;
        }
        .auto-style59 {
            height: 30px;
            width: 84px;
        }
        .auto-style60 {
            width: 132px;
        }
        .auto-style61 {
            width: 151px;
        }
        .auto-style62 {
            width: 152px;
        }
        .auto-style63 {
            height: 23px;
        }
        .auto-style64 {
            width: 132px;
            height: 23px;
        }
        .auto-style65 {
            width: 151px;
            height: 23px;
        }
        .auto-style66 {
            width: 152px;
            height: 23px;
        }
        .auto-style67 {
            height: 23px;
            width: 238px;
        }
        .auto-style68 {
            width: 238px;
        }
        .auto-style69 {
            height: 23px;
            width: 175px;
        }
        .auto-style70 {
            width: 175px;
        }
        .auto-style71 {
            width: 238px;
            height: 27px;
        }
        .auto-style72 {
            width: 175px;
            height: 27px;
        }
        .auto-style73 {
            height: 27px;
        }
        .auto-style74 {
            width: 260px;
        }
        .auto-style75 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:MultiView ID="MultiView1" runat="server">
                <br />
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style5">
                                <br />
                                <asp:Button ID="btnADDContacto" runat="server" Height="31px" Text="Agregar Contacto a Usuario" Width="239px" OnClick="btnADDContacto_Click" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Button ID="btnModContacto" runat="server" Height="31px" Text="Modificar Contacto de Usuario" Width="241px" OnClick="btnModContacto_Click" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Button ID="btnDelContacto" runat="server" Height="31px" Text="Eliminar Contacto de Usuario" Width="239px" OnClick="btnDelContacto_Click" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Button ID="btnMostrarAVLContacto" runat="server" Height="31px" Text="Mostar AVL de Contactos" Width="238px" OnClick="btnMostrarAVLContacto_Click" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Button ID="btnBackpricipal" runat="server" Text="Regresar Al menu Principal" OnClick="btnBackpricipal_Click" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View2" runat="server">
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Agregar Contacos a usuario" Font-Size="40pt"></asp:Label>
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style22">&nbsp;</td>
                            <td class="auto-style32">
                                <br />
                                <br />
                            </td>
                            <td class="auto-style74">
                                <asp:Label ID="Label2" runat="server" Text="Escoger Usuario de ABB :"></asp:Label>
                            </td>
                            <td class="auto-style75">

                                <asp:DropDownList ID="ddListLstNickABB" runat="server" Height="27px" OnSelectedIndexChanged="ddListLstNickABB_SelectedIndexChanged" Width="148px">
                                </asp:DropDownList>

                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style27"></td>
                            <td class="auto-style29">
                                <asp:Label ID="Label1" runat="server" Text="seleccione un usuario"></asp:Label>
                            </td>
                            <td class="auto-style13">
                                <asp:DropDownList ID="ddListNickADDContacto" runat="server" Height="28px" Width="144px">
                                    <asp:ListItem>Selecionar un Usuario </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Text="NickName: "></asp:Label>
                            </td>
                            <td class="auto-style18">
                                <asp:TextBox ID="txtNickNameADDContacto" runat="server" Width="198px"></asp:TextBox>
                            </td>
                            <td class="auto-style74"></td>
                            <td class="auto-style75">

                                <asp:Button ID="btnADDContactoSeleccion" runat="server" Text="Agregar a contactos" Width="126px" OnClick="btnADDContactoSeleccion_Click" />

                            </td>
                            <td class="auto-style7"></td>
                        </tr>
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="Password : "></asp:Label>
                            </td>
                            <td class="auto-style32">
                                <asp:TextBox ID="txtPasswordADDContacto" runat="server" Width="202px"></asp:TextBox>
                            </td>
                            <td class="auto-style74">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="Corrreo : "></asp:Label>
                            </td>
                            <td class="auto-style32">
                                <asp:TextBox ID="txtEmailADDContacto" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="auto-style74">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style22">&nbsp;</td>
                            <td class="auto-style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAgregarContacto_1" runat="server" Text="Agregar Contacto" Width="139px" OnClick="btnAgregarContacto_1_Click" />
                            </td>
                            <td class="auto-style74">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnBackADDContacto" runat="server" Text="Regresar Pagina Pricipal" />
                            </td>
                            <td class="auto-style22">&nbsp;</td>
                            <td class="auto-style32">&nbsp;</td>
                            <td class="auto-style74">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style22">&nbsp;</td>
                            <td class="auto-style32">
                                <asp:Button ID="btnShowAVLADDCont" runat="server" Text="Mostrar Grafo" OnClick="btnShowAVLADDCont_Click" />
                            </td>
                            <td class="auto-style74">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="Label7" runat="server" Font-Size="40pt" Text="Modificar Contacto de Usuario"></asp:Label>
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style52">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label8" runat="server" Text="Seleccione un usuario"></asp:Label>
                            </td>
                            <td class="auto-style36">
                                <asp:DropDownList ID="ddLstSelectUsusarioModConctac" runat="server" Height="16px" Style="margin-top: 0px" Width="146px">
                                    <asp:ListItem>Seleccione a un usuario</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style56">&nbsp;</td>
                            <td class="auto-style54">&nbsp;</td>
                            <td class="auto-style58">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style53"></td>
                            <td class="auto-style38">
                                <asp:Button ID="bntSelectUsuarioModContact" runat="server" Text="SeleccionarUsuario" Width="143px" OnClick="bntSelectUsuarioModContact_Click" />
                            </td>
                            <td class="auto-style57">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label10" runat="server" Text="nickname"></asp:Label>
                            </td>
                            <td class="auto-style55">
                                <asp:TextBox ID="txtNickContactoModContact" runat="server" Width="188px"></asp:TextBox>
                            </td>
                            <td class="auto-style59">&nbsp; &nbsp;<asp:Label ID="Label13" runat="server" Text="modNick"></asp:Label>
                            </td>
                            <td class="auto-style39">
                                <asp:TextBox ID="txtNickModModContact" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style52">&nbsp;</td>
                            <td class="auto-style36">&nbsp;</td>
                            <td class="auto-style56">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label11" runat="server" Text="password"></asp:Label>
                            </td>
                            <td class="auto-style54">
                                <asp:TextBox ID="txtPassModContac" runat="server" Width="182px"></asp:TextBox>
                            </td>
                            <td class="auto-style58">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style52">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label9" runat="server" Text="Seleccione un Contacto"></asp:Label>
                            </td>
                            <td class="auto-style36">
                                <asp:DropDownList ID="ddLstSelectContactModConcta" runat="server" Height="16px" Width="141px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style56">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label12" runat="server" Text="email"></asp:Label>
                            </td>
                            <td class="auto-style54">
                                <asp:TextBox ID="txtEmailModContact" runat="server" Width="170px"></asp:TextBox>
                            </td>
                            <td class="auto-style58">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style52">&nbsp;</td>
                            <td class="auto-style36">
                                <asp:Button ID="btnSelectConctacoModContact" runat="server" Text="Seleccionar Contacto" Width="139px" OnClick="btnSelectConctacoModContact_Click" />
                            </td>
                            <td class="auto-style56">&nbsp;</td>
                            <td class="auto-style54">&nbsp;</td>
                            <td class="auto-style58">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style52">&nbsp;</td>
                            <td class="auto-style36">
                                &nbsp;</td>
                            <td class="auto-style56">&nbsp;</td>
                            <td class="auto-style54">
                                <asp:Button ID="btnModContacto_2" runat="server" Text="modificar Contacto" OnClick="btnModContacto_2_Click" />
                            </td>
                            <td class="auto-style58">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style53"></td>
                            <td class="auto-style38">
                                <asp:Button ID="Button4" runat="server" Text="Regresar" />
                            </td>
                            <td class="auto-style57"></td>
                            <td class="auto-style55"></td>
                            <td class="auto-style59"></td>
                            <td class="auto-style39"></td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View4" runat="server">
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                            <td class="auto-style61">&nbsp;</td>
                            <td class="auto-style62">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style60">
                                <asp:Label ID="Label14" runat="server" Text="Escoja un Usuario"></asp:Label>
                            </td>
                            <td class="auto-style61">
                                <asp:DropDownList ID="ddLstUsuarioElim" runat="server" Height="19px" Width="142px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style62">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label15" runat="server" Text="escoja un contacto"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddLstContactoElim" runat="server" Height="22px" Width="158px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                            <td class="auto-style61">
                                <asp:Button ID="btnnickUsuarioElim" runat="server" Text="Escoja un ususario" OnClick="btnnickUsuarioElim_Click" />
                            </td>
                            <td class="auto-style62">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnContactoElim" runat="server" Text="Eliminar contacto" OnClick="btnContactoElim_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style63"></td>
                            <td class="auto-style64"></td>
                            <td class="auto-style65"></td>
                            <td class="auto-style66">
                                <asp:Button ID="btnMostrarGrafoElim" runat="server" Text="MostrarGrafo" OnClick="btnMostrarGrafoElim_Click" />
                            </td>
                            <td class="auto-style63">
                                <asp:Label ID="lblElimiado" runat="server" Text="[]"></asp:Label>
                            </td>
                            <td class="auto-style63"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style60">&nbsp;</td>
                            <td class="auto-style61">
                                <asp:Button ID="btnBackMainElim" runat="server" Text="Regresar" />
                            </td>
                            <td class="auto-style62">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View5" runat="server">
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnBackGrafo" runat="server" Text="Regresar a la pagina principal" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <asp:Image ID="Image1" runat="server" />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View6" runat="server">
                    <br />
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style67">
                                <asp:Button ID="Button6" runat="server" Text="Button" />
                            </td>
                            <td class="auto-style69"></td>
                            <td class="auto-style63"></td>
                        </tr>
                        <tr>
                            <td class="auto-style71"></td>
                            <td class="auto-style72">
                                <asp:DropDownList ID="ddLstUsuariosMostrarGrafo" runat="server" Height="18px" Width="156px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style73"></td>
                        </tr>
                        <tr>
                            <td class="auto-style68">&nbsp;</td>
                            <td class="auto-style70">
                                <asp:Button ID="Button5" runat="server" Text="mostrarGrafoAVLContacotos" OnClick="Button5_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image2" runat="server" />
                    <br />
                    <br />
                </asp:View>
                <br />
                <br />
            </asp:MultiView>
            <br />

        </div>
    </form>
</body>
</html>
