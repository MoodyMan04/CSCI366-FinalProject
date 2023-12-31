﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="CSCI336_FinalProject.CSCI366FinalWork.Webpages.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 823px">
                <asp:Label ID="lblWelcome" runat="server" Font-Bold="False" Font-Size="Large" Text="Welcome, "></asp:Label>
                <asp:LoginName ID="LoginName1" runat="server" Font-Size="Large" ForeColor="Blue" />
            </td>
            <td style="width: 158px">
                <asp:HyperLink ID="hlMember" runat="server" NavigateUrl="~/CSCI366FinalWork/Webpages/member.aspx">Member Page</asp:HyperLink>
            </td>
            <td>
                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Log Out" OnLoggingOut="LoginStatus1_LoggingOut" />
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 592px">
                <br />
                <asp:Label ID="lblBooks" runat="server" Font-Bold="True" Font-Size="Large" Text="Books:"></asp:Label>
            </td>
            <td>
                <br />
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
                <asp:CheckBox ID="chkUserIsAdmin" runat="server" Text="Is Admin?" />
            </td>
        </tr>
        <tr>
            <td style="width: 233px">Date Published:</td>
            <td style="width: 356px">
                <asp:TextBox ID="tbBookDatePublished" runat="server"></asp:TextBox>
            </td>
            <td>Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">
                <asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" />
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
                &nbsp;</td>
            <td style="width: 358px">&nbsp;</td>
            <td>Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 231px">&nbsp;</td>
            <td style="width: 358px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidUserInfo" runat="server" ForeColor="Red" Text="Invalid User Info" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 231px">
                <asp:Label ID="lblUpdateDeleteBook" runat="server" Font-Bold="True" Text="Update / Delete Book:"></asp:Label>
            </td>
            <td style="width: 358px">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Update / Delete User:"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 230px">
                Book ID:</td>
            <td style="width: 359px">
                <asp:TextBox ID="tbBookID" runat="server"></asp:TextBox>
            </td>
            <td>User ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUserID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 230px; height: 49px">
                <asp:Button ID="btnUpdateBook" runat="server" Text="Update Book" OnClick="btnUpdateBook_Click" />
            </td>
            <td style="width: 359px; height: 49px">
                <asp:Label ID="lblInvalidBookInfo2" runat="server" ForeColor="Red" Text="Invalid Book Info" Visible="False"></asp:Label>
            </td>
            <td style="height: 49px">
                <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" OnClick="btnUpdateUser_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidUserInfo2" runat="server" ForeColor="Red" Text="Invalid User ID" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 230px">
                <asp:Button ID="btnDeleteBook" runat="server" Text="Delete Book" OnClick="btnDeleteBook_Click" />
            </td>
            <td style="width: 359px">
                <asp:Label ID="lblInvalidBookID" runat="server" ForeColor="Red" Text="Invalid Book ID" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidUserID" runat="server" ForeColor="Red" Text="Invalid User ID" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 591px">
                <asp:Label ID="lblAuthors" runat="server" Font-Bold="True" Font-Size="Large" Text="Authors:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblClasses" runat="server" Font-Bold="True" Font-Size="Large" Text="Classes:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 591px">
                <asp:GridView ID="gvAuthors" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <asp:GridView ID="gvClasses" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <tr>
            <td style="width: 591px">
                <asp:Label ID="lblAuthorInfo" runat="server" Font-Bold="True" Text="Author Info:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblClassInfo" runat="server" Font-Bold="True" Text="Class Info:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 240px">First Name:</td>
            <td style="width: 350px">
                <asp:TextBox ID="tbAuthorFirstname" runat="server"></asp:TextBox>
            </td>
            <td>Class Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbClassName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 240px">Last Name:</td>
            <td style="width: 350px">
                <asp:TextBox ID="tbAuthorLastname" runat="server"></asp:TextBox>
            </td>
            <td>Class Description:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbClassDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:Button ID="btnAddAuthor" runat="server" Text="Add Author" OnClick="btnAddAuthor_Click" />
            </td>
            <td style="width: 350px">
                <asp:Label ID="lblInvalidAuthorInfo" runat="server" ForeColor="Red" Text="Invalid Author Info" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidClassInfo" runat="server" ForeColor="Red" Text="Invalid Class Info" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 240px">Author ID:</td>
            <td style="width: 351px">
                <asp:TextBox ID="tbAuthorID" runat="server"></asp:TextBox>
            </td>
            <td>Class ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbClassID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:Button ID="btnUpdateAuthor" runat="server" Text="Update Author" OnClick="btnUpdateAuthor_Click" />
            </td>
            <td style="width: 351px">
                <asp:Label ID="lblInvalidAuthorInfo2" runat="server" ForeColor="Red" Text="Invalid Author Info" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnUpdateClass" runat="server" Text="Update Class" OnClick="btnUpdateClass_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidClassInfo2" runat="server" ForeColor="Red" Text="Invalid Class Info" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:Button ID="btnDeleteAuthor" runat="server" Text="Delete Author" OnClick="btnDeleteAuthor_Click" />
            </td>
            <td style="width: 351px">
                <asp:Label ID="lblInvalidAuthorID" runat="server" ForeColor="Red" Text="Invalid Author ID" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnDeleteClass" runat="server" Text="Delete Class" OnClick="btnDeleteClass_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidClassID" runat="server" ForeColor="Red" Text="Invalid Class ID" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 593px">
                <asp:Label ID="lblCheckedOut" runat="server" Font-Bold="True" Font-Size="Large" Text="Checked Out:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAssociatedWith" runat="server" Font-Bold="True" Font-Size="Large" Text="Associated With:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 593px">
                <asp:GridView ID="gvCheckedOut" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <asp:GridView ID="gvAssociatedWith" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <tr>
            <td style="width: 593px">
                <asp:CheckBox ID="cbDisplayCheckedOutBooks" runat="server" Text="Display only currently checked out books" AutoPostBack="True" OnCheckedChanged="cbDisplayCheckedOutBooks_CheckedChanged" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 309px">
                &nbsp;</td>
            <td style="width: 281px">&nbsp;</td>
            <td>
                <asp:Label ID="lblAssociatedWithInfo" runat="server" Font-Bold="True" Font-Size="Medium" Text="Associated With Info:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 309px">&nbsp;</td>
            <td style="width: 281px">
                &nbsp;</td>
            <td>Class ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbAssociatedWithClassID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px">&nbsp;</td>
            <td style="width: 281px">
                &nbsp;</td>
            <td>Book ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbAssociatedWithBookID" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="height: 41px; width: 310px">&nbsp;</td>
            <td style="height: 41px; width: 280px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="height: 41px">Is Required:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkIsRequired" runat="server" Text="Is Required?" />
            </td>
        </tr>
        <tr>
            <td style="width: 310px">&nbsp;</td>
            <td style="width: 280px">
                &nbsp;</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;</td>
            <td style="width: 280px">&nbsp;</td>
            <td>
                <asp:Button ID="btnAddAssociatedWith" runat="server" Text="Add Association" OnClick="btnAddAssociatedWith_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidAssociationInfo" runat="server" ForeColor="Red" Text="Invalid Association Info" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 310px">
                &nbsp;</td>
            <td style="width: 279px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnUpdateAssociatedWith" runat="server" Text="Update Association" OnClick="btnUpdateAssociatedWith_Click" />
&nbsp;&nbsp;
                <asp:Label ID="lblInvalidAssociationInfo2" runat="server" ForeColor="Red" Text="Invalid Association Info" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;</td>
            <td style="width: 279px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteAssociatedWith" runat="server" Text="Delete Association" OnClick="btnDeleteAssociatedWith_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidAssociationInfo3" runat="server" ForeColor="Red" Text="Invalid Association Info" Visible="False"></asp:Label>
            </td>
        </tr>
        </table>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 592px">
                <asp:Label ID="lblAuthorBy" runat="server" Font-Bold="True" Font-Size="Large" Text="Authored By:"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 592px; height: 247px;">
                <asp:GridView ID="gvAuthoredBy" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <td style="height: 247px">
                <asp:Label ID="lblAuthoredByInfo" runat="server" Font-Bold="True" Text="Authored By Info:"></asp:Label>
                <br />
                Author ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbAuthorByAuthorID" runat="server"></asp:TextBox>
                <br />
                Book ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbAuthoredByBookID" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAddAuthoredBy" runat="server" Text="Add Authored By" OnClick="btnAddAuthoredBy_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblInvalidAuthoredByInfo" runat="server" ForeColor="Red" Text="Invalid Authored By Info" Visible="False"></asp:Label>
                <br />
&nbsp;<br />
                <asp:Button ID="btnDeleteAuthoredBy" runat="server" Text="Delete Authored By" OnClick="btnDeleteAuthoredBy_Click" />
&nbsp;
                <asp:Label ID="lblInvalidAuthoredByInfo2" runat="server" ForeColor="Red" Text="Invalid Authored By Info" Visible="False"></asp:Label>
            </td>
            <td style="height: 247px"></td>
        </tr>
        <tr>
            <td style="width: 592px">&nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblReturnDate" runat="server" Font-Bold="True" Font-Size="Large" Text="Set Current Return Date:"></asp:Label>
    <br />
    Current Return Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblCurrentReturnDate" runat="server" Text="Label" Font-Bold="True" ForeColor="Red"></asp:Label>
    <br />
    <asp:TextBox ID="tbReturnDate" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <br />
    <asp:Button ID="btnSetReturnDate" runat="server" Text="Set Return Date" OnClick="btnSetReturnDate_Click" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblInvalidReturnDate" runat="server" ForeColor="Red" Text="Invalid Return Date" Visible="False"></asp:Label>
    <br />
</asp:Content>
