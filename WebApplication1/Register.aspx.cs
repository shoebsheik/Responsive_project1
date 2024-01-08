using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogic;
using BussinessObject;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        UserBO userBo = new UserBO();
        UserBL userBl = new UserBL();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader dr = userBl.show();
                listDisplay.DataSource = dr;
                listDisplay.DataBind();

                ddlBranch1.DataSource = userBl.pbranch();
                ddlBranch1.DataTextField = "BRANCH_TYPE";
                ddlBranch1.DataBind(); 
                ddlBranch1.Items.Insert(0, new ListItem("Select Branch Type", ""));

                ddlLevel.DataSource = userBl.level1();
                ddlLevel.DataTextField = "LEVELNAME";
                ddlLevel.DataBind();
                ddlLevel.Items.Insert(0, new ListItem("Select Level ", ""));
                ddlDegree.Items.Insert(0, new ListItem("Select Degree ", ""));
                ddlBranch.Items.Insert(0, new ListItem("Select Branch ", ""));
                ddlDuration.Items.Insert(0, new ListItem("Select Duration ", ""));
                txtIntake.Text = System.DateTime.Now.ToString();
            }
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string level = ddlLevel.SelectedValue;
            userBo.Level = level;
            ddlDegree.DataSource = userBl.get_degree(userBo);
            ddlDegree.DataTextField = "DEGREENAME";
            ddlDegree.DataBind();
            ddlDegree.Items.Insert(0, new ListItem("Select Degree ", ""));
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e){}

        protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            string degree = ddlDegree.SelectedValue;
            userBo.Degree = degree;
            ddlBranch.DataSource = userBl.get_branch(userBo);
            ddlBranch.DataTextField = "BRANCHNAME";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch ", ""));
            
            ddlDuration.DataSource = userBl.get_duration(userBo);
            ddlDuration.DataTextField = "DURATION";
            ddlDuration.DataBind();
            ddlDuration.Items.Insert(0, new ListItem("Select Duration ", ""));   
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            list.Visible = false;
            if (btnSubmit.Text == "ADD")
            {
              if (Session["Mydata"] == null)
               {
                            dt = new DataTable();
                            dt.Columns.Add("ID");
                            dt.Columns.Add("PROGRAME");
                            dt.Columns.Add("Level");
                            dt.Columns.Add("Degree");
                            dt.Columns.Add("Branch");
                            dt.Columns.Add("Duration");
                            dt.Columns.Add("Intake");
                            Session["Mydata"] = dt;
              }
              else if (Session["Mydata"] != null)
               {
                 dt = Session["Mydata"] as DataTable;
               }                
                bool status = false;             
                foreach(DataRow row in dt.Rows)
                {
                    if (row["Degree"].ToString() == ddlDegree.SelectedValue && row["Branch"].ToString() == ddlBranch.SelectedValue)
                    {
                        //DataTable dt;
                        Response.Write("<script language='JavaScript'> alert('Record  Already Present')</script>");

                        status = true;
                        break;
                    }
                }             
                   if(!status)
                   {
                        DataRow dr = dt.NewRow();
                        dr["ID"] = 0;
                        dr["PROGRAME"] = ddlBranch1.SelectedValue;
                        dr["Level"] = ddlLevel.SelectedValue;
                        dr["Degree"] = ddlDegree.SelectedValue;
                        dr["Branch"] = ddlBranch.SelectedValue;
                        dr["Duration"] = ddlDuration.SelectedValue;
                        dr["Intake"] = txtIntake.Text;                      
                        dt.Rows.Add(dr);
                        list.Visible = true;
                        list.DataSource = dt;
                        list.DataBind();
                    }
                   foreach (ListViewItem item in list.Items)
                   {
                       Button btn = (Button)item.FindControl("btnEdit1");
                       btn.Visible = false;
                   }
                   ddlBranch1.SelectedIndex = 0;
                   ddlLevel.SelectedIndex = 0;
                   ddlDegree.ClearSelection();
                   ddlDegree.Items.Clear();
                   ddlDegree.Items.Insert(0, new ListItem("Select Degree ", ""));
                   ddlBranch.ClearSelection();
                   ddlBranch.Items.Clear();
                   ddlBranch.Items.Insert(0, new ListItem("Select Branch ", ""));
                   ddlDuration.ClearSelection();
                   ddlDuration.Items.Clear();
                   ddlDuration.Items.Insert(0, new ListItem("Select Duration ", ""));
                   txtIntake.Text = string.Empty;
                   list.Visible = true;
                
               }

               else if (btnSubmit.Text == "Update")
                   { 
                       int s = Convert.ToInt32(Session["Id"].ToString());
                       userBo.Id = s;
                       userBo.Programee_branch = ddlBranch1.SelectedValue;
                       userBo.Degree = ddlDegree.SelectedValue;
                       userBo.Level = ddlLevel.SelectedValue;
                       userBo.Branch = ddlBranch.SelectedValue;
                       userBo.Duration = ddlDuration.SelectedValue;
                       userBo.Intake = txtIntake.Text;
                       int res1 = userBl.UpdateRec(userBo);
                       if (res1 == 1)
                       {
                           Response.Write("<script language='JavaScript'> alert('Updated Successfully')</script>");
                       }
                       SqlDataReader dr = userBl.show();
                       listDisplay.DataSource = dr;
                       listDisplay.DataBind();

                       ddlBranch1.SelectedIndex = 0;
                       ddlLevel.SelectedIndex = 0;
                       ddlDegree.ClearSelection();
                       ddlDegree.Items.Clear();
                       ddlDegree.Items.Insert(0, new ListItem("Select Degree ", ""));
                       ddlBranch.ClearSelection();
                       ddlBranch.Items.Clear();
                       ddlBranch.Items.Insert(0, new ListItem("Select Branch ", ""));
                       ddlDuration.ClearSelection();
                       ddlDuration.Items.Clear();
                       ddlDuration.Items.Insert(0, new ListItem("Select Duration ", ""));
                       txtIntake.Text = string.Empty;
                       btnSubmit.Text = "ADD";
                       list.Visible = false;
                       btnSubmit.Visible = true;
                       Session["Mydata"] = null;
                   }         
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0)
            {
                Response.Write("<script language='JavaScript'> alert('Record  Already Present')</script>");
            }
            else{
                int res1 = 0;
                int res = 0;
                list.Visible = false;

                foreach (ListViewItem item in list.Items)
                {
                    Label lblBranchP = (Label)item.FindControl("LabelPrograme");
                    Label lblLevel = (Label)item.FindControl("LabelLevel");
                    Label lblDegree = (Label)item.FindControl("LabelDegree");
                    Label lblBranch = (Label)item.FindControl("LabelBranch");
                    Label lblDuration = (Label)item.FindControl("LabelDuration");
                    Label lblIntake = (Label)item.FindControl("LabelIntake");
                    userBo.Programee_branch = lblBranchP.Text;
                    userBo.Degree = lblDegree.Text;
                    userBo.Level = lblLevel.Text;
                    userBo.Branch = lblBranch.Text;
                    userBo.Duration = lblDuration.Text;
                    userBo.Intake = lblIntake.Text;
                    res1 = userBl.Check(userBo);

                }
                if (res1 != 1)
                {
                    res = userBl.save(userBo);
                    SqlDataReader dr = userBl.show();
                    list.Visible = true;
                    listDisplay.DataSource = dr;
                    listDisplay.DataBind();

                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Record  Already Present')</script>");
                }
                if (res == 1)
                {
                    Response.Write("<script language='JavaScript'> alert('Register Successfully')</script>");
                }
                clearForm();
                list.DataSource = null;
                list.DataBind();
                Session["Mydata"] = null;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
            list.DataSource = null;
            list.DataBind();
            list.Visible = false;
        }

        private void clearForm()
        {
            ddlBranch1.SelectedIndex = 0;
            ddlLevel.SelectedIndex = 0;
            ddlDegree.ClearSelection();
            ddlDegree.Items.Clear();
            ddlDegree.Items.Insert(0, new ListItem("Select Degree ", ""));
            ddlBranch.ClearSelection();
            ddlBranch.Items.Clear();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch ", ""));   
            ddlDuration.ClearSelection();
            ddlDuration.Items.Clear();
            ddlDuration.Items.Insert(0, new ListItem("Select Duration ", ""));   
            txtIntake.Text = string.Empty;
           // list.Items.Clear();   
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
                ListViewItem item = (ListViewItem)((Button)sender).NamingContainer;
                Label lblId = (Label)item.FindControl("IDLabel");
                Label lblBranchP = (Label)item.FindControl("PROGRAMELabel");
                Label lblLevel = (Label)item.FindControl("LEVELLabel");
                Label lblDegree = (Label)item.FindControl("DEGREELabel");
                Label lblBranch = (Label)item.FindControl("BRANCHLabel");
                Label lblDuration = (Label)item.FindControl("DURATIONLabel");
                Label lblIntake = (Label)item.FindControl("INTAKELabel");
                userBo.Programee_branch = lblBranchP.Text;
                SqlDataReader dr = userBl.getPbranch(userBo);
                list.DataSource = dr;
                list.DataBind();
                list.Visible = true;
                btnSubmit.Text = "Update";
        }

        protected void btnReport_Click(object sender, EventArgs e)
        { 
            ReportDocument rprt = new ReportDocument();            
            string filepath;
            rprt.Load(Server.MapPath("~/rptCrystalReportStudentIntake.rpt"));
            rprt.FileName = Server.MapPath("~/rptCrystalReportStudentIntake.rpt");
            filepath = Server.MapPath("~/" + "report.pdf");
            rprt.SetDatabaseLogon("sa","iitms"); 
            rprt.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            FileInfo fileinfo = new FileInfo(filepath);
           
            // Generate a unique query string to ensure the report is not cached by the browser
            string queryString = "?timestamp=" + DateTime.Now.Ticks.ToString();

            // Create a URL to the PDF file
            string pdfUrl = ResolveUrl("~/report.pdf" + queryString);

            // Create a hyperlink to open the report in a new tab
            string script = "window.open('" + pdfUrl + "', '_blank');";
            ClientScript.RegisterStartupScript(this.GetType(), "OpenReport", script, true);
        }

        protected void btnEdit1_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)((Button)sender).NamingContainer;
            Label lblBranchP = (Label)item.FindControl("LabelPrograme");
            Label lblLevel = (Label)item.FindControl("LabelLevel");
            Label lblDegree = (Label)item.FindControl("LabelDegree");
            Label lblBranch = (Label)item.FindControl("LabelBranch");
            Label lblDuration = (Label)item.FindControl("LabelDuration");
            Label lblIntake = (Label)item.FindControl("LabelIntake");

            ddlBranch1.SelectedValue = lblBranchP.Text;
            ddlLevel.SelectedValue = lblLevel.Text;
            ddlDegree.Items.Clear();
            ddlDegree.ClearSelection();
            ddlDegree.Items.Add(lblDegree.Text);
            ddlBranch.Items.Clear();
            ddlBranch.ClearSelection();
            ddlBranch.Items.Add(lblBranch.Text);
            ddlDuration.Items.Clear();
            ddlDuration.ClearSelection();
            ddlDuration.Items.Add(lblDuration.Text);
            txtIntake.Text = lblIntake.Text;

            userBo.Programee_branch = lblBranchP.Text;
            userBo.Level = lblLevel.Text;
            userBo.Degree = lblDegree.Text;
            userBo.Branch = lblBranch.Text;
            userBo.Duration = lblDuration.Text;
            userBo.Intake = lblIntake.Text;
            int Id = userBl.getid(userBo);
            Session["Id"] = Id;
            list.Items.Clear();
            btnSubmit.Text = "Update";
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            DataSet ds  = userBl.showexcel(); 
            listDisplay.DataSource = ds;
            listDisplay.DataBind();
            string filename = listDisplay.DataSource + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = ds;
            dgGrid.DataBind();

            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition","attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }


    }
}