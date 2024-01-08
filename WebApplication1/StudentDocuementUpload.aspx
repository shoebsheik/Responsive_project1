<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDocuementUpload.aspx.cs" Inherits="WebApplication1.StudentDocuementUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function numeric(evt) {
            var charcode = (evt.which) ? event.which : event.keyCode;
            if (charcode > 31 && ((charcode >= 48 && charcode <= 57) || charcode == 46)) {
                return true;
            } else {
                alert("Please Enter Roll number in Numeric Values");
                return false;
            }


        }

        function visible() {
            document.getElementsByClassName("labels").style.visibility = "visible";
        }

    </script>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-4">
                    <div class="form-group">
                        <span><small style="color: red">*</small></span>

                        <asp:Label ID="Label1" runat="server" Text="Please Enter Roll Number  :"></asp:Label>
                        <asp:TextBox ID="txtRoll" runat="server" class="form-control" onkeypress="return numeric(event)" ToolTip="Please Enter Roll Number "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Roll Number" ControlToValidate="txtRoll" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                    </div>
                </div>
            </div>

            <asp:Button ID="btnshow" runat="server" class="btn btn-primary" Text="Show" OnClick="btnshow_Click" OnClientClick="return visible()" />

            <div id="labelControl">

                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <asp:Label ID="Label2" class="labels" runat="server" Text="Student Name  :" Visible="False"></asp:Label>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <asp:Label ID="Label3" class="labels" runat="server" Text="College  :" Visible="False"></asp:Label>
                            <asp:Label ID="lblclg" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <asp:Label ID="Label4" class="labels" runat="server" Text="City  :" Visible="False"></asp:Label>
                            <asp:Label ID="lblcity" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <asp:Label ID="Label5" class="labels" runat="server" Text="Student Email  :" Visible="False"></asp:Label>
                            <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <div>
                    <h4 class="labels" style="visibility: hidden"><b>Document Upload :</b></h4>
                </div>

                <asp:ListView ID="ListView1" runat="server">
                    <LayoutTemplate>
                        <table id="Table1" runat="server" style="width: 90%; margin-left: 5%;">
                            <tr id="Tr1" runat="server">
                                <th>Sr No.</th>
                                <th>Document Name</th>
                                <th>fileName</th>
                                <th>FileUpload</th>
                                <th>Upload</th>
                                <th>Preview</th>
                                <th>Download</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("DOC_ID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lbldoc" Text='<%# Eval("DOC_NAME") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblfileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Upload Document" />
                            </td>
                            <td>
                                <asp:Button ID="btnUploadAddhar" runat="server" Text="Upload" class="btn btn-primary" OnClick="btnUploadAddhar_Click" ToolTip="Click to Upload Document" />
                            </td>
                            <td>
                                <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" CommandArgument='<%# Eval("FILEPATH") %>' ToolTip="Preview Document" />

                            </td>
                            <td>
                                <asp:Button ID="btndownload" runat="server" Text="Download" OnClick="btndownload_Click" ToolTip="Download Document" />
                            </td>


                        </tr>


                    </ItemTemplate>


                </asp:ListView>



            </div>

            <div class="modal fade" id="pdfModal" tabindex="-1" role="dialog" aria-labelledby="pdfModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="pdfModalLabel">PDF Preview</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <iframe id="pdfFrame" runat="server" style="width: 100%; height: 500px;"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
