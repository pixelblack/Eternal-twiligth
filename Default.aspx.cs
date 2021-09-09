using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        GenerateContent(DBQuerys.GetPosts(DBQuerys.PostType.News),"Noticia");
        GenerateContent(DBQuerys.GetPosts(DBQuerys.PostType.Audio),"Audio");
        GenerateContent(DBQuerys.GetPosts(DBQuerys.PostType.Images),"Foto");       
    }

    public void GenerateContent(DataTable table, String type)
    {
        Panel panel1 = new Panel();
        panel1.CssClass = "col-lg-4";
        ///////////////////////////
        Image image1 = new Image();
        image1.CssClass = "bd-placeholder-img rounded-circle";
        image1.Width = 140;
        image1.Height = 140;
        image1.ImageUrl = String.Format("HttpImageHandler.ashx?id={0}", table.Rows[table.Rows.Count-1]["id"]);
        ///////////////////////////
        Label label1 = new Label();
        label1.CssClass = "h2 d-block";
        label1.Text = table.Rows[table.Rows.Count-1]["title"].ToString();
        //////////////////////////
        Label label2 = new Label();      
        label2.Text = table.Rows[table.Rows.Count-1]["textContent"].ToString();
        ////////////////////////////
        Label label3 = new Label();
        label3.CssClass = "h4 d-block text-muted";
        label3.Text = type + " mas reciente";
        //////////////////////////////////
        panel1.Controls.Add(label3);
        panel1.Controls.Add(image1);
        panel1.Controls.Add(label1);
        panel1.Controls.Add(label2);
        this.lastPostPanel.Controls.Add(panel1);
    }
}