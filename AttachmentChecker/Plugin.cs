using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentChecker
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }

    public class Plugin: Plugin<Config>
    {
        public override string Author => "and.you";
        public override string Name => "AttachmentChecker";
        public override string Prefix => "AttachmentChecker";
        public override Version Version => new("9.5.0-r1");
        public override void OnEnabled()
        {
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}
