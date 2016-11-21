using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace TesisUdistrital.Modulo
{
    public partial class Descarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(Session["_SESSION_URLDESCARGA"].ToString());
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.WriteFile(fileInfo.FullName);
            Response.End();
        }
    }
}