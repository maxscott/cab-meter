using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Pipeline;

namespace CabMeter.DependencyInjection
{
    public class StructureMapConfig
    {
        public static void Config()
        {
            StructureMap.ObjectFactory.Initialize(o =>
                {
                    o.Scan(scanner => scanner.Assembly("CabMeter"));
                }); 
        }
    }
}