using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Redirect to the Login page
            Response.Redirect("MemberLogin.aspx");
        }

        protected void btnMemberLogin_Click(object sender, EventArgs e)
        {
            // Redirect to the Member Login page
            Response.Redirect("StaffLogin.aspx");
        }

        protected void btnStaffLogin_Click(object sender, EventArgs e)
        {
            // Redirect to the Staff Login page
            Response.Redirect("TryThePage.aspx");
        }

    }
}