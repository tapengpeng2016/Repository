using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CallBack1 : System.Web.UI.Page, ICallbackEventHandler
{
    private string eventArgument;
    protected void Page_Load(object sender, EventArgs e)
    {
        //appeler la function js
        if (!Page.IsPostBack)
        {
            //créer la référence de callback
            string callbackRef = Page.ClientScript.GetCallbackEventReference(this, //contrôle
                "document.forms[0].compte_emetteur.value",//parapmètre event
                "ClientCallBack",//fonction js à appler
                "null");//contexte

            //appeler DoPostBack sur un changement de sélection
            compte_emetteur.Attributes["onChange"] = callbackRef;

        }
    }
    public void RaiseCallbackEvent(string eventArgument)
    {
        this.eventArgument = eventArgument;
    }
    

    public string GetCallbackResult()
    {
        switch(eventArgument){
            case "P":
            default: 
            return "Compte externe 1|Compte externe 2";
            case "L":
            return "Compte personnel";
        }
    }

    protected void virer_Click(object sender, EventArgs e)
    {

    }
}
