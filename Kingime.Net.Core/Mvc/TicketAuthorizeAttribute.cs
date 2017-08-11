using Kingime.Net.Core.Define;
using Kingime.Net.Core.Extentsion;
using Kingime.Net.Core.Model;
using Kingime.Net.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kingime.Net.Core.Mvc
{
    /// <summary>
    /// 票证授权过滤器
    /// </summary>
    public class TicketAuthorizeAttribute : AuthorizeAttribute
    {
        
        /// <summary>
        /// 重写时，提供一个入口点用于进行自定义授权检查
        /// </summary>
        /// <param name="httpContext">HTTP 上下文，它封装有关单个 HTTP 请求的所有 HTTP 特定的信息</param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return false;
            }
            //
            if (string.IsNullOrWhiteSpace(authCookie.Value))
            {
                return false;
            }
            //
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
            }
            catch
            {
                return false;
            }
            //
            if (authTicket == null)
            {
                return false;
            }
            //
            var userData = JsonUtil.Deserialize<UserData>(authTicket.UserData.FromBase64());
            if (userData == null)
            {
                return false;
            }
            //
            httpContext.Items.Add(GlobalKeys.TicketUserDataKey, userData);
            return true;
        }

        /// <summary>
        /// 处理未能授权的 HTTP 请求
        /// </summary>
        /// <param name="filterContext">封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。filterContext 对象包括控制器、HTTP 上下文、请求上下文、操作结果和路由数据</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string redirectUrl = HttpUtility.UrlEncode(UrlHelper.GenerateContentUrl(filterContext.HttpContext.Request.Url.AbsoluteUri, filterContext.HttpContext));
            redirectUrl = $"{FormsAuthentication.LoginUrl}?returnUrl={redirectUrl}";
            filterContext.Result = new RedirectResult(redirectUrl);
        }
    }
}
