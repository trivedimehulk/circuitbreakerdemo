<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Sample DAL delay (in seconds):<asp:TextBox ID="TxtSampleThreadSleep_seconds" runat="server" Text="5"></asp:TextBox><br />
        Sample Threshold (in seconds):<asp:TextBox ID="TxtMethodExecutionThreshold_seconds" runat="server" Text="3"></asp:TextBox><br />
        Result:<asp:Label ID="LblStatus" runat="server"></asp:Label><br />
    Save Record: <asp:Button ID="BtnSaveRecord" Text="Save Record" runat="server" />
    </div>
    </form>
</body>
</html>
