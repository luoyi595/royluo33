<%@ Page Title="Camera: Online Store " Language="C#" MasterPageFile="~/BalloonShop.master" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>


