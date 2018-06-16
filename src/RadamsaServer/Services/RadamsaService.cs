using RadamsaServer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RadamsaServer.Services
{
    public class RadamsaService
    {
        private Process BuildCommand(FuzzRequest request)
        {
            var command = $"echo \"{request.Input}\" | radamsa";

            if (!request.Seed.Equals(null))
            {
                command += $" --seed {request.Seed}";
            }
                
            if (!request.Ammount.Equals(1))
            {
                command += $" -n {request.Ammount}";
            }

            command = command.Replace("\"", "\\\"");

            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\""
                }
            };
        }

        public string GetFuzzedOutput(FuzzRequest request)
        {
            var command = BuildCommand(request);
            command.Start();

            var output = command.StandardOutput.ReadToEnd();

            command.WaitForExit();

            return output;
        }
    }
}
