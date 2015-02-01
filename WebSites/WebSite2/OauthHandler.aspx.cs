// header files
using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;


    public partial class OauthHandler : System.Web.UI.Page
    {
        // initialize variables
        private String _oauthVerifyer, _realmid, _dataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                // This value is used to Get Access Token.
                _oauthVerifyer = Request.QueryString["oauth_verifier"].ToString();

                _realmid = Request.QueryString["realmId"].ToString();
                HttpContext.Current.Session["realm"] = _realmid;

                // If dataSource is QBO call QuickBooks Online Services, else call QuickBooks Desktop Services
                _dataSource = Request.QueryString["dataSource"].ToString();
                HttpContext.Current.Session["dataSource"] = _dataSource;

                // get access token
                getAccessToken();

                // Production applications should securely store the Access Token.
                // In this template, encrypted Oauth access token is persisted in OauthAccessTokenStorage.xml
                OauthAccessTokenStorageHelper.StoreOauthAccessToken(Page);

                // This value is used to redirect to Default.aspx from Cleanup page when user clicks on ConnectToInuit widget.
                Session["RedirectToDefault"] = true;
            }
            else
            {
                Response.Write("No OAuth token was received");
            }
        }

        /// <summary>
        /// Gets the Access Token
        /// </summary>
        private void getAccessToken()
        {
            IOAuthSession clientSession = CreateSession();
            try
            {
                IToken accessToken = clientSession.ExchangeRequestTokenForAccessToken((IToken)Session["requestToken"], _oauthVerifyer);
                Session["accessToken"] = accessToken.Token;

                // Add flag to session which tells that accessToken is in session
                Session["Flag"] = true;

                // Remove the Invalid Access token since we got the new access token
                HttpContext.Current.Session.Remove("InvalidAccessToken");
                Session["accessTokenSecret"] = accessToken.TokenSecret;
            }
            catch (Exception ex)
            {
                //Handle Exception if token is rejected or exchange of Request Token for Access Token failed. 
                throw ex;
            }
        }

        /// <summary>
        /// Creates the OAuth Session using Consumer key
        /// </summary>        
        /// <returns>OAuth Session.</returns>
        private IOAuthSession CreateSession()
        {
            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(CultureInfo.InvariantCulture),
                ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString(CultureInfo.InvariantCulture),
                SignatureMethod = SignatureMethod.HmacSha1
            };

            return new OAuthSession(consumerContext,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl,
                                             Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
        }
    }
