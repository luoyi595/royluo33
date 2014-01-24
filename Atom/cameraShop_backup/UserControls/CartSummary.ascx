<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartSummary.ascx.cs" Inherits="UserControls_CartSummary" %>
<style type="text/css">
    .auto-style1 {
        width: 168px;
        height: 72px;
    }
    .CartSummary {
        width: 166px;
    }
</style>
<table class="CartSummary" border="0" cellpadding="0" cellspacing="1">
  <tr>
    <td>
        <img alt="" class="auto-style1" src="/MasterImg/cart.jpg" /><b><br />
        <asp:Label ID="cartSummaryLabel" runat="server" /></b>
      <asp:HyperLink ID="viewCartLink" runat="server" NavigateUrl="../ShoppingCart.aspx"
        CssClass="CartLink" Text="(Check out)" />
      <asp:DataList ID="list" runat="server" Width="161px">
        <ItemTemplate>
          <%# Eval("Quantity") %>
          x
          <%# Eval("Name") %>
        </ItemTemplate>
      </asp:DataList>
      <img src="Images/line.gif" border="0" width="99%" height="1" />
      Total: <span class="ProductPrice">
        <asp:Label ID="totalAmountLabel" runat="server" />
      </span>
    </td>
  </tr>
</table>
