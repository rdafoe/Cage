
using System;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	[XmlType ("dockedPosition")]
	public class DockedPosition: DockToolbarPosition
	{
		Placement placement;
		int dockOffset;
		int dockRow;
		
		public DockedPosition ()
		{
		}
		
		internal DockedPosition (DockToolbar bar)
		{
			dockOffset = bar.AnchorOffset;
			dockRow = bar.DockRow;
			placement = ((DockToolbarPanel)bar.Parent).Placement;
		}
		
		internal DockedPosition (Placement placement)
		{
			this.placement = placement;
			dockRow = -1;
		}
		
		[XmlAttribute ("offset")]
		public int DockOffset {
			get { return dockOffset; }
			set { dockOffset = value; }
		}
		
		[XmlAttribute ("row")]
		public int DockRow {
			get { return dockRow; }
			set { dockRow = value; }
		}
		
		[XmlAttribute ("placement")]
		public Placement Placement {
			get { return placement; }
			set { placement = value; }
		}
		
		internal override void RestorePosition (DockToolbarFrame frame, DockToolbar bar)
		{
			frame.DockToolbar (bar, placement, dockOffset, dockRow);
		}
	}
}
