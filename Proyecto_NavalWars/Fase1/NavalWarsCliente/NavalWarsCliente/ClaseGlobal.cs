using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsCliente
{
    public class ClaseGlobal
    {
        public static ServiceReference1.Service1SoapClient servidorPrincipal = new ServiceReference1.Service1SoapClient();

    }
}