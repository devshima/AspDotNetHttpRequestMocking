using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HttpRequestMocking
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly IndexController  _controller = new IndexController();

        protected void Page_Load(object sender, EventArgs e)
        {
            _controller.createCookie(new HttpRequestWrapper(Request),
                                                     new HttpResponseWrapper(Response));
        }
    }
}