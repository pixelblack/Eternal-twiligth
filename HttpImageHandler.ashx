<%@ WebHandler Language="C#" Class="HttpImageHandler" %>

using System;
using System.Web;


public class HttpImageHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context)
    {       
        context.Response.ContentType = "image/jpg";
        context.Response.BinaryWrite(DBQuerys.GetImgById(Int32.Parse(context.Request.Params["id"])));
    }

    public bool IsReusable
    {
        get {return false;}
    }

}