using System;
using System.Threading;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        this.Validation.Click += this.ValidateForm;
        if(!this.IsPostBack)
        {
            this.realName.Focus();
        }
    } 
    protected void ValidateForm(Object sender,EventArgs e)
    {
        CssValidator("Register");
        if(this.Page.IsValid) // si todos los validators son validos 
        {
            if(DBQuerys.UserExists(this.user.Text))// si el usuario existe
            {
                this.lblStatus.Text = "Ese usuario ya existe";              
            }
            else //si el usuario no existe
            {
                if(this.captcha.Text == this.Session["Captcha"].ToString())
                {
                    DBQuerys.UserRegistry(this.realName.Text, this.user.Text, this.pass.Text, this.email.Text, Convert.ToChar(this.gender.SelectedValue[0]));
                    this.Response.Redirect("Login.aspx");
                }
                else
                {
                    this.captchaFV.ErrorMessage = "Captcha incorrecto";
                    this.captchaFV.IsValid = false;
                }
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