using ConsoleApp1.LC.Array;
using Krones.IAM.Identity.Client;
using Krones.IAM.Identity.Interface.Interfaces;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Krones.IAM.Identity.Interface.DTO;
using Krones.IAM.Identity.Interface.Enums;
using Krones.IAM.Permission.Interface.Interfaces;
using Krones.IAM.Permission.Client;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ConsoleApp1.ProxyPattern;
using ConsoleApp1.AsyncProg;
using ConsoleApp1.AsyncProg.Par;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //new AsyncProg.AsyncProg().Write();

            //ExceptionHandle.Enter();

            //DataSharingAndSync.Entry();

            //Collections.Entry();

            //BarrierDemo.Demo();

            //CountDownEventDemo.Demo();

            //ResetEventsDemo.Demo();

            ParallelDemo.Demoo();
        }
    }
}