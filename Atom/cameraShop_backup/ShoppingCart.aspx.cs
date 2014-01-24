using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add by aotm
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
//add by atom
using System.Net.Mail;  

public partial class ShoppingCart: System.Web.UI.Page
{
    //global parameter
  public static  decimal finalPrice=12;
  protected void Page_Load(object sender, EventArgs e)
  {
    // populate the control only on the initial page load
    if (!IsPostBack)
      PopulateControls();
    //SqlConnection discountConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString);
      
  }

  // fill shopping cart controls with data
  private void PopulateControls()
  {
    

    // Display product recommendations
    recommendations.LoadCartRecommendations();  
    // get the items in the shopping cart
    DataTable dt = ShoppingCartAccess.GetItems();
    // if the shopping cart is empty...
    if (dt.Rows.Count == 0)
    {
      titleLabel.Text = "Your shopping cart is empty!";
      grid.Visible = false;
      updateButton.Enabled = false;
      checkoutButton.Enabled = false;
      totalAmountLabel.Text = String.Format("{0:c}", 0);
    }
    else
    // if the shopping cart is not empty...
    {
      // populate the list with the shopping cart contents
      grid.DataSource = dt;
      grid.DataBind();
      // setup controls
      titleLabel.Text = "These are the products in your shopping cart:";
      grid.Visible = true;
      updateButton.Enabled = true;
      checkoutButton.Enabled = true;
      // display the total amount
      decimal amount = ShoppingCartAccess.GetTotalAmount();
      totalAmountLabel.Text = String.Format("{0:c}", amount);

      //---------------------------add by atom for discount---------------------------------
      SqlConnection discountConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString);
      decimal discount=0;
      SqlCommand selectDiscount = new SqlCommand("select DiscountPercentage from DiscountDetail where DiscountID =@discountID", discountConn);
      SqlDataReader discountReader;
      int discountID=0;
      discountConn.Open();

      if (amount >= 1000 && amount < 2000)
      {
          discountID = 1;
          selectDiscount.Parameters.Add("@discountID", discountID);
          selectDiscount.CommandType = CommandType.Text;
          //create data reader
          //SqlDataReader discountReader;
          discountReader = selectDiscount.ExecuteReader();
          discountReader.Read();
          discount = Convert.ToDecimal(discountReader[0]);
          discountReader.Close();

      }
      else if (amount >= 2000 && amount <= 3000)
      {
          discountID = 2;
          selectDiscount.Parameters.Add("@discountID", discountID);
          selectDiscount.CommandType = CommandType.Text;
          //create data reader
          //SqlDataReader discountReader;
          discountReader = selectDiscount.ExecuteReader();
          discountReader.Read();
          discount = Convert.ToDecimal(discountReader[0]);
          discountReader.Close();
      }
      else if (amount > 3000)
      {
          discountID = 3;
          selectDiscount.Parameters.Add("@discountID", discountID);
          selectDiscount.CommandType = CommandType.Text;
          //create data reader
          //SqlDataReader discountReader;
          discountReader = selectDiscount.ExecuteReader();
          discountReader.Read();
          discount = Convert.ToDecimal(discountReader[0]);
          discountReader.Close();
      }
      else if(amount<1000)
      {
          //discount = 1;
          discountID = 4;
          selectDiscount.Parameters.Add("@discountID", discountID);
          selectDiscount.CommandType = CommandType.Text;
          //create data reader
          //SqlDataReader discountReader;
          discountReader = selectDiscount.ExecuteReader();
          discountReader.Read();
          discount = Convert.ToDecimal(discountReader[0]);
          discountReader.Close();
      }

     
      string discountMessage;
      SqlCommand discountMsgCommand = new SqlCommand("Select DisocuntDescription from DiscountDetail where DiscountID=@discountID", discountConn);
      //carete a message reader
      SqlDataReader discountMsgReader;
      discountMsgCommand.Parameters.Add("@discountID", discountID);
      discountMsgCommand.CommandType = CommandType.Text;
      discountMsgReader = discountMsgCommand.ExecuteReader();
      discountMsgReader.Read();
      discountMessage = discountMsgReader[0].ToString();
      discountMsgReader.Close();

      //lable test
      discountMsgLable.Text = discountMessage;
      finalPrice = amount*discount;
      discountLable.Text = String.Format("{0:c}", (amount - (amount * discount)));
      amount = finalPrice;
      finalPriceLable.Text =String.Format("{0:c}", amount);


      discountConn.Close();
       //atom's job is done!

      //add for emailbodytest
      //TextBoxbodytest.Text = msgBody(String.Format("{0:c}", amount));
      
      
    }


  }

  // remove a product from the cart
  protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
  {
    // Index of the row being deleted
    int rowIndex = e.RowIndex;
    // The ID of the product being deleted
    string productId = grid.DataKeys[rowIndex].Value.ToString();
    // Remove the product from the shopping cart
    bool success = ShoppingCartAccess.RemoveItem(productId);
    // Display status
    statusLabel.Text = success ? "Product successfully removed!" :
                  "There was an error removing the product! ";
    // Repopulate the control
    PopulateControls();
  }

  // update shopping cart product quantities
  protected void updateButton_Click(object sender, EventArgs e)
  {
    // Number of rows in the GridView
    int rowsCount = grid.Rows.Count;
    // Will store a row of the GridView
    GridViewRow gridRow;
    // Will reference a quantity TextBox in the GridView
    TextBox quantityTextBox;
    // Variables to store product ID and quantity
    string productId;
    int quantity;
    // Was the update successful?
    bool success = true;
    // Go through the rows of the GridView
    for (int i = 0; i < rowsCount; i++)
    {
      // Get a row
      gridRow = grid.Rows[i];
      // The ID of the product being deleted
      productId = grid.DataKeys[i].Value.ToString();
      // Get the quantity TextBox in the Row
      quantityTextBox = (TextBox)gridRow.FindControl("editQuantity");
      // Get the quantity, guarding against bogus values
      if (Int32.TryParse(quantityTextBox.Text, out quantity))
      {
        // Update product quantity
        success = success && ShoppingCartAccess.UpdateItem(productId, quantity);
      }
      else
      {
        // if TryParse didn't succeed
        success = false;
      }

      // Display status message
      statusLabel.Text = success ?
      "Your shopping cart was successfully updated!" :
      "Some quantity updates failed! Please verify your cart!";
    }
    // Repopulate the control
    PopulateControls();
  }

  // create a new order and redirect to a payment page
  protected void checkoutButton_Click(object sender, EventArgs e)
  {
      SqlConnection ordersTableConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString);
      // Store the total amount because the cart 
      // is emptied when creating the order
      decimal amount;
      //decimal amount = ShoppingCartAccess.GetTotalAmount();
      // Create the order and store the order ID
      string orderId = ShoppingCartAccess.CreateOrder();
      // Obtain the site name from the configuration settings
      string siteName = BalloonShopConfiguration.SiteName;
      // Create the PayPal redirect location

      //add by atom, for update the finalPrice into orders table
      ordersTableConn.Open();
      SqlCommand insertFinalPrice = new SqlCommand("update Orders set OrderFinalPrice=" + finalPrice + "  where OrderID=" + orderId, ordersTableConn);
      insertFinalPrice.ExecuteNonQuery();
      amount = finalPrice;
      string redirect = "";
      redirect += "https://www.paypal.com/xclick/business=jueyuansanqv22@gmail.com";
      redirect += "&item_name=" + siteName + " Order " + orderId;
      redirect += "&item_number=" + orderId;
      redirect += "&amount=" + String.Format("{0:0.00} ", amount);
      redirect += "&currency=USD";
      redirect += "&return=http://www." + siteName + ".com";
      redirect += "&cancel_return=http://www." + siteName + ".com";
      // Redirect to the payment page
      Response.Redirect(redirect);
      ordersTableConn.Close();

      //add by atom
      if (TextBoxEmailAddress.Text!="")
      {
          sendmail(msgBody(String.Format("{0:c}", amount)),TextBoxEmailAddress.Text);
      }
      //atom's job done
  }


  private void sendmail(string body, string to)
  {
      

      try
      {



          MailMessage mail = new MailMessage();
          mail.To.Add(to);
          //mail.To.Add("574136907@qq.com");
          //mail.To.Add("yourfriend2@yahoo.com");
          mail.From = new MailAddress("pamacamerashop@gmail.com");
          mail.Subject = "Your PAMA Camera Shop Order Payment Reminder";

          string emailBody = body;
          mail.Body = emailBody;

          mail.IsBodyHtml = true;
          SmtpClient smtp = new SmtpClient();
          smtp.Host = "smtp.gmail.com";
          smtp.Port = 587;
          smtp.UseDefaultCredentials = true;
          smtp.Credentials = new System.Net.NetworkCredential
          ("pamacamerashop@gmail.com", "pama123456");
          smtp.EnableSsl = true;
          smtp.Send(mail);



      }
      catch (Exception ex)
      {

          throw ex;

      }

  }

  private string msgBody(string amount)
  {
      DataTable dt = ShoppingCartAccess.GetItems();

      string items = "";
      string nl = Environment.NewLine;
      for (int i = 0; i < dt.Rows.Count; i++)
      {
          items=items+nl+dt.Rows[i][1].ToString()+nl;
      }
      

      string body = "------------------------------------"+nl+"You have ordered product(s) below:"
          +nl+ items + nl+ "Total amount is: " + amount+nl+"------------------------------------"+nl+
          "Please pay for your order as soon as you can."+nl+nl+"From PAMA Camera Shop, enjoy your shopping in our website.";
      return body;

  }

}