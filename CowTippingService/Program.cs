using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CowTippingService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<CowTipper>(s =>                                   
                {
                    s.ConstructUsing(name=> new CowTipper(2000));               
                    s.WhenStarted(tc => tc.Start());                        
                    s.WhenStopped(tc => tc.Stop());                         
                });
                x.RunAsLocalSystem();                                       

                x.SetDescription("Lets Kill Cows.");                   
                x.SetDisplayName("Cow Tipper");                                  
                x.SetServiceName("CowTipper");                                  
            });                                                             

            var exitCode = (int) Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }                                                                               
    }
}
