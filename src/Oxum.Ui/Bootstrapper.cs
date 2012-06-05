using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrappers.Ninject;

namespace Oxum.Ui
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Ninject.IKernel existingContainer)
        {
            //TODO: Configure kernel
            base.ConfigureApplicationContainer(existingContainer);
        }
    }
}