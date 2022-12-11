using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebViewCrud
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                LabelInsertStatus.Text = "";
            }
        }

        protected void FillGridView()
        {
            GridView1.DataSource = CustomerDAL.GetData();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string CustomerID = row.Cells[0].Text;
            CustomerDAL.DeleteRow(CustomerID);
            FillGridView();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox CustomerID = GridView1.Rows[e.RowIndex].Cells[0].Controls[0] as TextBox;
            TextBox ContactName = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            TextBox City = GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
            TextBox Country = GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;

            CustomerDAL.UpdateRow(CustomerID.Text, ContactName.Text, City.Text, Country.Text);
            GridView1.EditIndex = -1;
            FillGridView();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGridView();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string ContactName = TextBoxContactName.Text;
            string City = TextBoxCity.Text;
            string Country = TextBoxCountry.Text;

            if (ContactName.Length == 0 || City.Length == 0 || Country.Length == 0)
            {
                LabelInsertStatus.Text = "Please fill all the fields!";
                return;
            }

            LabelInsertStatus.Text = "";
            CustomerDAL.CreateRow(ContactName, City, Country);
            FillGridView();
        }
    }
}