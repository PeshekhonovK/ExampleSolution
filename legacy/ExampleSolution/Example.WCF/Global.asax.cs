﻿using Example.BLL;
using Ninject;
using Ninject.Web.Common;
using System;

namespace Example.WCF
{
    public class Global : NinjectHttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new BLLModule());
        }
    }
}