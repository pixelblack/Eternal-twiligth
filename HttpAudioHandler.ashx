<%@ WebHandler Language="C#" Class="HttpAudioHandler" %>

using System;
using System.Web;

public class HttpAudioHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "audio/mp3";
        Byte[] bytes = DBQuerys.GetAudioById(Int32.Parse(context.Request.Params["id"]));
          //si en request se manda el parametro all ,, se muestra la cancion entera ,, 
          //este prametro solo se envia desde la pagina de musica
        if(!(context.Request.Params["mode"] == "all"))
        {
            Int32 percent = bytes.Length * 30/100;
            Array.Resize(ref bytes,percent);
        }

        context.Response.BinaryWrite(bytes);
    }

    public bool IsReusable
    {
        get {return false;}
    }

}