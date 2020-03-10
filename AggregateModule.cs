using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace NetEasy
{
    /// <summary>Provides a way to send several modules as one <see cref="ModPacket"/>. Useful for avoiding lots of net updates. Call <see cref="Module.Send(Node?, Node?, bool)"/> to send the data.</summary>
    [Serializable]
    public class AggregateModule : Module
    {
        /// <summary>All the modules to send.</summary>
        public List<Module> Modules { get; set; } = new List<Module>();

        /// <inheritdoc/>
        protected internal override void Receive()
        {
            foreach (var module in Modules)
            {
                module.Receive();
            }
        }
    }
}