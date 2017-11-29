using XNode;

namespace Dialogue {
	public abstract class DialogueBaseNode : Node {
		abstract public void Trigger();

		[System.Serializable] public class Connection { }
	}
}