using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessLogic;
using BussinessObject;
using System.Data.SqlClient;
using System.Net;
using System.IO;
namespace WebApplication1
{
    public partial class StudentDocuementUpload : System.Web.UI.Page
    {
        uploadBO uploadBo = new uploadBO();
        UploadBL uploadBl = new UploadBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){}
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            if (txtRoll.Text == string.Empty)
            {
                Response.Write("<script language='JavaScript'> alert('Please enter Roll Number ')</script>");
            }
            else
            {
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                uploadBo.Roll = Convert.ToInt32(txtRoll.Text);
                SqlDataReader dr = uploadBl.show(uploadBo);
                if (dr.HasRows)
                {
                    dr.Read();
                    lblName.Text = dr["NAME"].ToString();
                    lblclg.Text = dr["CLG"].ToString();
                    lblcity.Text = dr["CITY"].ToString();
                    lblemail.Text = dr["EMAIL"].ToString();
                    ListView1.Visible = true;
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Student Not Available')</script>");
                    ListView1.DataSource = null;
                    ListView1.DataBind();
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;

                    // Clear labels and set their visibility to false
                    lblName.Text = string.Empty;
                    lblclg.Text = string.Empty;
                    lblcity.Text = string.Empty;
                    lblemail.Text = string.Empty;
                }
                DataSet ds = uploadBl.listdata(uploadBo);
                ListView1.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 0)
                {
                    foreach (ListViewItem item in ListView1.Items)
                    {
                        Label lblfilen = (Label)item.FindControl("lblfileName");
                        lblfilen.Text = string.Empty;

                        Button btnPreview = (Button)item.FindControl("btnPreview");
                        btnPreview.Text = "Preview";
                    }
                }
                else
                {
                        ListView1.DataBind();       
                }
            }
        }

        protected void btnUploadAddhar_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)((Button)sender).NamingContainer;
            FileUpload fileupload = (FileUpload)item.FindControl("FileUpload1");
            Label lbldoc =(Label)item.FindControl("lbldoc");
            Label lblid =(Label)item.FindControl("lblid");
            Label lblfilename = (Label)item.FindControl("lblfileName");
            if (lblfilename.Text == string.Empty)
            {
                if (fileupload.HasFile)
                {
                    HttpPostedFile file = fileupload.PostedFile;
                    // Check file size (150KB limit)
                    if (file.ContentLength <= 150 * 1024)
                    {     
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileupload.FileName);
                        string filePath = Server.MapPath("~/Document/") + fileName;

                        // Save the uploaded file to the specified path
                        file.SaveAs(filePath);
                        uploadBo.DocName = fileName;
                        if (lbldoc.Text == "Adhaar")
                        {
                            uploadBo.FileName = "Adhaar_" + txtRoll.Text;
                        }
                        else if (lbldoc.Text == "TC")
                        {
                            uploadBo.FileName = "TC_" + txtRoll.Text;
                        }
                        uploadBo.Roll = Convert.ToInt32(txtRoll.Text);
                        uploadBo.DocId = Convert.ToInt32(lblid.Text);
                        int result = uploadBl.save(uploadBo);
                        if (result == 1)
                        {
                            Response.Write("<script language='JavaScript'> alert('Document Submitted')</script>");
                            lblfilename.Text = uploadBo.FileName;
                            
                        }
                    }
                    else
                    {
                        Response.Write("<script language='JavaScript'> alert('File should be of size less than 150 kb')</script>");
                    }
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Please Select a PDF file')</script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Document already Uploaded')</script>");
            }
        }

        protected void btndownload_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item1 in ListView1.Items)
            {
                Label lblfilename = (Label)item1.FindControl("lblfileName");
                uploadBo.FileName = lblfilename.Text;
                SqlDataReader dr = uploadBl.getfilepath(uploadBo);
                    string filePath = uploadBo.Paths;
                    string fileName = Path.GetFileName(filePath);
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);          
                        Response.TransmitFile(Server.MapPath("~/Document/"+filePath));
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script language='JavaScript'> alert('File not found.')</script>");
                    }       
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string pdfFileName = ((Button)sender).CommandArgument;
            pdfFrame.Attributes["src"] = "Document/" + pdfFileName;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pdfModalScript", "$('#pdfModal').modal('show');", true);
        }
    }
}