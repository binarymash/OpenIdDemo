namespace OpenIdDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    using OpenIdProvider = OpenIdDemo.AuthenticationProviders.OpenId.Interfaces;
    using Services = OpenIdDemo.Services.Interfaces;

    using log4net;
    
    public class AuthenticationController : Controller
    {

        #region Constructors

        public AuthenticationController(OpenIdProvider.IAuthenticationProvider openIdAuthenticationProvider, Services.IUserService userService)
        {
            _openIdAuthenticationProvider = openIdAuthenticationProvider;
            _userService = userService;
        }

        #endregion

        #region Actions

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult OpenId(string openIdUrl)
        {
            var request = _openIdAuthenticationProvider.Factory.AuthenticationRequest(openIdUrl ?? string.Empty);
            var response = _openIdAuthenticationProvider.Authenticate(request);
            switch (response.State)
            {
                case OpenIdProvider.AuthenticationState.Authenticating:
                    return HandleAuthenticating(response);
                case OpenIdProvider.AuthenticationState.Authenticated:
                    return HandleAuthenticated(response.UserIdentity);
                default:
                    return HandleErrored(response);
            }
        }

        //public ActionResult OAuth(string returnUrl)
        //{
        //    var twitter = new WebConsumer(TwitterConsumer.ServiceDescription, TokenManager);
        //    var callBackUrl = new Uri(Request.Url.Scheme + "://" + Request.Url.Authority + "/Account/OAuthCallback");
        //    twitter.Channel.Send(twitter.PrepareRequestUserAuthorization(callBackUrl, null, null));

        //    return RedirectToAction("Login");
        //}

        //public ActionResult OAuthCallback()
        //{
        //    var twitter = new WebConsumer(TwitterConsumer.ServiceDescription, TokenManager);
        //    var accessTokenResponse = twitter.ProcessUserAuthorization();
        //    if (accessTokenResponse != null)
        //    {
        //        string userName = accessTokenResponse.ExtraData["screen_name"];
        //        return CreateUser(userName, null, null, null);
        //    }
        //    _logger.Error("OAuth: No access token response!");
        //    return RedirectToAction("Login");
        //}

        #endregion

        #region Private

        OpenIdProvider.IAuthenticationProvider _openIdAuthenticationProvider { get; set; }
        Services.IUserService _userService { get; set; }

        ActionResult HandleAuthenticating(OpenIdProvider.IAuthenticationResponse response)
        {
            return response.AuthenticatingActionResult;
        }

        ActionResult HandleAuthenticated(OpenIdProvider.IUserIdentity userIdentity)
        {
            var getUserRequest = _userService.Factory.GetRequest(userIdentity.Identifier,
                userIdentity.FirstName,
                userIdentity.LastName,
                userIdentity.EmailAddress);

            var getUserResponse = _userService.Get(getUserRequest);
            if (getUserResponse.Ok)
            {
                Session["FullName"] = getUserResponse.User.FullName;
                FormsAuthentication.SetAuthCookie(getUserResponse.User.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Create", "User", getUserResponse.User);
        }

        ActionResult HandleErrored(OpenIdProvider.IAuthenticationResponse response)
        {
            return RedirectToAction("Login");
        }

        //private ICreateUserResponse CreateUser(ICreateUserRequest request)
        //{
        //User user = _userRepository.FindBy(x => x.UserName == userName);
        //if (user == null)
        //{
        //    user = new User
        //    {
        //        UserName = userName,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Email = email
        //    };
        //    return View("Create", user);
        //}
        //
        //Session["UserName"] = userName;
        //string fullName = user.FirstName + " " + user.LastName;
        //Session["FullName"] = fullName;
        //_formsAuth.SignIn(fullName, false);
        //    return RedirectToAction("Index", "Home");
        //}

        #endregion

    }
}
