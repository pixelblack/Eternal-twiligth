using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class Recovery : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {           
        if(!this.IsPostBack)
        {
            this.lblCaptcha.Text = CreateExpresion();
            this.correo.Focus();
        }
    }
    protected void ValidateAndCreateNewPass(Object sender,EventArgs e)
    {
        CssValidator("recovery");
        if(this.Page.IsValid && this.simplyCaptcha.Text == CalculateExpresion(this.lblCaptcha.Text).ToString())
        {           
            this.resumen.Visible = true;     
            DBQuerys.ModifyPassword(this.correo.Text, GenerateNewPass());
            SendMail(this.correo.Text);
        }
    }
    private void CssValidator(String validatorGroupName) // bien
    {
        foreach(BaseValidator item in this.Page.GetValidators(validatorGroupName))
        {
            if(item.IsValid)
            {
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass = "form-control is-valid";
            }
            else
            {
                WebControl s = (WebControl)item.FindControl(item.ControlToValidate);
                s.CssClass += "form-control is-invalid";
            }
        }
    }
    private String CreateExpresion()
    {
        String[] operando = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
                            , "11", "12", "13", "14", "15", "16", "17", "18",
                            "19", "20","uno","dos","tres","cuatro","cinco",
                            "seis","siete","ocho","nueve","diez","once","doce"
                            ,"trece","catorce","quince","dieciseis","diecisiete"
                            ,"dieciocho","diecinueve","veinte"};
        String[] operador = { "+", "-", "*" };
        
        String[] expresion = new String[3];
        Random rnd = new Random();      
        String ex = operando[rnd.Next(0, operando.Length - 1)] + " " + operador[rnd.Next(0, operador.Length - 1)] + " " + operando[rnd.Next(0, operando.Length - 1)];
        return ex;
    }
    private Int32 CalculateExpresion(String expresion)
    {
        Int32 result = new Int32();
        String[] exprecion = expresion.Split(' ');
        switch(exprecion[1])
        {
            case "+": result = ExpresionParse(exprecion[0]) + ExpresionParse(exprecion[2]);
                break;
            case "-": result = ExpresionParse(exprecion[0]) - ExpresionParse(exprecion[2]);
                break;
            case "*": result = ExpresionParse(exprecion[0]) * ExpresionParse(exprecion[2]);
                break;
            default: result = 0;
                break;
        }
        return result;
    }  
    private Int32 ExpresionParse(String operando)
    {     
        switch(operando)
        {
            case "uno": return 1;               
            case "dos": return 2;         
            case "tres": return 3;
            case "cuatro": return 4;
            case "cinco": return 5;
            case "seis":  return 6;              
            case "siete": return 7;            
            case "ocho": return 8;               
            case "nueve": return 9;               
            case "diez":  return 10;             
            case "once":  return 11;              
            case "doce":  return 12;             
            case "trece":  return 13;              
            case "catorce": return 14;              
            case "quince":  return 15;              
            case "dieciseis": return 16;              
            case "diecisiete": return 17;
            case "dieciocho":  return 18;          
            case "diecinueve": return 19;          
            case "veinte":  return 20;
            case "1": return 1;
            case "2": return 2;
            case "3": return 3;
            case "4": return 4;
            case "5": return 5;
            case "6": return 6;
            case "7": return 7;
            case "8": return 8;
            case "9": return 9;
            case "10": return 10;
            case "11": return 11;
            case "12": return 12;
            case "13": return 13;
            case "14": return 14;
            case "15": return 15;
            case "16": return 16;
            case "17": return 17;
            case "18": return 18;
            case "19": return 19;
            case "20": return 20;
            default: return 0;              
        }
    }
    private String GenerateNewPass()
    {
        String[] permisibleCharacters = {"A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G",
                                         "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m",
                                         "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T",
                                         "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z",
                                         "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
        Int32 passLength = 16;
        String pass = "";
        Random rnd = new Random();
        for(Int32 i = 0; i < passLength; i++)
        {
            pass += permisibleCharacters[rnd.Next(permisibleCharacters.Length - 1)];
        }
        return pass;
    }
    private void SendMail(String to)
    {

        String From = ConfigurationManager.AppSettings["PageEmail"];
        String asunto = "Se actualizo la contraseña";
        String body = "Usted ha solicitado el servicio de recuperacion de contraseña." +
            "Debido a la perdida de su contraseña actial se le ha generado una nueva completamente segura desde 0" +
            "su contraseña actual es" + DBQuerys.GetPassByEmail(this.correo.Text) + "  .Recuerde cambiarla mas tarde";

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Port = Int32.Parse(ConfigurationManager.AppSettings["SmtpClientPort"]);
        client.Credentials = new NetworkCredential(From, ConfigurationManager.AppSettings["PageEmailPass"]);     
        client.Send(From, to, asunto, body);     
    }
}