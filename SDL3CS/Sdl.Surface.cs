using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3CS;

public static partial class Sdl
{
	public enum ScaleMode
	{
		Invalid = -1,
		Nearest,
		Linear,
		Pixelart
	}

	public enum FlipMode
	{
		None = 1 << 0,
		Horizontal = 1 << 1,
		Vertical = 1 << 2,
		HorizontalAndVertical = Horizontal | Vertical
	}

	[Flags]
	public enum SurfaceFlags : uint
	{
		Preallocated = 0x00000001u,
		LockNeeded = 0x00000002u,
		Locked = 0x00000004u,
		SimdAligned = 0x00000008u,
	}

	public readonly struct Surface
	{
		public readonly SurfaceFlags Flags;
		public readonly PixelFormat Format;
		public readonly int Width;
		public readonly int Height;
		public readonly int Pitch;
		public readonly nint Pixels;

		// internal
		private readonly int refcount;
		private readonly nint reserved;
	};

	public static partial class Prop
	{
		public static partial class Surface
		{
			public const string SDRWhitePointFloat = "SDL.surface.SDR_white_point";
			public const string HDRHeadroomFloat = "SDL.surface.HDR_headroom";
			public const string TonemapOperatorString = "SDL.surface.tonemap";
			public const string HotspotXNumber = "SDL.surface.hotspot.x";
			public const string HotspotYNumber = "SDL.surface.hotspot.y";
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SurfaceMustLock(in Surface surface) => (surface.Flags & SurfaceFlags.LockNeeded) != 0;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SurfaceMustLock(Ptr<Surface> surface) => SurfaceMustLock(surface.Value);

	private static partial class Native
	{

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_CreateSurface(int width, int height, PixelFormat format);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_CreateSurfaceFrom(int width, int height, PixelFormat format, ReadOnlySpan<byte> pixels, int pitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_DestroySurface(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial PropertiesID SDL_GetSurfaceProperties(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceColorspace(in Surface surface, Colorspace colorspace);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Colorspace SDL_GetSurfaceColorspace(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Palette> SDL_CreateSurfacePalette(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfacePalette(in Surface surface, in Palette palette);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Palette> SDL_GetSurfacePalette(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_AddSurfaceAlternateImage(in Surface surface, in Surface image);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SurfaceHasAlternateImages(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public unsafe static partial Ptr<Surface>* SDL_GetSurfaceImages(in Surface surface, out int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_RemoveSurfaceAlternateImages(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_LockSurface(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_UnlockSurface(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_LoadBMP_IO(in IOStream src, [MarshalAs(UnmanagedType.I1)] bool closeio);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_LoadBMP(string file);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SaveBMP_IO(in Surface surface, in IOStream dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SaveBMP(in Surface surface, string file);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_LoadPNG_IO(in IOStream src, [MarshalAs(UnmanagedType.I1)] bool closeio);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_LoadPNG(string file);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SavePNG_IO(in Surface surface, in IOStream dst, [MarshalAs(UnmanagedType.I1)] bool closeio);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SavePNG(in Surface surface, string file);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceRLE(in Surface surface, [MarshalAs(UnmanagedType.I1)] bool enabled);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SurfaceHasRLE(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceColorKey(in Surface surface, [MarshalAs(UnmanagedType.I1)] bool enabled, uint key);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SurfaceHasColorKey(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetSurfaceColorKey(in Surface surface, out uint key);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceColorMod(in Surface surface, byte r, byte g, byte b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetSurfaceColorMod(in Surface surface, out byte r, out byte g, out byte b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceAlphaMod(in Surface surface, byte alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetSurfaceAlphaMod(in Surface surface, out byte alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceBlendMode(in Surface surface, BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetSurfaceBlendMode(in Surface surface, out BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetSurfaceClipRect(in Surface surface, in Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetSurfaceClipRect(in Surface surface, out Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_FlipSurface(in Surface surface, FlipMode flip);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_RotateSurface(in Surface surface, float angle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_DuplicateSurface(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_ScaleSurface(in Surface surface, int width, int height, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_ConvertSurface(in Surface surface, PixelFormat format);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_ConvertSurfaceAndColorspace(in Surface surface, PixelFormat format, in Palette palette, Colorspace colorspace, PropertiesID props);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ConvertPixels(int width, int height, PixelFormat srcFormat, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Span<byte> dst, int dstPitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ConvertPixelsAndColorspace(int width, int height, PixelFormat srcFormat, Colorspace srcColorspace, PropertiesID srcProperties, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Colorspace dstColorspace, PropertiesID dstProperties, Span<byte> dst, int dstPitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_PremultiplyAlpha(int width, int height, PixelFormat srcFormat, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Span<byte> dst, int dstPitch, [MarshalAs(UnmanagedType.I1)] bool linear);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_PremultiplySurfaceAlpha(in Surface surface, [MarshalAs(UnmanagedType.I1)] bool linear);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ClearSurface(in Surface surface, float r, float g, float b, float a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_FillSurfaceRect(in Surface dst, in Rect rect, uint color);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_FillSurfaceRects(in Surface dst, in Rect rects, int count, uint color);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurface(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurfaceUnchecked(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurfaceScaled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurfaceUncheckedScaled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_StretchSurface(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurfaceTiled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurfaceTiledWithScale(in Surface src, in Rect srcrect, float scale, ScaleMode scaleMode, in Surface dst, in Rect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_BlitSurface9Grid(in Surface src, in Rect srcrect, int leftWidth, int rightWidth, int topHeight, int bottomHeight, float scale, ScaleMode scaleMode, in Surface dst, in Rect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial uint SDL_MapSurfaceRGB(in Surface surface, byte r, byte g, byte b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial uint SDL_MapSurfaceRGBA(in Surface surface, byte r, byte g, byte b, byte a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ReadSurfacePixel(in Surface surface, int x, int y, out byte r, out byte g, out byte b, out byte a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ReadSurfacePixelFloat(in Surface surface, int x, int y, out float r, out float g, out float b, out float a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_WriteSurfacePixel(in Surface surface, int x, int y, byte r, byte g, byte b, byte a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_WriteSurfacePixelFloat(in Surface surface, int x, int y, float r, float g, float b, float a);
	}

	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> CreateSurface(int width, int height, PixelFormat format) => Native.SDL_CreateSurface(width, height, format);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> CreateSurfaceFrom(int width, int height, PixelFormat format, ReadOnlySpan<byte> pixels, int pitch) => Native.SDL_CreateSurfaceFrom(width, height, format, pixels, pitch);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DestroySurface(in Surface surface) => Native.SDL_DestroySurface(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static PropertiesID GetSurfaceProperties(in Surface surface) => Native.SDL_GetSurfaceProperties(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceColorspace(in Surface surface, Colorspace colorspace) => Native.SDL_SetSurfaceColorspace(surface, colorspace);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Colorspace GetSurfaceColorspace(in Surface surface) => Native.SDL_GetSurfaceColorspace(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Palette> CreateSurfacePalette(in Surface surface) => Native.SDL_CreateSurfacePalette(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfacePalette(in Surface surface, in Palette palette) => Native.SDL_SetSurfacePalette(surface, palette);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Palette> GetSurfacePalette(in Surface surface) => Native.SDL_GetSurfacePalette(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool AddSurfaceAlternateImage(in Surface surface, in Surface image) => Native.SDL_AddSurfaceAlternateImage(surface, image);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SurfaceHasAlternateImages(in Surface surface) => Native.SDL_SurfaceHasAlternateImages(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static OwnedArrayPtr<Ptr<Surface>> GetSurfaceImages(in Surface surface) => new(Native.SDL_GetSurfaceImages(surface, out var count), count);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void RemoveSurfaceAlternateImages(in Surface surface) => Native.SDL_RemoveSurfaceAlternateImages(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LockSurface(in Surface surface) => Native.SDL_LockSurface(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UnlockSurface(in Surface surface) => Native.SDL_UnlockSurface(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> LoadBMP_IO(in IOStream src, bool closeio) => Native.SDL_LoadBMP_IO(src, closeio);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> LoadBMP(string file) => Native.SDL_LoadBMP(file);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SaveBMP_IO(in Surface surface, in IOStream dst, bool closeio) => Native.SDL_SaveBMP_IO(surface, dst, closeio);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SaveBMP(in Surface surface, string file) => Native.SDL_SaveBMP(surface, file);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> LoadPNG_IO(in IOStream src, bool closeio) => Native.SDL_LoadPNG_IO(src, closeio);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> LoadPNG(string file) => Native.SDL_LoadPNG(file);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SavePNG_IO(in Surface surface, in IOStream dst, bool closeio) => Native.SDL_SavePNG_IO(surface, dst, closeio);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SavePNG(in Surface surface, string file) => Native.SDL_SavePNG(surface, file);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceRLE(in Surface surface, bool enabled) => Native.SDL_SetSurfaceRLE(surface, enabled);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SurfaceHasRLE(in Surface surface) => Native.SDL_SurfaceHasRLE(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceColorKey(in Surface surface, bool enabled, uint key) => Native.SDL_SetSurfaceColorKey(surface, enabled, key);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SurfaceHasColorKey(in Surface surface) => Native.SDL_SurfaceHasColorKey(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetSurfaceColorKey(in Surface surface, out uint key) => Native.SDL_GetSurfaceColorKey(surface, out key);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceColorMod(in Surface surface, byte r, byte g, byte b) => Native.SDL_SetSurfaceColorMod(surface, r, g, b);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetSurfaceColorMod(in Surface surface, out byte r, out byte g, out byte b) => Native.SDL_GetSurfaceColorMod(surface, out r, out g, out b);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceAlphaMod(in Surface surface, byte alpha) => Native.SDL_SetSurfaceAlphaMod(surface, alpha);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetSurfaceAlphaMod(in Surface surface, out byte alpha) => Native.SDL_GetSurfaceAlphaMod(surface, out alpha);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceBlendMode(in Surface surface, BlendMode blendMode) => Native.SDL_SetSurfaceBlendMode(surface, blendMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetSurfaceBlendMode(in Surface surface, out BlendMode blendMode) => Native.SDL_GetSurfaceBlendMode(surface, out blendMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetSurfaceClipRect(in Surface surface, in Rect rect) => Native.SDL_SetSurfaceClipRect(surface, rect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetSurfaceClipRect(in Surface surface, out Rect rect) => Native.SDL_GetSurfaceClipRect(surface, out rect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FlipSurface(in Surface surface, FlipMode flip) => Native.SDL_FlipSurface(surface, flip);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> RotateSurface(in Surface surface, float angle) => Native.SDL_RotateSurface(surface, angle);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> DuplicateSurface(in Surface surface) => Native.SDL_DuplicateSurface(surface);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> ScaleSurface(in Surface surface, int width, int height, ScaleMode scaleMode) => Native.SDL_ScaleSurface(surface, width, height, scaleMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> ConvertSurface(in Surface surface, PixelFormat format) => Native.SDL_ConvertSurface(surface, format);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> ConvertSurfaceAndColorspace(in Surface surface, PixelFormat format, in Palette palette, Colorspace colorspace, PropertiesID props) => Native.SDL_ConvertSurfaceAndColorspace(surface, format, palette, colorspace, props);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ConvertPixels(int width, int height, PixelFormat srcFormat, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Span<byte> dst, int dstPitch) => Native.SDL_ConvertPixels(width, height, srcFormat, src, srcPitch, dstFormat, dst, dstPitch);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ConvertPixelsAndColorspace(int width, int height, PixelFormat srcFormat, Colorspace srcColorspace, PropertiesID srcProperties, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Colorspace dstColorspace, PropertiesID dstProperties, Span<byte> dst, int dstPitch) => Native.SDL_ConvertPixelsAndColorspace(width, height, srcFormat, srcColorspace, srcProperties, src, srcPitch, dstFormat, dstColorspace, dstProperties, dst, dstPitch);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool PremultiplyAlpha(int width, int height, PixelFormat srcFormat, ReadOnlySpan<byte> src, int srcPitch, PixelFormat dstFormat, Span<byte> dst, int dstPitch, bool linear) => Native.SDL_PremultiplyAlpha(width, height, srcFormat, src, srcPitch, dstFormat, dst, dstPitch, linear);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool PremultiplySurfaceAlpha(in Surface surface, bool linear) => Native.SDL_PremultiplySurfaceAlpha(surface, linear);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ClearSurface(in Surface surface, float r, float g, float b, float a) => Native.SDL_ClearSurface(surface, r, g, b, a);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FillSurfaceRect(in Surface dst, in Rect rect, uint color) => Native.SDL_FillSurfaceRect(dst, rect, color);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FillSurfaceRects(in Surface dst, in Rect rects, int count, uint color) => Native.SDL_FillSurfaceRects(dst, rects, count, color);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurface(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect) => Native.SDL_BlitSurface(src, srcrect, dst, dstrect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurfaceUnchecked(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect) => Native.SDL_BlitSurfaceUnchecked(src, srcrect, dst, dstrect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurfaceScaled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode) => Native.SDL_BlitSurfaceScaled(src, srcrect, dst, dstrect, scaleMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurfaceUncheckedScaled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode) => Native.SDL_BlitSurfaceUncheckedScaled(src, srcrect, dst, dstrect, scaleMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool StretchSurface(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect, ScaleMode scaleMode) => Native.SDL_StretchSurface(src, srcrect, dst, dstrect, scaleMode);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurfaceTiled(in Surface src, in Rect srcrect, in Surface dst, in Rect dstrect) => Native.SDL_BlitSurfaceTiled(src, srcrect, dst, dstrect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurfaceTiledWithScale(in Surface src, in Rect srcrect, float scale, ScaleMode scaleMode, in Surface dst, in Rect dstrect) => Native.SDL_BlitSurfaceTiledWithScale(src, srcrect, scale, scaleMode, dst, dstrect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool BlitSurface9Grid(in Surface src, in Rect srcrect, int leftWidth, int rightWidth, int topHeight, int bottomHeight, float scale, ScaleMode scaleMode, in Surface dst, in Rect dstrect) => Native.SDL_BlitSurface9Grid(src, srcrect, leftWidth, rightWidth, topHeight, bottomHeight, scale, scaleMode, dst, dstrect);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint MapSurfaceRGB(in Surface surface, byte r, byte g, byte b) => Native.SDL_MapSurfaceRGB(surface, r, g, b);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint MapSurfaceRGBA(in Surface surface, byte r, byte g, byte b, byte a) => Native.SDL_MapSurfaceRGBA(surface, r, g, b, a);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ReadSurfacePixel(in Surface surface, int x, int y, out byte r, out byte g, out byte b, out byte a) => Native.SDL_ReadSurfacePixel(surface, x, y, out r, out g, out b, out a);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ReadSurfacePixelFloat(in Surface surface, int x, int y, out float r, out float g, out float b, out float a) => Native.SDL_ReadSurfacePixelFloat(surface, x, y, out r, out g, out b, out a);
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool WriteSurfacePixel(in Surface surface, int x, int y, byte r, byte g, byte b, byte a) => Native.SDL_WriteSurfacePixel(surface, x, y, r, g, b, a);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool WriteSurfacePixelFloat(in Surface surface, int x, int y, float r, float g, float b, float a) => Native.SDL_WriteSurfacePixelFloat(surface, x, y, r, g, b, a);
}
