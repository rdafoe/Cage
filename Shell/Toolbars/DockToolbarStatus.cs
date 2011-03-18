
using System;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	[XmlType ("dockBar")]
	public class DockToolbarStatus
	{
		bool visible;
		DockToolbarPosition position;
		string id;
		
		public DockToolbarStatus ()
		{
		}
		
		public DockToolbarStatus (string id, bool visible, DockToolbarPosition position)
		{
			this.visible = visible;
			this.position = position;
			this.id = id;
		}
		
		[XmlAttribute ("id")]
		public string BarId {
			get { return id; }
			set { id = value; }
		}

		[XmlElement ("visible")]
		public bool Visible {
			get { return visible; }
			set { visible = value; }
		}
		
		[XmlElement ("dockedPosition", typeof(DockedPosition))]
		[XmlElement ("floatingPosition", typeof(FloatingPosition))]
		public DockToolbarPosition Position {
			get { return position; }
			set { position = value; }
		}
	}
}
