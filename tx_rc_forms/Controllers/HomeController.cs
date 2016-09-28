using System.Collections.Generic;
using System.Web.Mvc;
using TXTextControl.ReportingCloud;

namespace tx_rc_forms.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            // create a new ReportingCloud object
            ReportingCloud rc = new ReportingCloud("bjoern@textcontrol.com", "Visions#22");

            // read template into byte array and upload template to RC
            byte[] bDocument = System.IO.File.ReadAllBytes(Server.MapPath("/App_Data/letter.tx"));
            rc.UploadTemplate("letter.tx", bDocument);

            // retrieve template information
            TXTextControl.ReportingCloud.TemplateInfo templateInfo = rc.GetTemplateInfo("letter.tx");
            
            // return template information to view
            return View(templateInfo);
        }

        // POST: Merge
        public void Merge()
        {
            // create a Dictionary with all form values
            Dictionary<string,string> formValues = new Dictionary<string,string>();

            foreach (string key in Request.Form)
            {
                formValues.Add(key, Request[key]);
            }

            // create a new ReportingCloud object
            ReportingCloud rc = new ReportingCloud("bjoern@textcontrol.com", "Visions#22");

            // create a MergeBody object with the form values
            MergeBody mb = new MergeBody()
            {
                MergeData = formValues
            };

            // call the MergeDocument method
            List<byte[]> documents = rc.MergeDocument(mb, "letter.tx");

            // return the PDF to the browser
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(documents[0]);
            Response.Flush();
            Response.End();
        }

    }
}