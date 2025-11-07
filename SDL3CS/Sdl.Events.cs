using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static SDL3CS.Sdl;

namespace SDL3CS;

public static partial class Sdl
{
	public enum EventType
	{
		First = 0,

		Quit = 0x100,
		Terminating,
		LowMemory,
		WillEnterBackground,
		DidEnterBackground,
		WillEnterForeground,
		DidEnterForeground,
		LocalChanged,
		SystemThemeChanged,

		DisplayOrientation = 0x151,
		DisplayAdded,
		DisplayRemoved,
		DisplayMoved,
		DisplayDesktopModeChanged,
		DisplayCurrentModeChanged,
		DisplayContentScaleChanged,
		DisplayUsableBoundsChanged,
		DisplayFirst = DisplayOrientation,
		DisplayLast = DisplayUsableBoundsChanged,

		WindowShown = 0x202,
		WindowHidden,
		WindowExposed,
		WindowMoved,
		WindowResized,
		WindowPixelSizeChanged,
		WindowMetalViewResized,
		WindowMinimized,
		WindowMaximized,
		WindowRestored,
		WindowMouseEnter,
		WindowMouseLeave,
		WindowFocusGained,
		WindowFocusLost,
		WindowCloseRequested,
		WindowHitTest,
		WindowIccProfChanged,
		WindowDisplayChanged,
		WindowDisplayScaleChanged,
		WindowSafeAreaChanged,
		WindowOccluded,
		WindowEnterFullscreen,
		WindowLeaveFullscreen,
		WindowDestroyed,
		WindowHdrStateChanged,
		WindowFirst = WindowShown,
		WindowLast = WindowHdrStateChanged,

		KeyDown = 0x300,
		KeyUp,
		TextEditing,
		TextInput,
		KeymapChanged,
		KeyboardAdded,
		KeyboardRemoved,
		TextEditingCandidates,
		ScreenKeyboardShown,
		ScreenKeyboardHidden,

		MouseMotion = 0x400,
		MouseButtonDown,
		MouseButtonUp,
		MouseWheel,
		MouseAdded,
		MouseRemoved,

		JoystickAxisMotion = 0x600,
		JoystickBallMotion,
		JoystickHatMotion,
		JoystickButtonDown,
		JoystickButtonUp,
		JoystickAdded,
		JoystickRemoved,
		JoystickBatteryUpdated,
		JoystickUpdateComplete,

		GamepadAxisMotion = 0x650,
		GamepadButtonDown,
		GamepadButtonUp,
		GamepadAdded,
		GamepadRemoved,
		GamepadRemapped,
		GamepadTouchpadDown,
		GamepadTouchpadMotion,
		GamepadTouchpadUp,
		GamepadSensorUpdate,
		GamepadUpdateComplete,
		GamepadSteamHandleUpdated,

		FingerDown = 0x700,
		FingerUp,
		FingerMotion,
		FingerCanceled,

		PinchBegin = 0x710,
		PinchUpdate,
		PinchEnd,

		ClipboardPaste = 0x900,

		DropFile = 0x1000,
		DropText,
		DropBegin,
		DropComplete,
		DropPosition,

		AudioDeviceAdded = 0x1100,
		AudioDeviceRemoved,
		AudioDeviceFormatChanged,

		SensorUpdate = 0x1200,

		PenProximityIn = 0x1300,
		PenProximityOut,
		PenDown,
		PenUp,
		PenButtonDown,
		PenButtonUp,
		PenMotion,
		PenAxis,

		CameraDeviceAdded = 0x1400,
		CameraDeviceRemoved,
		CameraDeviceApproved,
		CameraDeviceDenied,

		RenderTargetsReset = 0x2000,
		RenderDeviceReset,
		RenderDeviceLost,

		Private0 = 0x4000,
		Private1,
		Private2,
		Private3,

		PollSentinel = 0x7F00,
		User = 0x8000,
		Last = 0xFFFF,
		EnumPadding = 0x7FFFFFFF

	}

	public enum EventAction
	{
		AddEvent,
		PeekEvent,
		GetEvent
	}

	[StructLayout(LayoutKind.Explicit)]
	public readonly struct CommonEvent
	{
		[FieldOffset(0)]
		public readonly EventType Type;

		[FieldOffset(0)]
		public readonly uint UserType;

		[FieldOffset(4)]
		private readonly uint reserved_;

		[FieldOffset(8)]
		public readonly ulong Timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct DisplayEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly DisplayID DisplayID;
		public readonly int Data1;
		public readonly int Data2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WindowEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly int Data1;
		public readonly int Data2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct KeyboardDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly KeyboardID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct KeyboardEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly KeyboardID Which;
		public readonly Scancode Scancode;
		public readonly Keycode Key;
		public readonly Keymod Mod;
		public readonly ushort Raw;
		private readonly byte down_;
		private readonly byte repeat_;

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}

		public readonly bool Repeat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => repeat_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextEditingEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		private readonly Ptr<byte> text_;
		public readonly int Start;
		public readonly int Length;

		public readonly string? Text
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Marshal.PtrToStringUTF8(text_.Value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextEditingCandidatesEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		private unsafe readonly Ptr<byte>* candidates_;
		private readonly int numCandidates_;
		public readonly int SelectedCandidate;
		private readonly byte horizontal_;
		private readonly byte padding1;
		private readonly byte padding2;
		private readonly byte padding3;

		public unsafe readonly ReadOnlySpan<Ptr<byte>> Candidates
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => new(candidates_, numCandidates_);
		}

		public readonly bool Horizontal
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => horizontal_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextInputEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		private readonly Ptr<byte> text_;

		public readonly string? Text
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Marshal.PtrToStringUTF8(text_.Value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MouseDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly MouseID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MouseMotionEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly MouseID Which;
		public readonly MouseButtonFlags State;
		public readonly float X;
		public readonly float Y;
		public readonly float XRel;
		public readonly float YRel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MouseButtonEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly MouseID Which;
		public readonly MouseButton Button;
		private readonly byte down_;
		public readonly byte Clicks;
		private readonly byte padding_;
		public readonly float X;
		public readonly float Y;

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MouseWheelEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID windowID;
		public readonly MouseID which;
		public readonly float X;
		public readonly float Y;
		public readonly MouseWheelDirection Direction;
		public readonly float MouseX;
		public readonly float MouseY;
		public readonly int IntegerX;
		public readonly int IntegerY;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyAxisEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly byte Axis;
		private readonly byte padding1_;
		private readonly byte padding2_;
		private readonly byte padding3_;
		public readonly short Value;
		private readonly ushort padding4_;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyBallEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly byte Ball;
		private readonly byte padding1_;
		private readonly byte padding2_;
		private readonly byte padding3_;
		public readonly short XRel;
		public readonly short YRel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyHatEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID which;
		public readonly byte Hat;
		public readonly byte Value;
		private readonly byte padding1_;
		private readonly byte padding2_;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyButtonEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly byte Button;
		private readonly byte down_;
		private readonly byte padding1_;
		private readonly byte padding2_;

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct JoyBatteryEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly PowerState State;
		public readonly int Percent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GamepadAxisEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly byte Axis;
		private readonly byte padding1_;
		private readonly byte padding2_;
		private readonly byte padding3_;
		public readonly short Value;
		private readonly ushort padding4_;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GamepadButtonEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly byte Button;
		private readonly byte down_;
		private readonly byte padding1_;
		private readonly byte padding2_;

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GamepadDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GamepadTouchpadEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly int Touchpad;
		public readonly int Finger;
		public readonly float X;
		public readonly float Y;
		public readonly float Pressure;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct GamepadSensorEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly JoystickID Which;
		public readonly int Sensor;
		private unsafe fixed float data_[3];
		public readonly ulong SensorTimestamp;

		public unsafe readonly ReadOnlySpan<float> DataSpan
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				fixed (float* ptr = data_)
					return new ReadOnlySpan<float>(ptr, 3);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct AudioDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly AudioDeviceID Which;
		private readonly byte recording_;
		private readonly byte padding1_;
		private readonly byte padding2_;
		private readonly byte padding3_;

		public readonly bool Recording
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => recording_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct CameraDeviceEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly CameraID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TouchFingerEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly TouchID TouchID;
		public readonly FingerID FingerID;
		public readonly float X;
		public readonly float Y;
		public readonly float DeltaX;
		public readonly float DeltaY;
		public readonly float Pressure;
		public readonly WindowID WindowID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PinchFingerEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly float Scale;
		public readonly WindowID WindowID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PenProximityEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly PenID Which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PenMotionEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly PenID Which;
		public readonly PenInputFlags PenState;
		public readonly float X;
		public readonly float Y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PenTouchEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly PenID Which;
		public readonly PenInputFlags PenState;
		public readonly float X;
		public readonly float Y;
		private readonly byte eraser_;
		private readonly byte down_;

		public readonly bool Eraser
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => eraser_ != 0;
		}

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PenButtonEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly PenID Which;
		public readonly PenInputFlags PenState;
		public readonly float X;
		public readonly float Y;
		public readonly byte Button;
		private readonly byte down_;

		public readonly bool Down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => down_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PenAxisEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly PenID Which;
		public readonly PenInputFlags PenState;
		public readonly float X;
		public readonly float Y;
		public readonly PenAxis Axis;
		public readonly float Value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct DropEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly float X;
		public readonly float Y;
		private readonly Ptr<byte> source_;
		private readonly Ptr<byte> data_;

		public readonly string? Source
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Marshal.PtrToStringUTF8(source_.Value);
		}

		public readonly string? Data
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Marshal.PtrToStringUTF8(data_.Value);
		}

	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct ClipboardEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		private readonly byte owner_;
		private readonly int numMimeTypes_;
		private unsafe readonly Ptr<byte>* mimeTypes_;

		public unsafe readonly ReadOnlySpan<Ptr<byte>> MimeTypes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => new(mimeTypes_, numMimeTypes_);
		}

		public readonly bool Owner
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => owner_ != 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SensorEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly SensorID Which;
		public unsafe fixed float Data[6];
		public readonly ulong SensorTimestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct QuitEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct UserEvent
	{
		private readonly EventType type_;
		private readonly uint reserved_;
		private readonly ulong timestamp_;
		public readonly WindowID WindowID;
		public readonly int Code;
		public readonly nint Data1;
		public readonly nint Data2;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct Event
	{
		[FieldOffset(0)] public readonly EventType Type;
		[FieldOffset(0)] public readonly uint UserType;
		[FieldOffset(8)] public readonly ulong Timestamp;
		[FieldOffset(0)] public readonly CommonEvent Common;
		[FieldOffset(0)] public readonly DisplayEvent Display;
		[FieldOffset(0)] public readonly WindowEvent Window;
		[FieldOffset(0)] public readonly KeyboardDeviceEvent KeyboardDevice;
		[FieldOffset(0)] public readonly KeyboardEvent Key;
		[FieldOffset(0)] public readonly TextEditingEvent Êdit;
		[FieldOffset(0)] public readonly TextEditingCandidatesEvent EditCandidates;
		[FieldOffset(0)] public readonly TextInputEvent Text;
		[FieldOffset(0)] public readonly MouseDeviceEvent MouseDevice;
		[FieldOffset(0)] public readonly MouseMotionEvent MouseMotion;
		[FieldOffset(0)] public readonly MouseButtonEvent MouseButton;
		[FieldOffset(0)] public readonly MouseWheelEvent MouseWheel;
		[FieldOffset(0)] public readonly JoyDeviceEvent JoyDevice;
		[FieldOffset(0)] public readonly JoyAxisEvent JoyAxis;
		[FieldOffset(0)] public readonly JoyBallEvent JoyBall;
		[FieldOffset(0)] public readonly JoyHatEvent JoyHat;
		[FieldOffset(0)] public readonly JoyButtonEvent JoyButton;
		[FieldOffset(0)] public readonly JoyBatteryEvent JoyBattery;
		[FieldOffset(0)] public readonly GamepadDeviceEvent GamepadDevice;
		[FieldOffset(0)] public readonly GamepadAxisEvent GamepadAxis;
		[FieldOffset(0)] public readonly GamepadButtonEvent GamepadButton;
		[FieldOffset(0)] public readonly GamepadTouchpadEvent GamepadTouchpad;
		[FieldOffset(0)] public readonly GamepadSensorEvent GamepadSensor;
		[FieldOffset(0)] public readonly AudioDeviceEvent AudioDevice;
		[FieldOffset(0)] public readonly CameraDeviceEvent CameraDevice;
		[FieldOffset(0)] public readonly SensorEvent Sensor;
		[FieldOffset(0)] public readonly QuitEvent Quit;
		[FieldOffset(0)] public readonly UserEvent User;
		[FieldOffset(0)] public readonly TouchFingerEvent TouchFinger;
		[FieldOffset(0)] public readonly PinchFingerEvent PinchFinger;
		[FieldOffset(0)] public readonly PenProximityEvent PenProximity;
		[FieldOffset(0)] public readonly PenTouchEvent PenTouch;
		[FieldOffset(0)] public readonly PenMotionEvent PenMotion;
		[FieldOffset(0)] public readonly PenButtonEvent PenButton;
		[FieldOffset(0)] public readonly PenAxisEvent PenAxis;
		[FieldOffset(0)] public readonly RenderEvent Render;
		[FieldOffset(0)] public readonly DropEvent Drop;
		[FieldOffset(0)] public readonly ClipboardEvent Clipboard;
		[FieldOffset(0)] private unsafe fixed byte padding_[128];
	}

	public delegate bool EventFilter(nint userdata, in Event @event);

	private static partial class Native
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_PumpEvents();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public unsafe static partial int SDL_PeepEvents(Event* events, int numevents, EventAction action, uint minType, uint maxType);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_HasEvent(uint type);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_HasEvents(uint minType, uint maxType);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_FlushEvent(uint type);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_FlushEvents(uint minType, uint maxType);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_PollEvent(out Event @event);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_WaitEvent(out Event @event);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_WaitEventTimeout(out Event @event, int timeoutMs);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_PushEvent(in Event @event);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_SetEventFilter(EventFilter filter, nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetEventFilter(out EventFilter filter, out nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_AddEventWatch(EventFilter filter, nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_RemoveEventWatch(EventFilter filter, nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_FilterEvents(EventFilter filter, nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_SetEventEnabled(uint type, [MarshalAs(UnmanagedType.I1)] bool enabled);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_EventEnabled(uint type);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial uint SDL_RegisterEvents(int numevents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Window> SDL_GetWindowFromEvent(in Event @event);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public unsafe static partial int SDL_GetEventDescription(in Event @event, byte* buf, int buflen);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void PumpEvents() => Native.SDL_PumpEvents();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int PeepEvents(Span<Event> events, EventAction action, uint minType, uint maxType)
	{
		fixed (Event* eventsPtr = events)
			return Native.SDL_PeepEvents(eventsPtr, events.Length, action, minType, maxType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasEvent(uint type) => Native.SDL_HasEvent(type);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasEvent(EventType type) => Native.SDL_HasEvent((uint)type);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasEvents(uint minType, uint maxType) => Native.SDL_HasEvents(minType, maxType);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void FlushEvent(uint type) => Native.SDL_FlushEvent(type);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void FlushEvent(EventType type) => Native.SDL_FlushEvent((uint)type);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void FlushEvents(uint minType, uint maxType) => Native.SDL_FlushEvents(minType, maxType);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool PollEvent(out Event @event) => Native.SDL_PollEvent(out @event);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool WaitEvent(out Event @event) => Native.SDL_WaitEvent(out @event);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool WaitEventTimeout(out Event @event, int timeoutMs) => Native.SDL_WaitEventTimeout(out @event, timeoutMs);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool PushEvent(in Event @event) => Native.SDL_PushEvent(@event);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetEventFilter(EventFilter filter, nint userdata) => Native.SDL_SetEventFilter(filter, userdata);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetEventFilter(out EventFilter filter, out nint userdata) => Native.SDL_GetEventFilter(out filter, out userdata);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool AddEventWatch(EventFilter filter, nint userdata) => Native.SDL_AddEventWatch(filter, userdata);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void RemoveEventWatch(EventFilter filter, nint userdata) => Native.SDL_RemoveEventWatch(filter, userdata);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void FilterEvents(EventFilter filter, nint userdata) => Native.SDL_FilterEvents(filter, userdata);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetEventEnabled(uint type, bool enabled) => Native.SDL_SetEventEnabled(type, enabled);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool EventEnabled(uint type) => Native.SDL_EventEnabled(type);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint RegisterEvents(int numevents) => Native.SDL_RegisterEvents(numevents);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Window> GetWindowFromEvent(in Event @event) => Native.SDL_GetWindowFromEvent(@event);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetEventDescription(in Event @event, out string description)
	{
		Span<byte> buffer = stackalloc byte[256];
		fixed (byte* bufferPtr = buffer)
		{
			var ret = Native.SDL_GetEventDescription(@event, bufferPtr, 256);
			description = Marshal.PtrToStringUTF8((nint)bufferPtr) ?? string.Empty;
			return ret;
		}
	}
}
