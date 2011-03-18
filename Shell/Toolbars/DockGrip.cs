
using System;
using Gtk;
using Gdk;

namespace Cage.Shell.Toolbars
{
	internal class DockGrip: ToolItem
	{
		static bool IsWindows = true;
		static int GripSize = IsWindows? 4 : 6; //wimp theme engine looks ugly with width 6
		const int MarginLeft = 1;
		const int MarginRight = 3;
		
		public DockGrip ()
		{
		}
		
		protected override void OnSizeRequested (ref Requisition req)
		{
			if (Orientation == Orientation.Horizontal) {
				req.Width = GripSize + MarginLeft + MarginRight;
				req.Height = 0;
			} else {
				req.Width = 0;
				req.Height = GripSize + MarginLeft + MarginRight;
			}
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose args)
		{
			Rectangle rect = Allocation;
			if (Orientation == Orientation.Horizontal) {
				rect.Width = GripSize;
				rect.X += MarginLeft;
			} else {
				rect.Height = GripSize;
				rect.Y += MarginLeft;
			}
			
			Gtk.Orientation or = Orientation == Gtk.Orientation.Horizontal ? Gtk.Orientation.Vertical : Gtk.Orientation.Horizontal;
			Gtk.Style.PaintHandle (this.Style, this.ParentWindow, this.State, Gtk.ShadowType.None, args.Area, this, "grip", rect.X, rect.Y, rect.Width, rect.Height, or);
			return true;
		}
	}
}
