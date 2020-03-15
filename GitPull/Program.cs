using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
 * Pulls from a GIT repository to update local updates to code
 * @binding this program should be run using Windows Task Scheduler or a similar program
 * @author Jeremy Heminger <jeremy.heminger@aquamorusa.com> , <contact@jeremyheminger.com>
 * @date March 14, 2020
 * 
 * @version 0.0.2
 *  @feature pull from a list of repositories
 * @version 0.0.1
 * */
namespace GitPull
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCommand r = new RunCommand();
            if (args.Length < 1)
            {
                r.PullList();
            }
            else
            {
                r.Pull(args[0]);
            }
        }
    }
}
