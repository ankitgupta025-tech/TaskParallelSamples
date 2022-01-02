using Krones.IAM.Permission.Client;
using Krones.IAM.Permission.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Iam
    {
        public void ApiCalls() 
        {

            //IIdentityClient client = new IdentityClient("https://iamidentity.azurewebsites.net/");
            //await client.Connect("HMI-IAM-Service", "jWRhPu5ucMn0iyyhSkOp35DSegCCqc2pe4wNQknHb1Z7gh0WLFZQSXQTDOJkOI0c");
            //var options = await client.GetLoginOptions();

            //await client.Connect("HMI-IAM-Service", "jWRhPu5ucMn0iyyhSkOp35DSegCCqc2pe4wNQknHb1Z7gh0WLFZQSXQTDOJkOI0c");
            //var user = (await client.GetUsers()).ToList();
            //var tdto = new TransponderDto { TransponderId = new byte[] { }, TransponderType = TransponderType.MifareDESfire };

            ////client.SetUserTranspondersMapping("e249415f-559b-4e24-9447-1e9594ddc116", );

            IPermissionClient permissionClient = new PermissionClient("https://iampermission.azurewebsites.net/", "https://iamidentity.azurewebsites.net/");

            //await permissionClient.Connect("HMI-IAM-Service", "jWRhPu5ucMn0iyyhSkOp35DSegCCqc2pe4wNQknHb1Z7gh0WLFZQSXQTDOJkOI0c");

            //var p = await permissionClient.AddApplication(new Krones.IAM.Permission.Interface.DTO.ApplicationAndMachineInfoDto { 
            //  Application = new Krones.IAM.Permission.Interface.DTO.ApplicationDto { },
            //  Machine = new Krones.IAM.Permission.Interface.DTO.MachineInfoDto { }

            //});
        }
    }
}
