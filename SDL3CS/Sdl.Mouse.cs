using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3CS;

public static partial class Sdl
{
	public enum SystemCursor
	{
		Default,
		Text,
		Wait,
		Crosshair,
		Progress,
		NWSEResize,
		NESWResize,
		HorizontalResize,
		VerticalResize,
		Move,
		NotAllowed,
		Pointer,
		NWResize,
		NResize,
		NEResize,
		EResize,
		SEResize,
		SResize,
		SWResize,
		WResize,
		COUNT
	}

	public enum MouseWheelDirection
	{
		Normal,
		Flipped
	}

	public enum MouseButton : byte
	{
		Left = 1,
		Middle = 2,
		Right = 3,
		X1 = 4,
		X2 = 5,
	}

	[Flags]
	public enum MouseButtonFlags : byte
	{
		Left = 1 << 0,
		Middle = 1 << 1,
		Right = 1 << 2,
		X1 = 1 << 3,
		X2 = 1 << 4,
	}

	public readonly record struct MouseID
	{
		public readonly uint Value;
	}

	public readonly struct Cursor { }

	public readonly struct CursorFrameInfo
	{
		public readonly Ptr<Surface> Surface;
		public readonly uint Duration;
	}

	public static uint DefineButtonMask(MouseButtonFlags button) => 1u << ((int)button - 1);
	public static readonly uint ButtonLeftMask = DefineButtonMask(MouseButtonFlags.Left);
	public static readonly uint ButtonMiddleMask = DefineButtonMask(MouseButtonFlags.Middle);
	public static readonly uint ButtonRightMask = DefineButtonMask(MouseButtonFlags.Right);
	public static readonly uint ButtonX1Mask = DefineButtonMask(MouseButtonFlags.X1);
	public static readonly uint ButtonX2Mask = DefineButtonMask(MouseButtonFlags.X2);

	public delegate void MouseMotionTransformCallback(nint userdata, ulong timestamp, in Window window, MouseID mouseID, in float x, in float y);

	private static partial class Native
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_HasMouse();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public unsafe static partial MouseID* SDL_GetMice(out int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial nint SDL_GetMouseNameForID(MouseID instanceId);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Window> SDL_GetMouseFocus();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial MouseButtonFlags SDL_GetMouseState(out float x, out float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial MouseButtonFlags SDL_GetGlobalMouseState(out float x, out float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial MouseButtonFlags SDL_GetRelativeMouseState(out float x, out float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_WarpMouseInWindow(in Window window, float x, float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_WarpMouseGlobal(float x, float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRelativeMouseTransform(MouseMotionTransformCallback callback, nint userdata);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetWindowRelativeMouseMode(in Window window, [MarshalAs(UnmanagedType.I1)] bool enabled);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetWindowRelativeMouseMode(in Window window);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_CaptureMouse([MarshalAs(UnmanagedType.I1)] bool enabled);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_CreateCursor(ReadOnlySpan<byte> data, ReadOnlySpan<byte> mask, int w, int h, int hotX, int hotY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_CreateColorCursor(in Surface surface, int hotX, int hotY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_CreateAnimatedCursor(in CursorFrameInfo frames, int frameCount, int hotX, int hotY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_CreateSystemCursor(SystemCursor id);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetCursor(in Cursor cursor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_GetCursor();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Cursor> SDL_GetDefaultCursor();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_DestroyCursor(in Cursor cursor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ShowCursor();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_HideCursor();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_CursorVisible();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasMouse() => Native.SDL_HasMouse();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static OwnedArrayPtr<MouseID> GetMice() => new(Native.SDL_GetMice(out var count), count);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string? GetMouseNameForID(MouseID instanceId) => Marshal.PtrToStringUTF8(Native.SDL_GetMouseNameForID(instanceId));
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Window> GetMouseFocus() => Native.SDL_GetMouseFocus();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static MouseButtonFlags GetMouseState(out float x, out float y) => Native.SDL_GetMouseState(out x, out y);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static MouseButtonFlags GetGlobalMouseState(out float x, out float y) => Native.SDL_GetGlobalMouseState(out x, out y);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static MouseButtonFlags GetRelativeMouseState(out float x, out float y) => Native.SDL_GetRelativeMouseState(out x, out y);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WarpMouseInWindow(in Window window, float x, float y) => Native.SDL_WarpMouseInWindow(window, x, y);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool WarpMouseGlobal(float x, float y) => Native.SDL_WarpMouseGlobal(x, y);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRelativeMouseTransform(MouseMotionTransformCallback callback, nint userdata) => Native.SDL_SetRelativeMouseTransform(callback, userdata);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetWindowRelativeMouseMode(in Window window, bool enabled) => Native.SDL_SetWindowRelativeMouseMode(window, enabled);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetWindowRelativeMouseMode(in Window window) => Native.SDL_GetWindowRelativeMouseMode(window);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool CaptureMouse(bool enabled) => Native.SDL_CaptureMouse(enabled);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> CreateCursor(ReadOnlySpan<byte> data, ReadOnlySpan<byte> mask, int w, int h, int hotX, int hotY) => Native.SDL_CreateCursor(data, mask, w, h, hotX, hotY);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> CreateColorCursor(in Surface surface, int hotX, int hotY) => Native.SDL_CreateColorCursor(surface, hotX, hotY);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> CreateAnimatedCursor(in CursorFrameInfo frames, int frameCount, int hotX, int hotY) => Native.SDL_CreateAnimatedCursor(frames, frameCount, hotX, hotY);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> CreateSystemCursor(SystemCursor id) => Native.SDL_CreateSystemCursor(id);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetCursor(in Cursor cursor) => Native.SDL_SetCursor(cursor);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> GetCursor() => Native.SDL_GetCursor();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Cursor> GetDefaultCursor() => Native.SDL_GetDefaultCursor();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DestroyCursor(in Cursor cursor) => Native.SDL_DestroyCursor(cursor);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ShowCursor() => Native.SDL_ShowCursor();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HideCursor() => Native.SDL_HideCursor();
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool CursorVisible() => Native.SDL_CursorVisible();
}

