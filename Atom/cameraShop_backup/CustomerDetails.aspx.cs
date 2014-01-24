using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Set the title of the page
    this.Title = BalloonShopConfiguration.SiteName +
                " : Customer Details";
    string UserId = Request.QueryString["UserId"];
    //UserIdLabel.Text = UserId;

    //// Retrieve ProductID from the query string
    //string productId = Request.QueryString["ProductID"];
    //// Retrieves product details
    //ProductDetails pd = CatalogAccess.GetProductDetails(productId);
    //// Does the product exist?
    //if (pd.Name != null)
    //{
    //    PopulateControls(pd);
    //}
    //else
    //{
    //    Server.Transfer("~/NotFound.aspx");
    //}
    //// 301 redirect to the proper URL if necessary
    //Link.CheckProductUrl(Request.QueryString["ProductID"]);

  }
}
