using BRL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnSaveRecord.Click += BtnSaveRecord_Click;
    }

    private void BtnSaveRecord_Click(object sender, EventArgs e)
    {
        RecordMaster rm = new RecordMaster();
        try
        {
            bool result = rm.SaveRecord(TxtMethodExecutionThreshold_seconds.Text,TxtSampleThreadSleep_seconds.Text);
            if (result)
            {
                LblStatus.Text = "Record saved.";
            }
            else
            {
                LblStatus.Text = "Could not save recrod";
            }
        }
        catch (Exception ex)
        {
            LblStatus.Text = "Could not save recrod. Error->" + ex.Message;
        }
    }
}