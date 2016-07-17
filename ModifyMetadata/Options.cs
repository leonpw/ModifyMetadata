using System;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace ModifyMetadata
{
    internal class Options
    {
        [Option('d', "dateTime", DefaultValue = null, Required = false, HelpText = "DateTime to set date to.")]
        public DateTime? DateTime { get; set; }

        [Option('i', "inputDir", Required = true, HelpText = "Input directory to change.")]
        public string InputDir { get; set; }

        [Option('v', null, HelpText = "Print details during execution.")]
        public bool Verbose { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this).ToString();            
            
        }
    }
}