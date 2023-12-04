<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="CSCI336_FinalProject.CSCI366FinalWork.Webpages.member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td style="width: 586px; height: 29px">&nbsp;<asp:Label ID="lblWelcome" runat="server" Font-Size="Large" Text="Welcome, "></asp:Label>
                <asp:LoginName ID="LoginName1" runat="server" Font-Size="Large" style="color: #0000FF" />
            </td>
            <td class="text-end" style="height: 29px">
                <asp:LoginStatus ID="LoginStatus1" runat="server" Font-Size="Large" LogoutText="Log Out" OnLoggingOut="LoginStatus1_LoggingOut" />
            </td>
        </tr>
    </table>
    <strong>
    <br />
    </strong>
    <asp:Label ID="lblLibrary" runat="server" Font-Bold="True" Font-Size="Large" Text="Library:"></asp:Label>
    <asp:GridView ID="gvLibrary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvLibrary_RowDataBound">
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
    <table style="width:100%;">
        <tr>
            <td style="width: 506px">Display All:</td>
            <td>
                <asp:Button ID="btnDisplayAll" runat="server" Text="Display All" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblFilter" runat="server" Font-Bold="True" Font-Size="Large" Text="Filters:"></asp:Label>
    <br />
&nbsp;<table style="width:100%;">
        <tr>
            <td style="height: 43px; width: 211px">Title:</td>
            <td style="width: 295px; height: 43px">
                <asp:TextBox ID="tbFilterTitle" runat="server"></asp:TextBox>
            </td>
            <td style="height: 43px">
                <asp:Button ID="btnFilterTitle" runat="server" Text="Filter By Title" />
            </td>
        </tr>
        <tr>
            <td style="width: 211px">Language:</td>
            <td style="width: 295px">
                <asp:TextBox ID="tbFilterLanguage" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFilterLanguage" runat="server" Text="Filter By Language" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblCheckOutBook" runat="server" Font-Bold="True" Font-Size="Large" Text="Check Out Book:"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="height: 43px; width: 211px">Book ID:</td>
            <td style="width: 295px; height: 43px">
                <asp:TextBox ID="tbCheckOutBook" runat="server"></asp:TextBox>
            </td>
            <td style="height: 43px">
                <asp:Button ID="btnCheckOutBook" runat="server" Text="Check Out Book" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblReturnBook" runat="server" Font-Bold="True" Font-Size="Large" Text="Return Book:"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="height: 43px; width: 211px">Book ID:</td>
            <td style="width: 295px; height: 43px">
                <asp:TextBox ID="tbReturnBook" runat="server"></asp:TextBox>
            </td>
            <td style="height: 43px">
                <asp:Button ID="btnReturnBook" runat="server" Text="Check Out Book" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="lblCheckedOutBooks" runat="server" Font-Bold="True" Font-Size="Large" Text="Current Checked Out Books:"></asp:Label>
    <br />
    <asp:GridView ID="gvCheckedOutBooks" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
</asp:Content>
