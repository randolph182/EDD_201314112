﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="NavalWarsCliente.AdminUsuarios" %>

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
                <asp:Label ID="Label1" runat="server" Text="Administracion de Usuarios" Font-Size ="20pt"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" OnClick="btnAgregarUsuario_Click" Width="169px" />
                <br />
                <br />
                <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar Usuario" OnClick="btnModificarUsuario_Click" Width="168px" />
                <br />
                <br />
                <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar Usuario" Width="162px" OnClick="btnEliminarUsuario_Click" />
                <br />
                <br />
                <asp:Button ID="btnMostrarArbolGeneral" runat="server" Text="Mostrar Arbol" OnClick="btnMostrarArbolGeneral_Click" Width="167px" />
                <br />
                <br />
                <asp:Button ID="btnMostrarArbolEspejo" runat="server" Text="Mostrar Arbol Espejo" OnClick="btnMostrarArbolEspejo_Click" />
                <br />
                <br />
                <asp:Button ID="btnMostrarTopJuegos" runat="server" Text="Mostrar Top 10 Juegos" OnClick="btnMostrarTopJuegos_Click" />
                <br />
                <br />
                <asp:Button ID="btnRergresarPrincipalAdmin" runat="server" Text="Rergresar Principal" OnClick="btnRergresarPrincipalAdmin_Click" />
                <br />
            </asp:View>
            <br />
            <asp:View ID="View2" runat="server">
                <asp:Label ID="Label2" runat="server" Font-Size="20pt" Text="Agregar Nuevo Usurio "></asp:Label>
                <br />
                <br />
                <table style="width:100%;">
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
                        <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br /> </td>
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
                        <td>
                            &nbsp;</td>
                        
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
                <table style="width:100%;">
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
                            <asp:Button ID="btnRegresarUMod" runat="server" Text="Regresar" OnClick="btnRegresarUMod_Click" />
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style13">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style16">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
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
                <asp:Label ID="Label3" runat="server" Text="Eliminacion de Usuarios" Font-Size ="25pt"></asp:Label>
                <br />
                <br />
                <table style="width:100%;">
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
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblMensajeElimUsuario" runat="server" Text="[ ]"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style4">
                            <asp:Button ID="btnRegresarElimU" runat="server" Text="Regresar" OnClick="btnRegresarElimU_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>

                </table>
                <br />
            </asp:View>
            <br />
            <asp:View ID="View5" runat="server">
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image1" runat="server" Height="644px" ImageUrl="C:\GrafoEDD\ABBUsuarios.png" Width="1405px" />
                <br />
                <br />
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
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
