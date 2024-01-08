<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translation.aspx.cs" Inherits="WebApplication1.Translation" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <table border="0">
        <tr>
            <td>
                Source Language
            </td>
            <td>
                <select id="ddlSource">
                    <option value="ZH">Chinese (Mandarin)</option>
                    <option value="CS">Czech</option>
                    <option value="DA">Danish</option>
                    <option value="NL">Dutch</option>
                    <option value="EN" selected = "selected">English</option>
                    <option value="ET">Estonian</option>
                    <option value="FR">French</option>
                    <option value="KA">Georgian</option>
                    <option value="DE">German</option>
                    <option value="HI">Hindi</option>
                    <option value="HU">Hungarian</option>
                    <option value="LA">Latin</option>
                    <option value="LV">Latvian</option>
                    <option value="LT">Lithuanian</option>
                    <option value="SR">Serbian</option>
                    <option value="CY">Welsh</option>
                    <option value="XH">Xhosa</option>
                </select>
            </td>
            <td>
            </td>
            <td>
                Target Language
            </td>
            <td>
                <select id="ddlTarget">
                    <option value="ZH">Chinese (Mandarin)</option>
                    <option value="CS">Czech</option>
                    <option value="DA">Danish</option>
                    <option value="NL">Dutch</option>
                    <option value="EN">English</option>
                    <option value="ET">Estonian</option>
                    <option value="FR" selected = "selected">French</option>
                    <option value="KA">Georgian</option>
                    <option value="DE">German</option>
                    <option value="HI">Hindi</option>
                    <option value="HU">Hungarian</option>
                    <option value="LA">Latin</option>
                    <option value="LV">Latvian</option>
                    <option value="LT">Lithuanian</option>
                    <option value="SR">Serbian</option>
                    <option value="CY">Welsh</option>
                    <option value="XH">Xhosa</option>
                </select>
            </td>
            <td>
                <input type="button" id="btnTranslate" value="Translate" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <textarea id="txtSource" rows="10" cols="30"></textarea>
            </td>
            <td>
            </td>
            <td colspan="2">
                <textarea id="txtTarget" rows="10" cols="30"></textarea>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("#btnTranslate").click(function () {
            var url = "https://translation.googleapis.com/language/translate/v2?key=API_Key";
            url += "&source=" + $("#ddlSource").val();
            url += "&target=" + $("#ddlTarget").val();
            url += "&q=" + escape($("#txtSource").val());
            $.get(url, function (data, status) {
                $("#txtTarget").val(data.data.translations[0].translatedText);
            });
        });
    </script>
  
</body>
</html>