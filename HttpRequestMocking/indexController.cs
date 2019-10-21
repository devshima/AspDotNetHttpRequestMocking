using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpRequestMocking
{
    public class IndexController
    {
        public IndexController()
        {

        }

        public void createCookie(HttpRequestBase request, HttpResponseBase response)
        {
            if (request.QueryString == null)
            {
                throw new ArgumentNullException();
            }
            string value = request.QueryString["hoge"];

            var cookie = new HttpCookie("hoge");
            cookie.Value = "hoge" + value;
            response.Cookies.Add(cookie);
        }

    }
}