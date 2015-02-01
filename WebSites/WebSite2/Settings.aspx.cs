using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Enabled = false;
        //Button1.Disabled = Disabled
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Enabled = false;
        //Button1.Disabled = Disabled
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button3.Enabled = false;
        //Button1.Disabled = Disabled
    }
}