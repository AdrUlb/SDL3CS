using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3CS;

public static partial class Sdl
{
	public const string LibraryName = "SDL3";

	private sealed class SdlFreeHandle : SafeHandle
	{
		public SdlFreeHandle(nint handle) : base(0, true)
		{
			SetHandle(handle);
		}

		public override bool IsInvalid => handle == 0;

		protected override bool ReleaseHandle()
		{
			if (IsInvalid)
				return false;

			Native.SDL_free(handle);
			SetHandle(0);
			return true;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe readonly struct Ptr<T> where T : unmanaged
	{
		private readonly T* ptr_;

		public bool IsNull
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => ptr_ == null;
		}

		public ref T Value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (IsNull)
					throw new NullReferenceException();
				return ref *ptr_;
			}
		}
	}

	private unsafe readonly struct ArrayPtr<T>(T* ptr, int count) where T : unmanaged
	{
		public bool IsNull
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => ptr == null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<T> AsSpan() => IsNull ? throw new NullReferenceException() : new(ptr, count);
	}

	public unsafe readonly struct OwnedArrayPtr<T>(T* ptr, int count) : IDisposable where T : unmanaged
	{
		private readonly ArrayPtr<T> array_ = new(ptr, count);
		private readonly SdlFreeHandle handle_ = new((nint)ptr);
		public int Count => count;

		public bool IsNull
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => array_.IsNull;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T* AsPointer() => ptr;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<T> AsSpan() => array_.AsSpan();

		public void Dispose() => handle_.Dispose();
	}
}
