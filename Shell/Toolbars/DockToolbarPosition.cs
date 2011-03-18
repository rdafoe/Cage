
using System;
using Gtk;
using Gdk;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	[XmlInclude (typeof(DockedPosition))]
	[XmlInclude (typeof(FloatingPosition))]
	public class DockToolbarPosition
	{
		internal virtual void RestorePosition (DockToolbarFrame frame, DockToolbar bar) {}
		
		internal static DockToolbarPosition Create (DockToolbar bar)
		{
			if (bar.Floating)
				return new FloatingPosition (bar);
			else
				return new DockedPosition (bar);
		} 
	}
}
