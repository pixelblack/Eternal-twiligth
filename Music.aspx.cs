using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;


public partial class Music : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        DataTable table = DBQuerys.GetPosts(DBQuerys.PostType.Audio); //tabla que obtendra los datos de la DB
        for(Int32 i = table.Rows.Count-1; i >= 0; i--)
        {
            Panel panel2 = new Panel();
            panel2.CssClass = "col";
            ///////////////////////////
            Panel panel3 = new Panel();
            panel3.CssClass = "card shadow-sm";
            ///////////////////////////
            Image image1 = new Image();
            image1.CssClass = "bd-placeholder-img crd-img-top";
            image1.Style["height"] = "225px";
            image1.Style["width"] = "100%";
            image1.ImageUrl = String.Format("HttpImageHandler.ashx?id={0}", table.Rows[i]["id"]);
            ///////////////////////////
            Panel panel4 = new Panel();
            panel4.CssClass = "card-body";
            ////////////////////////////
            Label label1 = new Label();
            label1.CssClass = "h4";
            label1.Text = table.Rows[i]["title"].ToString() + "<br/>";
            ////////////////////////////
            Label label2 = new Label();
            label2.CssClass = "card-text";
            label2.Text = table.Rows[i]["textContent"].ToString() + "<br/>";
            ////////////////////////////    
            HtmlAudio audio = new HtmlAudio();
            audio.Style["background-color"] = "white";
            audio.Style["border-radius"] = "5px";
            audio.Attributes["controls"] = "controls";  
            audio.Src = String.Format("HttpAudioHandler.ashx?id={0}&mode={1}",table.Rows[i]["id"].ToString(),"all");
            ///////////////////////////
            Label label3 = new Label();
            label3.CssClass = "text-muted";
            label3.Text = "<hr/>" + table.Rows[i]["fecha"].ToString();
            this.MediumNoticesPanel.Controls.Add(panel2);
            panel2.Controls.Add(panel3);
            panel3.Controls.Add(image1);
            panel3.Controls.Add(panel4);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(audio);
            panel4.Controls.Add(label3);
                  
        }
    }
}