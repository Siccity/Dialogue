using XNode;

namespace Dialogue {
	public abstract class DialogueBaseNode : Node {
		[Input(backingValue = ShowBackingValue.Never, typeConstraint = TypeConstraint.Inherited)] public DialogueBaseNode input;
		[Output(backingValue = ShowBackingValue.Never)] public DialogueBaseNode output;

		abstract public void Trigger();

		public override object GetValue(NodePort port) {
			return null;
		}
	}
}