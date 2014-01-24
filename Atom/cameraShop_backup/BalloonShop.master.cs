using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class BalloonShop : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToShortDateString();
        string time = DateTime.Now.ToShortTimeString();
        welcomeMsg.Text = "Now is: " + date + ". "+time+". Hope you enjoy the shopping in our website.";

        int hour = DateTime.Now.Hour;
        string timeMsg = "Have a nice day!";
        if (hour>6&&hour<=12)
        {
            timeMsg = "Good morning!";
        }
        else if (hour>12&&hour<=18)
        {
            timeMsg = "Good afternoon!";
        }
        else if (hour>18&&hour<=24)
        {
            timeMsg = "Good night!";
        }
        else
        {
            timeMsg = "What a wonderful night!";
        }
        timeWelcomeLabel.Text = timeMsg;
    
    }
}
