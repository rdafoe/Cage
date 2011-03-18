using System;
using System.IO;
using Gtk;
using Cage.Shell.Docking;
using Cage.Shell.Toolbars;

public partial class MainWindow : Gtk.Window
{
	Gtk.Container rootWidget;
	DockToolbarFrame toolbarFrame;
	DockFrame dock;
	DragNotebook tabControl;
	Gtk.MenuBar topMenu;
	Gtk.Statusbar statusBar;
	Gtk.VBox fullViewVBox;
	DockItem documentDockItem;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		SetSizeRequest( 800, 600 );
			
		CreateComponents();
	}
	
	void CreateMenuBar ()
	{
		topMenu = new Gtk.MenuBar();
		Menu fileMenu = new Menu();
		MenuItem file = new MenuItem("File");
		file.Submenu = fileMenu;			
		
		AccelGroup agr = new AccelGroup();
		AddAccelGroup(agr);
		
		ImageMenuItem exit = new ImageMenuItem(Stock.Quit, agr);
		exit.AddAccelerator("activate", agr, new AccelKey(Gdk.Key.q, Gdk.ModifierType.ControlMask, AccelFlags.Visible));
		exit.Activated += onButtonPressEvent;
		fileMenu.Append(exit);
		
		topMenu.Append(file);
		
		((VBox)fullViewVBox).PackStart (topMenu, false, false, 0);
			((Gtk.Box.BoxChild) fullViewVBox [topMenu]).Position = 0;
			topMenu.ShowAll ();
	}
	
	void DestroyMenuBar ()
	{
		if (topMenu == null)
			return;
		
		rootWidget.Remove (topMenu);
		topMenu = null;
	}
	
	void CreateToolBar()
	{
		toolbarFrame = new DockToolbarFrame();
		((VBox)rootWidget).PackStart (toolbarFrame, true, true, 0);
			
		DockToolbar tb1 = new DockToolbar("MyToolbar","The Toolbar");		
		tb1.ToolbarStyle = ToolbarStyle.Icons;
		ToolButton b = new ToolButton("gtk-quit");
		b.Clicked += onButtonPressEvent;
		tb1.Add(b);
		tb1.ShowAll();
		tb1.IconSize =Gtk.IconSize.SmallToolbar;
		toolbarFrame.AddBar(tb1);		
	}
		
	void CreateComponents ()
	{
		fullViewVBox = new VBox (false, 0);
		rootWidget = fullViewVBox;
		
		CreateMenuBar ();
		
		CreateToolBar();
		
		// Create the docking widget and add it to the window.
		dock = new DockFrame ();
		dock.Homogeneous = false;
		dock.DefaultItemHeight = 100;
		dock.DefaultItemWidth = 100;
		//dock.CompactGuiLevel = 1;
	
		toolbarFrame.AddContent (dock);
		
		// Create the notebook for the various documents.
		tabControl = new DragNotebook (); //(dock.ShadedContainer);
		tabControl.Scrollable = true;
		tabControl.AppendPage( new Label( "Other page" ), new Label( "Favorite Page  " ) );
		tabControl.AppendPage( new Label( "What page" ), new Label( "Welcome/Start Page  " ) );
		tabControl.AppendPage( new TextView(), new Image( "gtk-new", IconSize.Menu ) );
		tabControl.ShowAll();

		// The main document area
		documentDockItem = dock.AddItem ("Documents");
		documentDockItem.Behavior = DockItemBehavior.Locked;
		documentDockItem.Status = DockItemStatus.AutoHide;
		documentDockItem.DefaultHeight = 100;
		documentDockItem.DefaultWidth = 100;
		documentDockItem.DefaultStatus = DockItemStatus.AutoHide;
		documentDockItem.DefaultLocation = "Document/Right";
		documentDockItem.Expand = true;
		documentDockItem.DrawFrame = true;
		documentDockItem.Label = "Documents";
		documentDockItem.Content = tabControl;
		documentDockItem.DefaultVisible = true;
		documentDockItem.Visible = true;
				
		
		DockItem dit = dock.AddItem ("left");
		dit.Status = DockItemStatus.AutoHide;
		dit.DefaultHeight = 100;
		dit.DefaultWidth = 100;
		dit.DefaultStatus = DockItemStatus.AutoHide;
		dit.DefaultLocation = "left";
		dit.Behavior = DockItemBehavior.Normal;
		dit.Label = "Left";
		dit.DefaultVisible = true;
		dit.Visible = true;
		DockItemToolbar tb = dit.GetToolbar(PositionType.Top);
		ToolButton b = new ToolButton(null,"Hello");
		tb.Add(b,false);
	    tb.Visible = true;
		tb.ShowAll();
		
		dit = dock.AddItem ("right");
		dit.Status = DockItemStatus.AutoHide;
		dit.DefaultHeight = 100;
		dit.DefaultWidth = 100;
		dit.DefaultStatus = DockItemStatus.AutoHide;
		dit.DefaultLocation = "Documents/Right";
		dit.Behavior = DockItemBehavior.Normal;
		dit.Label = "Right";
		dit.DefaultVisible = true;
		dit.Visible = true;
		//dit.Icon = Gdk.Pixbuf.LoadFromResource("Cage.Shell.Docking.stock-close-12.png");
		
		dit = dock.AddItem ("top");
		dit.Status = DockItemStatus.AutoHide;
		dit.DefaultHeight = 100;
		dit.DefaultWidth = 100;
		dit.DefaultStatus = DockItemStatus.AutoHide;
		dit.DefaultLocation = "Documents/Top";
		dit.Behavior = DockItemBehavior.Normal;
		dit.Label = "Top";
		dit.DefaultVisible = true;
		dit.Visible = true;
		
		dit = dock.AddItem ("bottom");
		dit.Status = DockItemStatus.AutoHide;
		dit.DefaultHeight = 100;
		dit.DefaultWidth = 100;
		dit.DefaultStatus = DockItemStatus.AutoHide;
		dit.DefaultLocation = "Documents/Bottom";
		dit.Behavior = DockItemBehavior.Normal;
		dit.Label = "Bottom";
		dit.DefaultVisible = true;
		dit.Visible = true;
		
		
		
		if ( File.Exists( "toolbar.status" ) )
		{
			toolbarFrame.LoadStatus("toolbar.status");
		}

		if ( File.Exists( "config.layout" ) )
		{
			dock.LoadLayouts( "config.layout" );
		}
		else
		{
			dock.CreateLayout( "test", true );
		}
		
		
		dock.CurrentLayout = "test";
		dock.HandlePadding = 0;
		dock.HandleSize = 10;
	
		dock.SaveLayouts( "config.layout" );
		toolbarFrame.SaveStatus("toolbar.status");
		
		Add (fullViewVBox);
		fullViewVBox.ShowAll ();
		
		statusBar = new Gtk.Statusbar();
		fullViewVBox.PackEnd (statusBar, false, true, 0);			
	}	
	
	public void onButtonPressEvent( object sender, EventArgs args )
	{
		dock.SaveLayouts( "config.layout" );
		toolbarFrame.SaveStatus("toolbar.status");
		Gtk.Application.Quit();
	}	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dock.SaveLayouts( "config.layout" );
		toolbarFrame.SaveStatus("toolbar.status");
		Application.Quit ();
		a.RetVal = true;
	}
}

