using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria.ModLoader;

namespace NetEasy
{
	/// <summary>Use the static methods in this class to communicate with NetEasy.</summary>
	public sealed class NetEasy : Mod
	{
		/// <summary>Loads your <see cref="Mod"/> for NetEasy. Call this in <see cref="Mod.PostSetupContent"/>.</summary>
		public static void Register(Mod mod)
		{
			try
			{
				Module.Load(mod);
			}
			catch (ModuleLoadException) { throw; }
			catch (Exception e)
			{
				throw new ModuleLoadException("There was an error registering a Module. " + e.Message, e);
			}
		}

		/// <summary>Handles packets sent from your mod. Call this in <see cref="Mod.HandlePacket(BinaryReader, int)"/>.</summary>
		public static void HandleModule(BinaryReader reader, int whoAmI)
		{
			Module.Receive(reader.BaseStream, whoAmI);
		}

		/// <inheritdoc/>
		public override void Unload()
		{
			Module.Unload();
		}
	}
}