
namespace Cage.Shell.Toolbars
{
	internal class PlaceholderWindow: Gtk.Window
	{
		Gdk.GC redgc;
		
		public PlaceholderWindow (DockToolbarFrame frame): base (Gtk.WindowType.Toplevel)
		{
			SkipTaskbarHint = true;
			Decorated = false;
			TransientFor = frame.TopWindow;
			Realize ();
			redgc = new Gdk.GC (GdkWindow);
	   		redgc.RgbFgColor = new Gdk.Color (255, 0, 0);
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose args)
		{
			base.OnExposeEvent (args);
			int w, h;
			this.GetSize (out w, out h);
			this.GdkWindow.DrawRectangle (redgc, false, 0, 0, w-1, h-1);
	  		return true;
		}
	}
}
