
using System;
using Gtk;
using Gdk;

namespace Cage.Shell.Toolbars
{
	internal class FloatingDock: Gtk.Window
	{
		DockToolbar bar;
		
		public FloatingDock (DockToolbarFrame frame): base (Gtk.WindowType.Toplevel)
		{
			SkipTaskbarHint = true;
			Decorated = false;
			TransientFor = frame.TopWindow;
		}
		
		public void Attach (DockToolbar bar)
		{
			this.bar = bar;
			bar.FloatingDock = this;
			Frame f = new Frame ();
			f.Shadow = ShadowType.Out;
			f.Add (bar);
			Add (f);
			f.Show ();
			bar.Show ();
			Show ();
		}
		
		public void Detach ()
		{
			bar.FloatingDock = null;
			((Frame)bar.Parent).Remove (bar);
		}
	}
}
