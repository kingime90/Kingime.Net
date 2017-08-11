using Kingime.Net.Core.Define;
using Kingime.Net.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kingime.Net.Core.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TicketController : Controller
    {
        private UserData userData;

        /// <summary>
        /// 用户数据
        /// </summary>
        public UserData UserData
        {
            get
            {
                if (userData == null)
                {
                    userData = HttpContext.Items[GlobalKeys.TicketUserDataKey] as UserData;
                }
                //
                return userData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected TicketController() : base()
        {

        }
    }
}
