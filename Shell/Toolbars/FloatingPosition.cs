
using System;
using Gtk;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	[XmlType ("floatingPosition")]
	public class FloatingPosition: DockToolbarPosition
	{
		Orientation orientation;
		int x;
		int y;
		
		public FloatingPosition ()
		{
		}
		
		internal FloatingPosition (DockToolbar bar)
		{
			orientation = bar.Orientation;
			bar.FloatingDock.GetPosition (out x, out y);
		}
		
		[XmlAttribute ("x")]
		public int X {
			get { return x; }
			set { x = value; }
		}
		
		[XmlAttribute ("y")]
		public int Y {
			get { return y; }
			set { y = value; }
		}
		
		[XmlAttribute ("orientation")]
		public Orientation Orientation {
			get { return orientation; }
			set { orientation = value; }
		}
		
		internal override void RestorePosition (DockToolbarFrame frame, DockToolbar bar)
		{
			frame.FloatBar (bar, orientation, x, y);
		}
	}
}
