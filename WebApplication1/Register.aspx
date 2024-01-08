<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  

    <title></title>
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
      <style>
          #frm1{
            width: 90%;
            margin: 20px;
            box-shadow: 0px 10px 10px;
            margin-left: 5%;
            margin-right: 5%;
            padding: 20px;
        }
         table, th,td {
             border : 1px solid gray;
        }
          #form {
               box-shadow: 0px 7px 7px;
               border:1px solid black;
          }
          #btns {
              margin-left:500px;
          }
       
    </style>

    <script>
        function numeric(evt) {
            var charcode = (evt.which) ? event.which : event.keyCode;
            if (charcode > 31 && ((charcode >= 48 && charcode <= 57) || charcode == 46)) {
                return true;
            } else {
                alert("Please  Enter Numeric values");
                return false;
            }


        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <div id="form">        
     <div id="frm1">

         <div class="row">
  <div class="col">
      <div class="form-group">
                    <span><small style="color: red">*</small></span>
                    <label for=""><b>Select Programme/Branch Type</b> </label>
                   
                    <asp:DropDownList ID="ddlBranch1" class="form-control" ToolTip="Please Select Branch Type" runat="server" AutoPostBack="True" TabIndex="1"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Please Select Branch Type" ControlToValidate="ddlBranch1"></asp:RequiredFieldValidator>
       </div>
  </div>
  <div class="col">

      <div class="form-group">
                    <span><small style="color: red">*</small></span>
                    <label for=""><b>Select Level</b> </label>
                    
                    <asp:DropDownList ID="ddlLevel" class="form-control" ToolTip="Please Select Level" runat="server" AutoPostBack="True" TabIndex="2" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Please Select Level" ControlToValidate="ddlLevel"></asp:RequiredFieldValidator>
       </div>
  </div>
</div>

         <div class="row">
  <div class="col">
       <div class="form-group">
                    <span><small style="color: red">*</small></span>
                    <label for=""><b>Select Affiliated Degree</b> </label>
                    <asp:DropDownList ID="ddlDegree" class="form-control" ToolTip="Please Select Degree" runat="server" AutoPostBack="True" TabIndex="3" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Please Select Degree" ControlToValidate="ddlDegree"></asp:RequiredFieldValidator>
       </div>
  </div>
  <div class="col">
      
       <div class="form-group">
                   <span><small style="color: red">*</small></span>
                    <label for=""><b>Select Affiliated Programme/Branch </b> </label>
                    <asp:DropDownList ID="ddlBranch" class="form-control" ToolTip="Please Select Branch" runat="server" AutoPostBack="True" TabIndex="4" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Please Select Branch" ControlToValidate="ddlBranch"></asp:RequiredFieldValidator>
       </div>
  </div>
</div>
      
         
         <div class="row">
  <div class="col">
       <div class="form-group">
                    <span><small style="color: red">*</small></span>
                    <label for=""><b>Select Duration/In Year</b> </label>
                    <asp:DropDownList ID="ddlDuration" class="form-control" ToolTip="Please Select Duration of Course" runat="server" AutoPostBack="True" TabIndex="5"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Please Select Duration" ControlToValidate="ddlDuration"></asp:RequiredFieldValidator>
       </div>
  </div>
  <div class="col">
       <div class="form-group">
                    <span><small style="color: red">*</small></span>
                    <label for="exampleInputEmail1"><b>Intake</b> </label>
                    <asp:TextBox ID="txtIntake" runat="server" onkeypress="return numeric(event)" class="form-control" MaxLength="3"  ToolTip="Please Enter Intake" placeholder="Enter Intake" TabIndex="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Intake" ControlToValidate="txtIntake" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </div>
  </div>
</div>
      
      <div class="row">
  <div class="col">      
          <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary"  Text="ADD" ToolTip="Submit Form" CausesValidation="true" TabIndex="7" OnClick="btnAdd_Click" Style="margin-left:600px;" />
      </div>
          </div>
     
             <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" runat="server" ForeColor="red" ShowSummary="False" /><br />
         <div class="row">
              <div class="col">
                   <asp:ListView ID="list" runat="server" class="listview" Visible="true" style="width:100%; margin-left:30%;" >
              <LayoutTemplate>
                <table id="Table1" runat="server" style="width:90%; margin-left:5%; ">
                    <tr id="Tr1" runat="server">
                        <th>Branch_Type</th>
                         <th>Level</th>
                         <th>Degree</th>
                         <th>Branch</th>
                         <th>Duration</th>
                         <th>Intake</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>

                   <td>
               
                        <asp:Label runat="server" ID="LabelPrograme" Text='<%# Eval("PROGRAME") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabelLevel" Text='<%# Eval("Level") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabelDegree" Text='<%# Eval("Degree") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabelBranch" Text='<%# Eval("Branch") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabelDuration" Text='<%# Eval("Duration") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabelIntake" Text='<%# Eval("Intake") %>' />
                    </td>

                      <td>
                          <asp:Button ID="btnEdit1" runat="server" Text="Edit"   class="btn btn-primary" CausesValidation="false" OnClick="btnEdit1_Click"/>
                     </td>
                </tr>
             
            </ItemTemplate>


         </asp:ListView>
         <br />
         <br />
        </div>
               </div>
             <br />
             <div id ="btns">
           <asp:Button ID="btnSub" runat="server" class="btn btn-primary"  Text="Submit" ToolTip="Submit Form" TabIndex="9" OnClick="btnSub_Click" CausesValidation="false"  />
         <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary" ToolTip="Clear Form " CausesValidation="false" TabIndex="10" OnClick="btnClear_Click"/>
         <asp:Button ID="btnReport" runat="server" Text="Report" CausesValidation="false"  class="btn btn-primary" ToolTip="Generate Report " OnClick="btnReport_Click"/>
          <asp:Button ID="btnExcel" runat="server" Text=" Excel Report" CausesValidation="false"  class="btn btn-primary" ToolTip="Generate Excel  Report "  OnClick="btnExcel_Click"/>
                 </div><br /><br />
         <asp:ListView ID="listDisplay" runat="server"  class="listview" >
           
          
             <LayoutTemplate>
                 <table id="Table2" runat="server" style=" margin-left:20%; " >
                     <tr id="Tr2" runat="server">
                         <td id="Td1" runat="server">
                             <table id="itemPlaceholderContainer" runat="server"  style="">
                                 <tr id="Tr3" runat="server" style="">
                                     <th id="Th1" runat="server">ID</th>
                                     <th id="Th2" runat="server">PROGRAME</th>
                                     <th id="Th3" runat="server">LEVEL</th>
                                     <th id="Th4" runat="server">DEGREE</th>
                                     <th id="Th5" runat="server">BRANCH</th>
                                     <th id="Th6" runat="server">DURATION</th>
                                     <th id="Th7" runat="server">INTAKE</th>
                                 </tr>
                                 <tr id="itemPlaceholder" runat="server">
                                 </tr>
                             </table>
                         </td>
                     </tr>
                     
                 </table>
             </LayoutTemplate>
                <ItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PROGRAMELabel" runat="server" Text='<%# Eval("PROGRAME") %>' />
                     </td>
                     <td>
                         <asp:Label ID="LEVELLabel" runat="server" Text='<%# Eval("LEVEL") %>' />
                     </td>
                     <td>
                         <asp:Label ID="DEGREELabel" runat="server" Text='<%# Eval("DEGREE") %>' />
                     </td>
                     <td>
                         <asp:Label ID="BRANCHLabel" runat="server" Text='<%# Eval("BRANCH") %>' />
                     </td>
                     <td>
                         <asp:Label ID="DURATIONLabel" runat="server" Text='<%# Eval("DURATION") %>' />
                     </td>
                     <td>
                         <asp:Label ID="INTAKELabel" runat="server" Text='<%# Eval("INTAKE") %>' />
                     </td>

                      <td>
                          <asp:Button ID="btnEdit" runat="server" Text="Edit"   class="btn btn-primary" CausesValidation="false" OnClick="btnEdit_Click"/>
                     </td>
                 </tr>
             </ItemTemplate>
               
          
         </asp:ListView>

                

         </div>
        
     </div>
        <asp:Label ID="HiddenId" runat="server" Visible ="false" ></asp:Label>
       
    </form>
</body>
</html>

