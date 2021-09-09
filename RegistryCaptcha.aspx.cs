using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
public partial class RegistryCaptcha : System.Web.UI.Page
{    
    protected void Page_Load(Object sender, EventArgs e)
    {
        this.CreateCaptchaImage();                        
    }

    public void CreateCaptchaImage()
    {
        String[] characters = {"A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G",
                               "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m",
                               "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T",
                               "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z",
                               "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        Bitmap captchaImg = new Bitmap(110, 45);
        Graphics graphics = Graphics.FromImage(captchaImg);
        graphics.Clear(Color.LightSeaGreen);
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        Font font = new Font("Consolas", 27, FontStyle.Bold);
        String captchaStr = "";
        Random rnd = new Random();
        for(Int32 i = 0; i < 5; i++)
        {
            captchaStr += characters[rnd.Next(characters.Length - 1)].ToString();
        }
        this.Session["Captcha"] = captchaStr;
        graphics.DrawString(captchaStr, font, Brushes.White, 3, 3);
        for(Int32 i = 0; i < rnd.Next(5, 10); i++)
        {
            graphics.DrawLine(new Pen(Color.FromArgb(rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255)), rnd.Next(2, 5)), new Point(rnd.Next(110), rnd.Next(45)), new Point(rnd.Next(110), rnd.Next(45)));
        }
        this.Response.ContentType = "image/GIF";
        captchaImg.Save(this.Response.OutputStream, ImageFormat.Gif);
        font.Dispose();
        graphics.Dispose();
        captchaImg.Dispose();

    }
}