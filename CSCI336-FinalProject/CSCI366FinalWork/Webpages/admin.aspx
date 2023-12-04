<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="CSCI336_FinalProject.CSCI366FinalWork.Webpages.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 592px">
                <asp:Label ID="lblBooks" runat="server" Font-Bold="True" Font-Size="Large" Text="Books:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Users:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 592px">
                <asp:GridView ID="gvBooks" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="gvUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 233px">
                <asp:Label ID="lblBookInfo" runat="server" Font-Bold="True" Text="Book Info:"></asp:Label>
            </td>
            <td style="width: 356px">&nbsp;</td>
            <td>
                <asp:Label ID="lblUserInfo" runat="server" Font-Bold="True" Text="User Info:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">Title:</td>
            <td style="width: 356px">
                <asp:TextBox ID="tbBookTitle" runat="server"></asp:TextBox>
            </td>
            <td>First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserFirstname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">Publisher:</td>
            <td style="width: 356px">
                <asp:TextBox ID="tbBookPublisher" runat="server"></asp:TextBox>
            </td>
            <td>Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserLastname" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 233px">Language:</td>
            <td style="width: 356px">
                <asp:TextBox ID="tbBookLanguage" runat="server"></asp:TextBox>
            </td>
            <td>Is Admin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserIsAdmin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">Date Published:</td>
            <td style="width: 356px">
                <asp:TextBox ID="tbDatePublished" runat="server"></asp:TextBox>
            </td>
            <td>Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">
                <asp:Button ID="btnAddBook" runat="server" Text="Add Book" />
            </td>
            <td style="width: 356px">
                <asp:Label ID="lblInvalidBookInfo" runat="server" ForeColor="Red" Text="Invalid Book Info" Visible="False"></asp:Label>
            </td>
            <td>Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 231px">
                <asp:Label ID="lblUpdateDeleteBook" runat="server" Font-Bold="True" Text="Update / Delete Book:"></asp:Label>
            </td>
            <td style="width: 358px">&nbsp;</td>
            <td>Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 231px">Book ID:</td>
            <td style="width: 358px">
                <asp:TextBox ID="tbBookID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Update / Delete User:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 231px">
                <asp:Button ID="btnUpdateBook" runat="server" Text="Update Book" />
            </td>
            <td style="width: 358px">
                <asp:Label ID="lblInvalidBookID" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Invalid User Info" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 230px">
                <asp:Button ID="btnDeleteBook" runat="server" Text="Delete Book" />
            </td>
            <td style="width: 359px">
                <asp:Label ID="lblInvalidBookID2" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
            </td>
            <td>User ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 230px; height: 49px"></td>
            <td style="width: 359px; height: 49px"></td>
            <td style="height: 49px">
                <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Invalid User ID" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 230px">&nbsp;</td>
            <td style="width: 359px">&nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Invalid User ID" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
