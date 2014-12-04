using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3tireASP
{
    public partial class home : System.Web.UI.Page
    {
        tblproperty tp = new tblproperty();
        DataAccessLayer dacc = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillGridview();
            }

        }
        public void fillGridview()
        {
            GridView1.DataSource = dacc.getDetails();
            GridView1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkDelete = (CheckBox)row.Cells[0].FindControl("ChkSelect");
                    if (chkDelete != null)
                    {
                        if (chkDelete.Checked)
                        {

                            string id1=Convert.ToString( GridView1.DataKeys[row.RowIndex].Value);
                            tp.id = id1;
                            dacc.deleteDetils(tp);
                            fillGridview();
                            
                        }
                    }

                }
            }

        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            tp.Name = txt_userName.Text;
            tp.Pass = txtPassword.Text;
            dacc.insertDetails(tp);
            fillGridview();

        }


    }
}