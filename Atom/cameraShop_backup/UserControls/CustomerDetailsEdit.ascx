<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerDetailsEdit.ascx.cs"
  Inherits="UserControls_CustomerDetailsEdit" %>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="ProfileWrapper"
  SelectMethod="GetData" TypeName="ProfileDataSource" UpdateMethod="UpdateData">
</asp:ObjectDataSource>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BalloonShopConnection %>"
  SelectCommand="SELECT [ShippingRegionID], [ShippingRegion] FROM [ShippingRegion]" DeleteCommand="DELETE FROM [ShippingRegion] WHERE [ShippingRegionID] = @ShippingRegionID" InsertCommand="INSERT INTO [ShippingRegion] ([ShippingRegion]) VALUES (@ShippingRegion)" UpdateCommand="UPDATE [ShippingRegion] SET [ShippingRegion] = @ShippingRegion WHERE [ShippingRegionID] = @ShippingRegionID" >
    <DeleteParameters>
        <asp:Parameter Name="ShippingRegionID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="ShippingRegion" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="ShippingRegion" Type="String" />
        <asp:Parameter Name="ShippingRegionID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" 
    EnableModelValidation="True" DataKeyNames="ShippingRegionID">
  <EditItemTemplate>
      ShippingRegionID:
      <asp:Label ID="ShippingRegionIDLabel1" runat="server" Text='<%# Eval("ShippingRegionID") %>' />
      <br />
      ShippingRegion:
      <asp:TextBox ID="ShippingRegionTextBox" runat="server" Text='<%# Bind("ShippingRegion") %>' />
      <br />
      <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
      &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
  </EditItemTemplate>
    <InsertItemTemplate>
        ShippingRegion:
        <asp:TextBox ID="ShippingRegionTextBox" runat="server" Text='<%# Bind("ShippingRegion") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </InsertItemTemplate>
  <ItemTemplate>
      ShippingRegionID:
      <asp:Label ID="ShippingRegionIDLabel" runat="server" Text='<%# Eval("ShippingRegionID") %>' />
      <br />
      ShippingRegion:
      <asp:Label ID="ShippingRegionLabel" runat="server" Text='<%# Bind("ShippingRegion") %>' />
      <br />
      <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
      &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
      &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
  </ItemTemplate>
</asp:FormView>
