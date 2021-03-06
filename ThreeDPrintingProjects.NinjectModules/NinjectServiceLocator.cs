﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace ThreeDPrintingProjects.NinjectModules
{
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        public IKernel Kernel { get; private set; }

        public NinjectServiceLocator(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return Kernel.Get(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}
