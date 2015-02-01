using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

public partial class OauthGrant : System.Web.UI.Page
{
    // initialize variables
    public String consumerSecret, consumerKey, oauthLink, RequestToken, TokenSecret, oauth_callback_url;

    protected void Page_Load(object sender, EventArgs e)
    {
        // get request token
        oauth_callback_url = Request.Url.GetLeftPart(UriPartial.Authority) + ConfigurationManager.AppSettings["oauth_callback_url"];
        consumerKey = ConfigurationManager.AppSettings["consumerKey"];
        consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
        oauthLink = Constants.OauthEndPoints.IdFedOAuthBaseUrl;
        IToken token = (IToken)HttpContext.Current.Session["requestToken"];
        IOAuthSession session = CreateSession();
        IToken requestToken = session.GetRequestToken();
        HttpContext.Current.Session["requestToken"] = requestToken;
        RequestToken = requestToken.Token;
        TokenSecret = requestToken.TokenSecret;
        oauthLink = Constants.OauthEndPoints.AuthorizeUrl + "?oauth_token=" + RequestToken + "&oauth_callback=" + UriUtility.UrlEncode(oauth_callback_url);
        Response.Redirect(oauthLink);
    }

    // create session implementation
    protected IOAuthSession CreateSession()
    {
        OAuthConsumerContext consumerContext = new OAuthConsumerContext
        {
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret,
            SignatureMethod = SignatureMethod.HmacSha1
        };
        return new OAuthSession(consumerContext,
                                        Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                        oauthLink,
                                        Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
    }
}