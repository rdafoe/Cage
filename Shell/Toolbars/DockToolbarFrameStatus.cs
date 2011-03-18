
using System;
using System.Collections;
using System.Xml.Serialization;

namespace Cage.Shell.Toolbars
{
	public class DockToolbarFrameStatus
	{
		internal const int CurrentVersion = 2;
		
		[XmlElement ("version")]
		public int Version = 1;
		
		[XmlElement ("layout", typeof(DockToolbarFrameLayout))]
		public ArrayList Status = new ArrayList ();
	}
}
