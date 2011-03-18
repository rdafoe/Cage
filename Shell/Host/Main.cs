using System;
using Gtk;
using Mono.Addins;

[assembly:AddinRoot ("Core", "1.0", Namespace="Cage.Shell")]

namespace Cage.Shell.Host
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			
			//AddinManager.Initialize();
			//AddinManager.Registry.Update();
			
			//foreach (ICommand cmd in AddinManager.GetExtensionObjects<ICommand>())
			//	cmd.Run();
			
			Application.Run ();
		}
	}
}

