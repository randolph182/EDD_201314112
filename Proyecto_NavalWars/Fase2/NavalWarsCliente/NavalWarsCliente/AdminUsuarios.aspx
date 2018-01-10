<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="NavalWarsCliente.AdminUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 460px;
        }

        .auto-style4 {
            width: 76px;
        }

        .auto-style5 {
            width: 421px;
        }

        .auto-style7 {
            width: 85px;
        }

        .auto-style13 {
            width: 126px;
        }

        .auto-style14 {
            width: 173px;
        }

        .auto-style15 {
            width: 171px;
        }

        .auto-style16 {
            width: 152px;
        }

        .auto-style18 {
            width: 228px;
        }

        .auto-style19 {
            width: 421px;
            height: 30px;
        }

        .auto-style20 {
            width: 76px;
            height: 30px;
        }

        .auto-style21 {
            height: 30px;
        }
        .auto-style26 {
            width: 66px;
        }
        .auto-style27 {
            width: 210px;
        }
        .auto-style28 {
            width: 157px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />
            <asp:MultiView ID="MultiView1" runat="server">
                <br />
                <asp:View ID="View1" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Administracion de Usuarios" Font-Size="20pt"></asp:Label>
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnAgregarUsuario" runat="server" OnClick="btnAgregarUsuario_Click" Text="Agregar Usuario" Width="216px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnModificarUsuario" runat="server" OnClick="btnModificarUsuario_Click" Text="Modificar Usuario" Width="214px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnEliminarUsuario" runat="server" OnClick="btnEliminarUsuario_Click" Text="Eliminar Usuario" Width="215px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnMostrarArbolGeneral" runat="server" OnClick="btnMostrarArbolGeneral_Click" Text="Mostrar Arbol" Width="212px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnMostrarArbolEspejo" runat="server" OnClick="btnMostrarArbolEspejo_Click" Text="Mostrar Arbol Espejo" Width="211px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnMostrarTopJuegos" runat="server" OnClick="btnMostrarTopJuegos_Click" Text="Mostrar Top 10 Juegos" Width="209px" />
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="btnTopMascontactos" runat="server" Text="Mostrar Top 10 Mas Contactos" Width="215px" OnClick="btnTopMascontactos_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">
                                <asp:Button ID="bntGrafoTablaHash" runat="server" OnClick="bntGrafoTablaHash_Click" Text="Mostrar Tabla Hash " Width="212px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">
                                <asp:Button ID="btnRergresarPrincipalAdmin" runat="server" OnClick="btnRergresarPrincipalAdmin_Click" Text="Rergresar Principal" />
                            </td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style26">&nbsp;</td>
                            <td class="auto-style27">&nbsp;</td>
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
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="Label2" runat="server" Font-Size="20pt" Text="Agregar Nuevo Usurio "></asp:Label>
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nickname:</td>
                            <td>
                                <asp:TextBox ID="txtNicknameNU" runat="server" Width="165px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nombre:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtNombreNU" runat="server" Width="163px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password:</td>
                            <td>
                                <asp:TextBox ID="txtPasswordNU" runat="server" Width="162px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtEmailNU" runat="server" Width="159px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                            </td>
                            <td>
                                <br />
                                <asp:Button ID="btnAgregarNuevoUsuario" runat="server" Text="Agregar" Width="137px" OnClick="btnAgregarNuevoUsuario_Click" />
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                            <td>
                                <asp:Label ID="lblMensajeAddUsuario" runat="server" Text="[ ]"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                            <td>
                                <asp:Button ID="btnMostrarArbol" runat="server" Text="mostrarArbol" OnClick="btnMostrarArbol_Click" />
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Rergresar" />
                            </td>
                            <td>&nbsp;</td>

                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="Label4" runat="server" Font-Size="25pt" Text="Modificacion de Usuarios"></asp:Label>
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">Nickname:</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtNickNameNuevoUMod" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">Nombre:</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtNombreUMod" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">Nickname del Usuario:</td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtNickNameUMod" runat="server" Width="134px"></asp:TextBox>
                            </td>
                            <td class="auto-style7">Password:</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtPasswordUMod" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">
                                <br />
                            </td>
                            <td class="auto-style14">
                                <asp:Button ID="btnBuscarNickUMod" runat="server" Text="Buscar" OnClick="btnBuscarNickUMod_Click" />
                            </td>
                            <td class="auto-style7">Email:</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtEmailUMod" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">Conectado</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtConectadoUMod" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">
                                <br />
                                <br />
                            </td>
                            <td class="auto-style13">
                                <asp:Button ID="btnModificarUMod" runat="server" Text="Modificar" OnClick="btnModificarUM_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style13">
                                <asp:Label ID="lblMensajeUModificado" runat="server" Text="[ ]"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">
                                <asp:Button ID="btnMostrarArbolModUsuario" runat="server" Text="Mostrar Arbol" Width="110px" Style="margin-top: 0px" OnClick="btnMostrarArbolModUsuario_Click" />
                            </td>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                            <td class="auto-style14">
                                <asp:Button ID="btnRegresarUMod" runat="server" OnClick="btnRegresarUMod_Click" Text="Regresar" />
                            </td>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                    </table>
                    <br />
                    <br />
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View4" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Eliminacion de Usuarios" Font-Size="25pt"></asp:Label>
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style4">Nickname:</td>
                            <td>
                                <asp:TextBox ID="txtNicknameElimU" runat="server" Width="171px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>
                                <br />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="124px" OnClick="btnEliminar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMensajeElimUsuario" runat="server" Text="[ ]"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19"></td>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style21">
                                <asp:Button ID="btnMostrarArbolElimUsuaio" runat="server" Text="MostrarArbol" Width="124px" OnClick="btnMostrarArbolElimUsuaio_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19"></td>
                            <td class="auto-style20">
                                <asp:Button ID="btnRegresarElimU" runat="server" Text="Regresar" OnClick="btnRegresarElimU_Click" />
                            </td>
                            <td class="auto-style21"></td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                <br />
                <asp:View ID="View5" runat="server">
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style18">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                <asp:Button ID="Button1" runat="server" Text="Regresar" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                    <br />
                    <asp:Image ID="Image1"
                        runat="server" />
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
