<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSCI336_FinalProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">NDSU ACM Library
                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Img/acm_logo_BIG_2023.png" Width="100px" />
            </h1>
            <p>Welcome to the ACM Library Database! </p>
            <p>Here you can find all the books we have stored within NDSU ACM&#39;s library, as well as check out and return books!</p>
            <p>Click on the
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/logon.aspx">Login</asp:HyperLink>
                button to log in!</p>
        </section>
    </main>

</asp:Content>
