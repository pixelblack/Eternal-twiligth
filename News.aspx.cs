using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //empezar a cargar dinamicamente todo el contenido       
        DataTable table = DBQuerys.GetPosts(DBQuerys.PostType.News); //tabla que obtendra los datos de la DB
        for(Int32 i = table.Rows.Count-1; i >= 0; i--)
        {
            Panel panel1 = new Panel();
            panel1.CssClass = "col-md-6";           
            /////////////////////////////
            Panel panel2 = new Panel();
            panel2.CssClass = "row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative";
            ////////////////////////////
            Panel panel3 = new Panel();
            panel3.CssClass = "col p-4 d-flex flex-column position-static";
            ///////////////////////////
            Label label1 = new Label();
            label1.CssClass = "h3 mb-1";
            label1.Text = table.Rows[i]["title"].ToString();
            //////////////////////////
            Label label2 = new Label();
            label2.CssClass = "mb-1 text-muted";
            label2.Text = table.Rows[i]["fecha"].ToString();
            //////////////////////////
            Label label3 = new Label();
            label3.CssClass = "card-text mb-auto";
            label3.Text = table.Rows[i]["textContent"].ToString();
            //////////////////////////
            Panel panel5 = new Panel();
            panel5.CssClass = "col-auto d-none d-lg-block";
            ///////////////////////////
            Image image1 = new Image();
            image1.CssClass = "bd-placeholder-img";
            image1.Width = 200;
            image1.Height = 250;          
            image1.ImageUrl = String.Format("HttpImageHandler.ashx?id={0}", table.Rows[i]["id"]);                 
            ///////////////////


            this.MediumNoticesPanel.Controls.Add(panel1);
            panel1.Controls.Add(panel2);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel5);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel5.Controls.Add(image1);
        }
    }   
}