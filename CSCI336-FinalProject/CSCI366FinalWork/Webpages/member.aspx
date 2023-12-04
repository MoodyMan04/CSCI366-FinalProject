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
    <br />
    Total Library Book Count:
    <asp:Label ID="lblBookCount" runat="server" Font-Bold="True" ForeColor="Blue" Text="count"></asp:Label>
&nbsp;<asp:GridView ID="gvLibrary" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvLibrary_RowDataBound" Width="674px">
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
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 509px">Display All:</td>
            <td>
                <asp:Button ID="btnDisplayAll" runat="server" OnClick="btnDisplayAll_Click" style="margin-left: 42" Text="Display All" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblFilter" runat="server" Font-Bold="True" Font-Size="Large" Text="Filters:"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 211px">Book ID:</td>
            <td style="width: 295px">
                <asp:TextBox ID="tbFilterBookID" runat="server" style="margin-left: 4"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFilterBookID" runat="server" OnClick="btnFilterBookID_Click" Text="Filter By Book ID" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidBookID" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
&nbsp;<table style="width:100%;">
        <tr>
            <td style="height: 43px; width: 211px">Title:</td>
            <td style="width: 295px; height: 43px">
                <asp:TextBox ID="tbFilterTitle" runat="server"></asp:TextBox>
            </td>
            <td style="height: 43px">
                <asp:Button ID="btnFilterTitle" runat="server" OnClick="btnFilterTitle_Click" Text="Filter By Title" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidTitle" runat="server" ForeColor="Red" Text="Invalid Title" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 211px; height: 43px">Language:</td>
            <td style="width: 295px; height: 43px">
                <asp:TextBox ID="tbFilterLanguage" runat="server"></asp:TextBox>
            </td>
            <td style="height: 43px">
                <asp:Button ID="btnFilterLanguage" runat="server" OnClick="btnFilterLanguage_Click" Text="Filter By Language" />
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidLanguage" runat="server" ForeColor="Red" Text="Invalid Language" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 209px">Author:</td>
            <td style="width: 297px">
                <asp:TextBox ID="tbFilterAuthor" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFilterAuthor" runat="server" Text="Filter By Author" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidAuthor" runat="server" ForeColor="Red" Text="Invalid Author" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 209px; height: 49px">Required Class:</td>
            <td style="width: 297px; height: 49px">
                <asp:TextBox ID="tbFilterClass" runat="server" CssClass="offset-sm-0"></asp:TextBox>
            </td>
            <td style="height: 49px">
                <asp:Button ID="btnFilterClass" runat="server" Text="Filter By Class" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidClass" runat="server" ForeColor="Red" Text="Invalid Class" Visible="False"></asp:Label>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidBookID2" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidBookID3" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
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
