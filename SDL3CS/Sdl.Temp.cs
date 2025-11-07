namespace SDL3CS;

// TODO
public static partial class Sdl
{
	public readonly struct IOStream { }

	public readonly record struct SensorID
	{
		public readonly uint Value;
	}

	public readonly record struct PenID
	{
		public readonly uint Value;
	}

	public readonly record struct JoystickID
	{
		public readonly uint Value;
	}

	public readonly record struct AudioDeviceID
	{
		public readonly uint Value;
	}

	public readonly record struct CameraID
	{
		public readonly uint Value;
	}

	public readonly record struct TouchID
	{
		public readonly ulong Value;
	}

	public readonly record struct FingerID
	{
		public readonly ulong Value;
	}

	public enum PenInputFlags : uint { }
	public enum BlendMode : uint { }
	public enum PenAxis { }
	public enum PowerState { }
}
