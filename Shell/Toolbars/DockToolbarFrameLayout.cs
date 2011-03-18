
using System;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	public class DockToolbarFrameLayout
	{
		[XmlAttribute ("id")]
		public string Id;
		
		[XmlElement ("dockbar")]
		public DockToolbarStatus[] Bars;
	}
}
