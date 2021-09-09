<%@ Application Language="C#" %>




<script RunAt="server" Language="c#">

    //Eventos del request
    // estos eventos se lanzan ada vez que se hace un request al servidor 
    #region RequestEventHandler
    void Application_BeginRequest(Object sender, EventArgs e)
    {

    }
    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {

    }
    void Application_AuthorizeRequest(Object sender, EventArgs e)
    {

    }
    void Application_ResolveRequestCache(Object sender, EventArgs e)
    {

    }
    void Application_AcquireRequestState(Object sender, EventArgs e)
    {

    }
    void Application_PreRequestHandlerExcecute(Object sender, EventArgs e)
    {

    }
    void Application_PostRequesthandlerExcecute(Object sender, EventArgs e)
    {

    }
    void Application_ReleaseRequestState(Object sender, EventArgs e)
    {

    }
    void Application_UpdateRequestCache(Object sender, EventArgs e)
    {

    }
    void Application_EndRequest(Object sender, EventArgs e)
    {

    }
    #endregion

    // Eventos de aplicacion
    //estos eventos se lanzan cada vez que la aplicacion se instancia
    #region ApplicationEventHandler
    void Application_Start(Object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        

        // Obtiene las rutas disponibles de la aplicacion y les corta la extension
        RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);

        // definiciones de javascript para el scriptmanager de la masterpage
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/Scripts/jquery-3.4.1.js",
            DebugPath = "~/Scripts/jquery-3.4.1.js",
        });
        ScriptManager.ScriptResourceMapping.AddDefinition("Bootstrap", new ScriptResourceDefinition
        {
            Path = "~/Scripts/bootstrap.bundle.js",
            DebugPath = "~/Scripts/bootstrap.bundle.js",
        });
        ScriptManager.ScriptResourceMapping.AddDefinition("Popper", new ScriptResourceDefinition
        {
            Path = "~/Scripts/popper.js",
            DebugPath = "~/Scripts/popper.js",
        });
    }
    void Application_End(Object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }
    void Application_Error(Object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }
    #endregion

    // Eventos de Sesion
    //estos eventos se lanzan cada vez que una Sesion nueva se instancia
    #region SessionEventHandler
    void Session_Start(Object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión
        //creacion de las variables de Session
        this.Session.Timeout = 60;
        InitialiceSessionVariables();
    }

    void Session_End(Object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión.       
        //reinicio de las variables de Session
        InitialiceSessionVariables();
        FormsAuthentication.SignOut();
    }
    #endregion

    //Funciones personales

    void InitialiceSessionVariables()
    {
        this.Session["valid"] = false; //variable Booleana que especifica si un usuario es valido o no
        this.Session["username"] = null;//variable String que especifica el nombre del usuario actual
        this.Session["email"] = null;// variable String que especifica el correo del usuario actual
   }
</script>