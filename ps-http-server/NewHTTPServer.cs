using System;
using System.Collections.Generic;
using System.Net;
using System.Management.Automation;

namespace new_httpserver
{
    [Cmdlet(VerbsCommon.New, "HTTPServer")]
    public class NewHTTPServer : Cmdlet //Extending Class1 from Cmdlet Class
    {
        // Port parameter.
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string URI { get; set; } // URL the HTTP server will run on.

        // Port parameter.
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Port { get; set; } // Port the HTTP server will run on.
        // URL the server will listen on.
        private string url;
        private HttpListener httpServer;
        protected override void BeginProcessing() //Add this Begin function method
        {
            httpServer = new HttpListener();
        }

        protected override void ProcessRecord() //Add this Process function method
        {
            // Create the URL out of URI and Port.
            if(Port != null) {
                url = URI + ":" + Port + "/";
            } else {
                url = URI + ":" + "8080/";
            }
            //Add ending output codes
            httpServer.Prefixes.Add(url);
            httpServer.Start();
            Console.WriteLine("Starting the HTTP Server on {0}.", url);
        }

        protected override void EndProcessing() //Add this End function method
        {
            httpServer.Close();
        }
    }
}
