
namespace Cage.Shell.Toolbars
{
	public interface IDockToolbar
	{
		string Id { get; }
		string Title { get; }
		bool Visible { get; set; }
	}
}
