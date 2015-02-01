// header files
using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.Diagnostics;

public partial class MenuProxy : System.Web.UI.Page
{
    // initialize variables
    private String txtServiceResponse = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         GetBlueDotMenu();
    }

    protected void GetBlueDotMenu()
    {
        // set a REST endpoint
        HttpContext.Current.Session["serviceEndPoint"] = Constants.PlatformApiEndpoints.BlueDotAppMenuUrl;

        // create a new oAuth session with the consumer information
        OAuthConsumerContext consumerContext = new OAuthConsumerContext
        {
            ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
            SignatureMethod = SignatureMethod.HmacSha1,
            ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString()
        };

        // create an oAuth oSession 
        OAuthSession oSession = new OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                Constants.OauthEndPoints.AuthorizeUrl,
                                Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);

        // configure oSession
        oSession.ConsumerContext.UseHeaderForOAuthParameters = true;

        // create a new token base
        oSession.AccessToken = new TokenBase
        {
            Token = Session["accessToken"].ToString(),
            ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
            TokenSecret = Session["accessTokenSecret"].ToString()
        };

        IConsumerRequest conReq = oSession.Request();
        conReq = conReq.Get();
        conReq = conReq.ForUrl(HttpContext.Current.Session["serviceEndPoint"].ToString());
        try
        {
            conReq = conReq.SignWithToken();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        string header = conReq.Context.GenerateOAuthParametersForHeader();
        try
        {
            txtServiceResponse = conReq.ReadBody();
            Response.Write(txtServiceResponse);
        }
        catch (WebException we)
        {
            HttpWebResponse rsp = (HttpWebResponse)we.Response;
            if (rsp != null)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(rsp.GetResponseStream()))
                    {
                        txtServiceResponse = txtServiceResponse + rsp.StatusCode + " | " + reader.ReadToEnd();
                    }
                }
                catch (Exception)
                {
                    txtServiceResponse = txtServiceResponse + "Status code: " + rsp.StatusCode;
                }
            }
            else
            {
                txtServiceResponse = txtServiceResponse + "Error Communicating with App Menu Platform API" + we.Message;
            }
        }
    }
}