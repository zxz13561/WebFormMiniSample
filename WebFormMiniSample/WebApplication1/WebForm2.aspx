<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        p:last-child{color:red; }
        span{color:blue; }
        #span2{color:green; }
        .cls1{color:aquamarine; }
        .cls2{color:brown; }
        p > span{background-color:antiquewhite; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p class="cls2">p Text1</p>
            <p>
                <span class="cls1">First</span>
                <span id="span2">Second</span>
                <span class="cls1">Third</span>
            </p>
            <p>p Text3</p>
            <span>outside P</span>
        </div>
    </form>
</body>
</html>
