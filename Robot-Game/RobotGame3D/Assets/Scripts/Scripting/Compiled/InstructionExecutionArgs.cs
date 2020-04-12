using Assets.Scripts.Robot;

namespace Assets.Scripts.Scripting.Compiled {
	public struct InstructionExecutionArgs {
		public RobotBase Robot { get; set; }
		public InstructionController Controller { get; set; }
	}
}