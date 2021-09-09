using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Web.Configuration;

public partial class Login : System.Web.UI.Page
{ 
    protected void Page_Load(Object sender, EventArgs e)
    {    
        if(!this.IsPostBack)
        {
            this.user.Focus();          
        }              
    }     
    protected void ValidateForm(Object sender , EventArgs e)
    {      
        CssValidator("login");     
        if(this.Page.IsValid) // si se llenan los 2 textbox
        {         
            if(DBQuerys.ValidateLogin(this.user.Text,this.pass.Text)) // si existe ya el usuario
            {
                this.Session["valid"] = true;
                this.Session["username"] = this.user.Text;             
                FormsAuthentication.RedirectFromLoginPage((String)this.Session["username"], false);
              
               
            }
            else // si el usuario no existe o es incorrecto
            {               
                this.lblStatus.Text = "Usuario o contraseña incorrectos";
                this.pass.CssClass = "form-control form-control-lg is-invalid";
                
            }
        }      
    } 
    private void CssValidator(String validatorGroupName) 
    {
        foreach(BaseValidator item in this.Page.GetValidators(validatorGroupName))
        {
            if(item.IsValid)
            {                             
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass = "form-control form-control-lg is-valid";             
            }
            else
            {               
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass += "form-control form-control-lg is-invalid";
            }
        }
    }     
}

