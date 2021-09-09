using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class Crud : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        this.btnInsert.ServerClick += this.ValidateForm;                
    }   
    protected void ValidateForm(Object sender, EventArgs e)
    {
        CssValidator("Insert");
        if(this.Page.IsValid) // si todos los validators son validos 
        {
            if(DBQuerys.UserExists(this.txtUser.Text))// si el usuario existe
            {
                this.lblStatus.Text = "Ese usuario ya existe";
            }
            else //si el usuario no existe
            {              
                    DBQuerys.UserRegistry(this.txtName.Text, this.txtUser.Text, this.txtPass.Text, this.txtEmail.Text, Convert.ToChar(this.drGender.SelectedValue[0]));
                    this.lblStatus.CssClass = "text-success";
                    this.lblStatus.Text = "Usuario registrado correctamente";
                    
            }
        }
    } // valida el formulario de ingresar usuario a la DB
    private void CssValidator(String validatorGroupName)
    {
        foreach(BaseValidator item in this.Page.GetValidators(validatorGroupName))
        {
            if(item.IsValid)
            {
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass = "form-control form-control-sm is-valid";
            }
            else
            {
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass += "form-control form-control-sm is-invalid";
            }
        }
    } // aplica estilo a los TextBox
    protected void btnsubirf_Click(Object sender, EventArgs e)
    {       
        this.lblStatusf.Text = "";
        if(!String.IsNullOrEmpty(this.fluf.FileName))
        {
            String ext = Path.GetExtension(this.fluf.FileName);
                  ext = ext.ToLower();
            if(ext == ".png" || ext==".jpg" || ext == ".bmp" || ext == ".gif" || ext == ".jpeg")
            {
                if(Convert.ToInt32(this.fluf.PostedFile.ContentLength) > 1048576)
                {
                    this.lblStatusf.Text = "Error , la foto debe ser menor a 1 MB";
                }
                else
                {
                    this.fluf.SaveAs(this.Server.MapPath("Resources/FotosSubidas/") + this.fluf.FileName);
                    this.imgf.ImageUrl = "Resources/FotosSubidas/" + this.fluf.FileName;
                }
            }
            else
            {
                this.lblStatusf.Text = "El archivo no tiene un formato valido";
            }         
        }
        else
        {
            this.lblStatusf.Text = "Debe seleccionar una foto";
        }
    } //sube una foto a la pagina que se guarda en Resources/FotosSubidas
    protected void btnsubira_Click(Object sender, EventArgs e)
    {
        this.lblStatusa.Text = "";
        if(!String.IsNullOrEmpty(this.flua.FileName))
        {
            String ext = Path.GetExtension(this.flua.FileName);
            ext = ext.ToLower();
            if(ext == ".mp3" || ext ==".wav")
            {
                if(Convert.ToInt32(this.flua.PostedFile.ContentLength) > 5242880)
                {
                    this.lblStatusa.Text = "Error ,el audio debe ser menor a 5 MB";
                }
                this.flua.SaveAs(this.Server.MapPath("Resources/AudiosSubidos/") + this.flua.FileName);
                // this.imga.ImageUrl = "Resources/AudiosSubidos/" + this.flua.FileName; de ser posible poner la foto de la etiqueta de los metadatos
                this.imga.AlternateText = "Resources/AudiosSubidos/" + this.flua.FileName;
            }
            else
            {
                this.lblStatusa.Text = "El archivo no tiene un formato valido";
            }
            
        }
        else
        {
            this.lblStatusa.Text = "Debe seleccionar un archivo de audio";
        }
    } //sube un audio a la pagina que se guarda en Resources/FotosSubidas
    protected void ChangePostSelection(Object sender, EventArgs e)
    {
        if(this.drdpost.SelectedValue == "noticia" || this.drdpost.SelectedValue == "foto")
        {      
            this.flua.Visible = false;
            this.lblStatusa.Visible = false;
            this.imga.Visible = false;
            this.btnSubira.Visible = false;
        }
        else
        {    
            this.flua.Visible = true;
            this.lblStatusa.Visible = true;
            this.imga.Visible = true;
            this.btnSubira.Visible = true;
        }  
    } // hace visible o no el formulario de subir audio
    protected void Publish(Object sender,EventArgs e)
    {
        if(this.drdpost.SelectedValue == "noticia" || this.drdpost.SelectedValue == "foto")
        {
            //subir fotos y noticias        
            if(!(this.imgf.ImageUrl == "~/Resources/NullIcon.png"))
            {              
                 DBQuerys.UploadPost(
                    this.txtTitlePost.Text, 
                    this.txtTextPost.Text,
                    DateTime.Now.Date.ToShortDateString(),
                    this.GetBytesOfFile(this.Server.MapPath("") + "/" + this.imgf.ImageUrl),
                    this.drdpost.SelectedValue,null
                    );
                this.statusPost.Text = "Se publico correctamente";
            }
            else
            {
                this.lblStatusf.Text = "Debe subir una foto";
            }
                 
        }
        else
        {
            //subir canciones
            Byte[] imagen = null;   
            if(!(this.imgf.ImageUrl == "~/Resources/NullIcon.png"))
            {
                imagen = this.GetBytesOfFile(this.Server.MapPath("") + "/" + this.imgf.ImageUrl);
            }
            else
            {
                this.lblStatusf.Text = "Debe subir una foto";
            }

            Byte[] audio = null;
            if(!(this.imgf.ImageUrl == "~/Resources/.png")) 
            {
                audio = this.GetBytesOfFile(this.Server.MapPath("") + "/" + this.imga.AlternateText);              
            }
            else
            {
                this.lblStatusa.Text = "Debe subir una cancion";
            }
            DBQuerys.UploadPost(
                this.txtTitlePost.Text,
                this.txtTextPost.Text,
                DateTime.Now.Date.ToShortDateString(),
                imagen,
                this.drdpost.SelectedValue,
                audio);
            this.statusPost.Text = "Se publico correctamente";
        }

        this.txtTitlePost.Text = String.Empty;
        this.txtTextPost.Text = String.Empty;
        this.imgf.ImageUrl = "~/Resources/NullIcon.png";
        this.imga.ImageUrl = "~/Resources/audioFile.png";

        this.CleanUploadResources();
    } //publica el post en la DB , verificar si funciona
    protected void btnErasePost_Click(Object sender,EventArgs e)
    {
        if(this.drpErasePost.SelectedIndex == 0)
        {
            DBQuerys.DeletePostByID(this.txtErasePost.Text);
            this.statusErasePost.Text = "Se elimino el post correctamente";
        }
        else
        {
            DBQuerys.DeletePost(this.txtErasePost.Text);
            this.statusErasePost.Text = "Se elimino el post correctamente";
        }
    } //Borra un post en depedendencia del dpErasePost.SelectedIndex
    protected Byte[] GetBytesOfFile(String path)
    {
        StreamReader re = new StreamReader(path);      
        BinaryReader reader = new BinaryReader(re.BaseStream);
        Byte[] bytes = reader.ReadBytes((Int32)re.BaseStream.Length);
        reader.Close();
        reader.Dispose();
        return bytes;
    } //Retorna los Bytes[] de un archivo binario (audio o foto)
    protected void CleanUploadResources()
    {
        DirectoryInfo dif = new DirectoryInfo(this.Server.MapPath("") + "/Resources/FotosSubidas");
        foreach(FileInfo fi in dif.GetFiles("*"))
        {
            fi.Delete();
        }
        DirectoryInfo dia = new DirectoryInfo(this.Server.MapPath("") + "/Resources/AudiosSubidos");
        foreach(FileInfo fi in dia.GetFiles("*"))
        {
            fi.Delete();
        }
    } // elimina el audio y la foto de la carpeta de AudiosSubidos y FotosSubidas
 
}
