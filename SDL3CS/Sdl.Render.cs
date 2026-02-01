using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3CS;

public static partial class Sdl
{
	public const int RendererVsyncDisabled = 0;
	public const int RendererVsyncAdaptive = -1;
	public const int DebugTextFontCharacterSize = 8;

	public const string SoftwareRenderer = "software";
	public const string GpuRenderer = "gpu";

	public struct Vertex
	{
		public FPoint Position;
		public FColor Color;
		public FPoint TexCoord;
	}

	public enum TextureAccess
	{
		Static,
		Streaming,
		Target
	}

	public enum TextureAddressMode
	{
		Invalid = -1,
		Auto,
		Clamp,
		Wrap
	}

	public enum RendererLogicalPresentation
	{
		Disabled,
		Stretch,
		Letterbox,
		Overscan,
		IntegerScale
	}

	public struct GpuRenderStateCreateInfo
	{
		public Ptr<GpuShader> FragmentShader;
		public int NumSamplerBindings;
		public Ptr<GpuTextureSamplerBinding> SamplerBindings;
		public int NumStorageTextures;
		public Ptr<Ptr<GpuTexture>> StorageTextures;
		public int NumStorageBuffers;
		public Ptr<Ptr<GpuBuffer>> StorageBuffers;
		public PropertiesID Props;
	}

	public readonly struct GpuRenderState
	{
	}

	public readonly struct Renderer
	{
	}

	public readonly struct Texture
	{
		public readonly PixelFormat Format;
		public readonly int Width;
		public readonly int Height;
		public readonly int Refcount;
	}

	public static partial class Prop
	{
		public static partial class Renderer
		{
			public const string NameString = "SDL.renderer.name";
			public const string WindowPointer = "SDL.renderer.window";
			public const string SurfacePointer = "SDL.renderer.surface";
			public const string VsyncNumber = "SDL.renderer.vsync";
			public const string MaxTextureSizeNumber = "SDL.renderer.max_texture_size";
			public const string TextureFormatsPointer = "SDL.renderer.texture_formats";
			public const string TextureWrappingBoolean = "SDL.renderer.texture_wrapping";
			public const string OutputColorspaceNumber = "SDL.renderer.output_colorspace";
			public const string HdrEnabledBoolean = "SDL.renderer.HDR_enabled";
			public const string SdrWhitePointFloat = "SDL.renderer.SDR_white_point";
			public const string HdrHeadroomFloat = "SDL.renderer.HDR_headroom";
			public const string D3D9DevicePointer = "SDL.renderer.d3d9.device";
			public const string D3D11DevicePointer = "SDL.renderer.d3d11.device";
			public const string D3D11SwapchainPointer = "SDL.renderer.d3d11.swap_chain";
			public const string D3D12DevicePointer = "SDL.renderer.d3d12.device";
			public const string D3D12SwapchainPointer = "SDL.renderer.d3d12.swap_chain";
			public const string D3D12CommandQueuePointer = "SDL.renderer.d3d12.command_queue";
			public const string VulkanInstancePointer = "SDL.renderer.vulkan.instance";
			public const string VulkanSurfaceNumber = "SDL.renderer.vulkan.surface";
			public const string VulkanPhysicalDevicePointer = "SDL.renderer.vulkan.physical_device";
			public const string VulkanDevicePointer = "SDL.renderer.vulkan.device";
			public const string VulkanGraphicsQueueFamilyIndexNumber = "SDL.renderer.vulkan.graphics_queue_family_index";
			public const string VulkanPresentQueueFamilyIndexNumber = "SDL.renderer.vulkan.present_queue_family_index";
			public const string VulkanSwapchainImageCountNumber = "SDL.renderer.vulkan.swapchain_image_count";
			public const string GpuDevicePointer = "SDL.renderer.gpu.device";

			public static partial class Create
			{
				public const string NameString = "SDL.renderer.create.name";
				public const string WindowPointer = "SDL.renderer.create.window";
				public const string SurfacePointer = "SDL.renderer.create.surface";
				public const string OutputColorspaceNumber = "SDL.renderer.create.output_colorspace";
				public const string PresentVsyncNumber = "SDL.renderer.create.present_vsync";
				public const string GpuDevicePointer = "SDL.renderer.create.gpu.device";
				public const string GpuShadersSpirvBoolean = "SDL.renderer.create.gpu.shaders_spirv";
				public const string GpuShadersDxilBoolean = "SDL.renderer.create.gpu.shaders_dxil";
				public const string GpuShadersMslBoolean = "SDL.renderer.create.gpu.shaders_msl";
				public const string VulkanInstancePointer = "SDL.renderer.create.vulkan.instance";
				public const string VulkanSurfaceNumber = "SDL.renderer.create.vulkan.surface";
				public const string VulkanPhysicalDevicePointer = "SDL.renderer.create.vulkan.physical_device";
				public const string VulkanDevicePointer = "SDL.renderer.create.vulkan.device";
				public const string VulkanGraphicsQueueFamilyIndexNumber = "SDL.renderer.create.vulkan.graphics_queue_family_index";
				public const string VulkanPresentQueueFamilyIndexNumber = "SDL.renderer.create.vulkan.present_queue_family_index";
			}

			public static partial class Texture
			{
				public const string ColorspaceNumber = "SDL.texture.colorspace";
				public const string FormatNumber = "SDL.texture.format";
				public const string AccessNumber = "SDL.texture.access";
				public const string WidthNumber = "SDL.texture.width";
				public const string HeightNumber = "SDL.texture.height";
				public const string SdrWhitePointFloat = "SDL.texture.SDR_white_point";
				public const string HdrHeadroomFloat = "SDL.texture.HDR_headroom";
				public const string D3D11TexturePointer = "SDL.texture.d3d11.texture";
				public const string D3D11TextureUPointer = "SDL.texture.d3d11.texture_u";
				public const string D3D11TextureVPointer = "SDL.texture.d3d11.texture_v";
				public const string D3D12TexturePointer = "SDL.texture.d3d12.texture";
				public const string D3D12TextureUPointer = "SDL.texture.d3d12.texture_u";
				public const string D3D12TextureVPointer = "SDL.texture.d3d12.texture_v";
				public const string OpenglTextureNumber = "SDL.texture.opengl.texture";
				public const string OpenglTextureUvNumber = "SDL.texture.opengl.texture_uv";
				public const string OpenglTextureUNumber = "SDL.texture.opengl.texture_u";
				public const string OpenglTextureVNumber = "SDL.texture.opengl.texture_v";
				public const string OpenglTextureTargetNumber = "SDL.texture.opengl.target";
				public const string OpenglTexWFloat = "SDL.texture.opengl.tex_w";
				public const string OpenglTexHFloat = "SDL.texture.opengl.tex_h";
				public const string Opengles2TextureNumber = "SDL.texture.opengles2.texture";
				public const string Opengles2TextureUvNumber = "SDL.texture.opengles2.texture_uv";
				public const string Opengles2TextureUNumber = "SDL.texture.opengles2.texture_u";
				public const string Opengles2TextureVNumber = "SDL.texture.opengles2.texture_v";
				public const string Opengles2TextureTargetNumber = "SDL.texture.opengles2.target";
				public const string VulkanTextureNumber = "SDL.texture.vulkan.texture";
				public const string GpuTexturePointer = "SDL.texture.gpu.texture";
				public const string GpuTextureUvPointer = "SDL.texture.gpu.texture_uv";
				public const string GpuTextureUPointer = "SDL.texture.gpu.texture_u";
				public const string GpuTextureVPointer = "SDL.texture.gpu.texture_v";

				public static partial class Create
				{
					public const string ColorspaceNumber = "SDL.texture.create.colorspace";
					public const string FormatNumber = "SDL.texture.create.format";
					public const string AccessNumber = "SDL.texture.create.access";
					public const string WidthNumber = "SDL.texture.create.width";
					public const string HeightNumber = "SDL.texture.create.height";
					public const string PalettePointer = "SDL.texture.create.palette";
					public const string SdrWhitePointFloat = "SDL.texture.create.SDR_white_point";
					public const string HdrHeadroomFloat = "SDL.texture.create.HDR_headroom";
					public const string D3D11TexturePointer = "SDL.texture.create.d3d11.texture";
					public const string D3D11TextureUPointer = "SDL.texture.create.d3d11.texture_u";
					public const string D3D11TextureVPointer = "SDL.texture.create.d3d11.texture_v";
					public const string D3D12TexturePointer = "SDL.texture.create.d3d12.texture";
					public const string D3D12TextureUPointer = "SDL.texture.create.d3d12.texture_u";
					public const string D3D12TextureVPointer = "SDL.texture.create.d3d12.texture_v";
					public const string MetalPixelbufferPointer = "SDL.texture.create.metal.pixelbuffer";
					public const string OpenglTextureNumber = "SDL.texture.create.opengl.texture";
					public const string OpenglTextureUvNumber = "SDL.texture.create.opengl.texture_uv";
					public const string OpenglTextureUNumber = "SDL.texture.create.opengl.texture_u";
					public const string OpenglTextureVNumber = "SDL.texture.create.opengl.texture_v";
					public const string Opengles2TextureNumber = "SDL.texture.create.opengles2.texture";
					public const string Opengles2TextureUvNumber = "SDL.texture.create.opengles2.texture_uv";
					public const string Opengles2TextureUNumber = "SDL.texture.create.opengles2.texture_u";
					public const string Opengles2TextureVNumber = "SDL.texture.create.opengles2.texture_v";
					public const string VulkanTextureNumber = "SDL.texture.create.vulkan.texture";
					public const string VulkanLayoutNumber = "SDL.texture.create.vulkan.layout";
					public const string GpuTexturePointer = "SDL.texture.create.gpu.texture";
					public const string GpuTextureUvPointer = "SDL.texture.create.gpu.texture_uv";
					public const string GpuTextureUPointer = "SDL.texture.create.gpu.texture_u";
					public const string GpuTextureVPointer = "SDL.texture.create.gpu.texture_v";
				}

			}
		}
	}

	private static partial class Native
	{

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial int SDL_GetNumRenderDrivers();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial string SDL_GetRenderDriver(int index);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_CreateWindowAndRenderer(string title, int width, int height, WindowFlags windowFlags, out Ptr<Window> window, out Ptr<Renderer> renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_CreateRenderer(in Window window, string name);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_CreateRendererWithProperties(PropertiesID props);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_CreateGpuRenderer(in GpuDevice device, in Window window);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<GpuDevice> SDL_GetGpuRendererDevice(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_CreateSoftwareRenderer(in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_GetRenderer(in Window window);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Window> SDL_GetRenderWindow(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial string SDL_GetRendererName(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial PropertiesID SDL_GetRendererProperties(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderOutputSize(in Renderer renderer, out int w, out int h);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetCurrentRenderOutputSize(in Renderer renderer, out int w, out int h);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Texture> SDL_CreateTexture(in Renderer renderer, PixelFormat format, TextureAccess access, int w, int h);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Texture> SDL_CreateTextureFromSurface(in Renderer renderer, in Surface surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Texture> SDL_CreateTextureWithProperties(in Renderer renderer, PropertiesID props);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial PropertiesID SDL_GetTextureProperties(in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Renderer> SDL_GetRendererFromTexture(in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureSize(in Texture texture, out float w, out float h);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTexturePalette(in Texture texture, in Palette palette);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Palette> SDL_GetTexturePalette(in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureColorMod(in Texture texture, byte r, byte g, byte b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureColorModFloat(in Texture texture, float r, float g, float b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureColorMod(in Texture texture, out byte r, out byte g, out byte b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureColorModFloat(in Texture texture, out float r, out float g, out float b);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureAlphaMod(in Texture texture, byte alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureAlphaModFloat(in Texture texture, float alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureAlphaMod(in Texture texture, out byte alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureAlphaModFloat(in Texture texture, out float alpha);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureBlendMode(in Texture texture, BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureBlendMode(in Texture texture, out BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetTextureScaleMode(in Texture texture, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetTextureScaleMode(in Texture texture, out ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_UpdateTexture(in Texture texture, in Rect rect, nint pixels, int pitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_UpdateYuvTexture(in Texture texture, in Rect rect, in byte yplane, int ypitch, in byte uplane, int upitch, in byte vplane, int vpitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_UpdateNvTexture(in Texture texture, in Rect rect, in byte yplane, int ypitch, in byte uVplane, int uVpitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_LockTexture(in Texture texture, in Rect rect, out nint pixels, out int pitch);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_LockTextureToSurface(in Texture texture, in Rect rect, out Ptr<Surface> surface);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_UnlockTexture(in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderTarget(in Renderer renderer, in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Texture> SDL_GetRenderTarget(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderLogicalPresentation(in Renderer renderer, int w, int h, RendererLogicalPresentation mode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderLogicalPresentation(in Renderer renderer, out int w, out int h, out RendererLogicalPresentation mode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderLogicalPresentationRect(in Renderer renderer, out FRect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderCoordinatesFromWindow(in Renderer renderer, float windowX, float windowY, out float x, out float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderCoordinatesToWindow(in Renderer renderer, float x, float y, out float windowX, out float windowY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_ConvertEventToRenderCoordinates(in Renderer renderer, ref Event @event);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderViewport(in Renderer renderer, in Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderViewport(in Renderer renderer, out Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderViewportSet(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderSafeArea(in Renderer renderer, out Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderClipRect(in Renderer renderer, in Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderClipRect(in Renderer renderer, out Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderClipEnabled(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderScale(in Renderer renderer, float scaleX, float scaleY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderScale(in Renderer renderer, out float scaleX, out float scaleY);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderDrawColor(in Renderer renderer, byte r, byte g, byte b, byte a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderDrawColorFloat(in Renderer renderer, float r, float g, float b, float a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderDrawColor(in Renderer renderer, out byte r, out byte g, out byte b, out byte a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderDrawColorFloat(in Renderer renderer, out float r, out float g, out float b, out float a);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderColorScale(in Renderer renderer, float scale);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderColorScale(in Renderer renderer, out float scale);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderDrawBlendMode(in Renderer renderer, BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderDrawBlendMode(in Renderer renderer, out BlendMode blendMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderClear(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderPoint(in Renderer renderer, float x, float y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderPoints(in Renderer renderer, in FPoint points, int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderLine(in Renderer renderer, float x1, float y1, float x2, float y2);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderLines(in Renderer renderer, in FPoint points, int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderRect(in Renderer renderer, in FRect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderRects(in Renderer renderer, in FRect rects, int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderFillRect(in Renderer renderer, in FRect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderFillRects(in Renderer renderer, in FRect rects, int count);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTexture(in Renderer renderer, in Texture texture, in FRect srcrect, in FRect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTextureRotated(in Renderer renderer, in Texture texture, in FRect srcrect, in FRect dstrect, double angle, in FPoint center, FlipMode flip);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTextureAffine(in Renderer renderer, in Texture texture, in FRect srcrect, in FPoint origin, in FPoint right, in FPoint down);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTextureTiled(in Renderer renderer, in Texture texture, in FRect srcrect, float scale, in FRect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTexture9Grid(in Renderer renderer, in Texture texture, in FRect srcrect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, in FRect dstrect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderTexture9GridTiled(in Renderer renderer, in Texture texture, in FRect srcrect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, in FRect dstrect, float tileScale);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderGeometry(in Renderer renderer, in Texture texture, nint vertices, int numVertices, nint indices, int numIndices);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderGeometryRaw(in Renderer renderer, in Texture texture, nint xy, int xyStride, nint color, int colorStride, nint uv, int uvStride, int numVertices, nint indices, int numIndices, int sizeIndices);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderTextureAddressMode(in Renderer renderer, TextureAddressMode uMode, TextureAddressMode vMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderTextureAddressMode(in Renderer renderer, out TextureAddressMode uMode, out TextureAddressMode vMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<Surface> SDL_RenderReadPixels(in Renderer renderer, in Rect rect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderPresent(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_DestroyTexture(in Texture texture);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_DestroyRenderer(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_FlushRenderer(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial nint SDL_GetRenderMetalLayer(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial nint SDL_GetRenderMetalCommandEncoder(in Renderer renderer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_AddVulkanRenderSemaphores(in Renderer renderer, uint waitStageMask, long waitSemaphore, long signalSemaphore);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetRenderVSync(in Renderer renderer, int vsync);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetRenderVSync(in Renderer renderer, out int vsync);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_RenderDebugText(in Renderer renderer, float x, float y, string str);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetDefaultTextureScaleMode(in Renderer renderer, ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_GetDefaultTextureScaleMode(in Renderer renderer, out ScaleMode scaleMode);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial Ptr<GpuRenderState> SDL_CreateGpuRenderState(in Renderer renderer, in GpuRenderStateCreateInfo createinfo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetGpuRenderStateFragmentUniforms(ref GpuRenderState state, uint slotIndex, nint data, uint length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetGpuRenderState(in Renderer renderer, in GpuRenderState state);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		[return: MarshalAs(UnmanagedType.I1)]
		public static partial bool SDL_SetGpuRenderState(in Renderer renderer, nint state);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[LibraryImport(LibraryName, StringMarshalling = StringMarshalling.Utf8)]
		[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
		public static partial void SDL_DestroyGpuRenderState(in GpuRenderState state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetNumRenderDrivers() => Native.SDL_GetNumRenderDrivers();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string GetRenderDriver(int index) => Native.SDL_GetRenderDriver(index);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool CreateWindowAndRenderer(string title, int width, int height, WindowFlags windowFlags, out Ptr<Window> window, out Ptr<Renderer> renderer) => Native.SDL_CreateWindowAndRenderer(title, width, height, windowFlags, out window, out renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> CreateRenderer(in Window window, string name) => Native.SDL_CreateRenderer(window, name);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> CreateRendererWithProperties(PropertiesID props) => Native.SDL_CreateRendererWithProperties(props);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> CreateGpuRenderer(in GpuDevice device, in Window window) => Native.SDL_CreateGpuRenderer(device, window);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<GpuDevice> GetGpuRendererDevice(in Renderer renderer) => Native.SDL_GetGpuRendererDevice(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> CreateSoftwareRenderer(in Surface surface) => Native.SDL_CreateSoftwareRenderer(surface);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> GetRenderer(in Window window) => Native.SDL_GetRenderer(window);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Window> GetRenderWindow(in Renderer renderer) => Native.SDL_GetRenderWindow(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string GetRendererName(in Renderer renderer) => Native.SDL_GetRendererName(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static PropertiesID GetRendererProperties(in Renderer renderer) => Native.SDL_GetRendererProperties(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderOutputSize(in Renderer renderer, out int w, out int h) => Native.SDL_GetRenderOutputSize(renderer, out w, out h);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetCurrentRenderOutputSize(in Renderer renderer, out int w, out int h) => Native.SDL_GetCurrentRenderOutputSize(renderer, out w, out h);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Texture> CreateTexture(in Renderer renderer, PixelFormat format, TextureAccess access, int w, int h) => Native.SDL_CreateTexture(renderer, format, access, w, h);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Texture> CreateTextureFromSurface(in Renderer renderer, in Surface surface) => Native.SDL_CreateTextureFromSurface(renderer, surface);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Texture> CreateTextureWithProperties(in Renderer renderer, PropertiesID props) => Native.SDL_CreateTextureWithProperties(renderer, props);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static PropertiesID GetTextureProperties(in Texture texture) => Native.SDL_GetTextureProperties(texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Renderer> GetRendererFromTexture(in Texture texture) => Native.SDL_GetRendererFromTexture(texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureSize(in Texture texture, out float w, out float h) => Native.SDL_GetTextureSize(texture, out w, out h);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTexturePalette(in Texture texture, in Palette palette) => Native.SDL_SetTexturePalette(texture, palette);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Palette> GetTexturePalette(in Texture texture) => Native.SDL_GetTexturePalette(texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureColorMod(in Texture texture, byte r, byte g, byte b) => Native.SDL_SetTextureColorMod(in texture, r, g, b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureColorModFloat(in Texture texture, float r, float g, float b) => Native.SDL_SetTextureColorModFloat(in texture, r, g, b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureColorMod(in Texture texture, out byte r, out byte g, out byte b) => Native.SDL_GetTextureColorMod(in texture, out r, out g, out b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureColorModFloat(in Texture texture, out float r, out float g, out float b) => Native.SDL_GetTextureColorModFloat(in texture, out r, out g, out b);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureAlphaMod(in Texture texture, byte alpha) => Native.SDL_SetTextureAlphaMod(in texture, alpha);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureAlphaModFloat(in Texture texture, float alpha) => Native.SDL_SetTextureAlphaModFloat(in texture, alpha);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureAlphaMod(in Texture texture, out byte alpha) => Native.SDL_GetTextureAlphaMod(in texture, out alpha);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureAlphaModFloat(in Texture texture, out float alpha) => Native.SDL_GetTextureAlphaModFloat(in texture, out alpha);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureBlendMode(in Texture texture, BlendMode blendMode) => Native.SDL_SetTextureBlendMode(in texture, blendMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureBlendMode(in Texture texture, out BlendMode blendMode) => Native.SDL_GetTextureBlendMode(in texture, out blendMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetTextureScaleMode(in Texture texture, ScaleMode scaleMode) => Native.SDL_SetTextureScaleMode(in texture, scaleMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetTextureScaleMode(in Texture texture, out ScaleMode scaleMode) => Native.SDL_GetTextureScaleMode(in texture, out scaleMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool UpdateTexture(in Texture texture, in Rect rect, nint pixels, int pitch) => Native.SDL_UpdateTexture(in texture, in rect, pixels, pitch);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool UpdateYuvTexture(in Texture texture, in Rect rect, in byte yplane, int ypitch, in byte uplane, int upitch, in byte vplane, int vpitch) => Native.SDL_UpdateYuvTexture(in texture, in rect, in yplane, ypitch, in uplane, upitch, in vplane, vpitch);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool UpdateNvTexture(in Texture texture, in Rect rect, in byte yplane, int ypitch, in byte uVplane, int uVpitch) => Native.SDL_UpdateNvTexture(in texture, in rect, in yplane, ypitch, in uVplane, uVpitch);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LockTexture(in Texture texture, in Rect rect, out nint pixels, out int pitch) => Native.SDL_LockTexture(in texture, in rect, out pixels, out pitch);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LockTextureToSurface(in Texture texture, in Rect rect, out Ptr<Surface> surface) => Native.SDL_LockTextureToSurface(in texture, in rect, out surface);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UnlockTexture(in Texture texture) => Native.SDL_UnlockTexture(texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderTarget(in Renderer renderer, in Texture texture) => Native.SDL_SetRenderTarget(in renderer, in texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Texture> GetRenderTarget(in Renderer renderer) => Native.SDL_GetRenderTarget(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderLogicalPresentation(in Renderer renderer, int w, int h, RendererLogicalPresentation mode) => Native.SDL_SetRenderLogicalPresentation(in renderer, w, h, mode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderLogicalPresentation(in Renderer renderer, out int w, out int h, out RendererLogicalPresentation mode) => Native.SDL_GetRenderLogicalPresentation(in renderer, out w, out h, out mode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderLogicalPresentationRect(in Renderer renderer, out FRect rect) => Native.SDL_GetRenderLogicalPresentationRect(in renderer, out rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderCoordinatesFromWindow(in Renderer renderer, float windowX, float windowY, out float x, out float y) => Native.SDL_RenderCoordinatesFromWindow(in renderer, windowX, windowY, out x, out y);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderCoordinatesToWindow(in Renderer renderer, float x, float y, out float windowX, out float windowY) => Native.SDL_RenderCoordinatesToWindow(in renderer, x, y, out windowX, out windowY);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ConvertEventToRenderCoordinates(in Renderer renderer, ref Event @event) => Native.SDL_ConvertEventToRenderCoordinates(in renderer, ref @event);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderViewport(in Renderer renderer, in Rect rect) => Native.SDL_SetRenderViewport(in renderer, in rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderViewport(in Renderer renderer, out Rect rect) => Native.SDL_GetRenderViewport(in renderer, out rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderViewportSet(in Renderer renderer) => Native.SDL_RenderViewportSet(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderSafeArea(in Renderer renderer, out Rect rect) => Native.SDL_GetRenderSafeArea(in renderer, out rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderClipRect(in Renderer renderer, in Rect rect) => Native.SDL_SetRenderClipRect(in renderer, in rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderClipRect(in Renderer renderer, out Rect rect) => Native.SDL_GetRenderClipRect(in renderer, out rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderClipEnabled(in Renderer renderer) => Native.SDL_RenderClipEnabled(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderScale(in Renderer renderer, float scaleX, float scaleY) => Native.SDL_SetRenderScale(in renderer, scaleX, scaleY);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderScale(in Renderer renderer, out float scaleX, out float scaleY) => Native.SDL_GetRenderScale(in renderer, out scaleX, out scaleY);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderDrawColor(in Renderer renderer, byte r, byte g, byte b, byte a) => Native.SDL_SetRenderDrawColor(in renderer, r, g, b, a);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderDrawColorFloat(in Renderer renderer, float r, float g, float b, float a) => Native.SDL_SetRenderDrawColorFloat(in renderer, r, g, b, a);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderDrawColor(in Renderer renderer, out byte r, out byte g, out byte b, out byte a) => Native.SDL_GetRenderDrawColor(in renderer, out r, out g, out b, out a);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderDrawColorFloat(in Renderer renderer, out float r, out float g, out float b, out float a) => Native.SDL_GetRenderDrawColorFloat(in renderer, out r, out g, out b, out a);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderColorScale(in Renderer renderer, float scale) => Native.SDL_SetRenderColorScale(in renderer, scale);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderColorScale(in Renderer renderer, out float scale) => Native.SDL_GetRenderColorScale(in renderer, out scale);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderDrawBlendMode(in Renderer renderer, BlendMode blendMode) => Native.SDL_SetRenderDrawBlendMode(in renderer, blendMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderDrawBlendMode(in Renderer renderer, out BlendMode blendMode) => Native.SDL_GetRenderDrawBlendMode(in renderer, out blendMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderClear(in Renderer renderer) => Native.SDL_RenderClear(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderPoint(in Renderer renderer, float x, float y) => Native.SDL_RenderPoint(in renderer, x, y);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderPoints(in Renderer renderer, in FPoint points, int count) => Native.SDL_RenderPoints(in renderer, in points, count);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderLine(in Renderer renderer, float x1, float y1, float x2, float y2) => Native.SDL_RenderLine(in renderer, x1, y1, x2, y2);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderLines(in Renderer renderer, in FPoint points, int count) => Native.SDL_RenderLines(in renderer, in points, count);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderRect(in Renderer renderer, in FRect rect) => Native.SDL_RenderRect(in renderer, in rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderRects(in Renderer renderer, in FRect rects, int count) => Native.SDL_RenderRects(in renderer, in rects, count);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderFillRect(in Renderer renderer, in FRect rect) => Native.SDL_RenderFillRect(in renderer, in rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderFillRects(in Renderer renderer, in FRect rects, int count) => Native.SDL_RenderFillRects(in renderer, in rects, count);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTexture(in Renderer renderer, in Texture texture, in FRect srcrect, in FRect dstrect) => Native.SDL_RenderTexture(in renderer, in texture, in srcrect, in dstrect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTextureRotated(in Renderer renderer, in Texture texture, in FRect srcrect, in FRect dstrect, double angle, in FPoint center, FlipMode flip) => Native.SDL_RenderTextureRotated(in renderer, in texture, in srcrect, in dstrect, angle, in center, flip);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTextureAffine(in Renderer renderer, in Texture texture, in FRect srcrect, in FPoint origin, in FPoint right, in FPoint down) => Native.SDL_RenderTextureAffine(in renderer, in texture, in srcrect, in origin, in right, in down);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTextureTiled(in Renderer renderer, in Texture texture, in FRect srcrect, float scale, in FRect dstrect) => Native.SDL_RenderTextureTiled(in renderer, in texture, in srcrect, scale, in dstrect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTexture9Grid(in Renderer renderer, in Texture texture, in FRect srcrect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, in FRect dstrect) => Native.SDL_RenderTexture9Grid(in renderer, in texture, in srcrect, leftWidth, rightWidth, topHeight, bottomHeight, scale, in dstrect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderTexture9GridTiled(in Renderer renderer, in Texture texture, in FRect srcrect, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, in FRect dstrect, float tileScale) => Native.SDL_RenderTexture9GridTiled(in renderer, in texture, in srcrect, leftWidth, rightWidth, topHeight, bottomHeight, scale, in dstrect, tileScale);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool RenderGeometry(in Renderer renderer, in Texture texture, ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices)
	{
		fixed (Vertex* verticesPtr = vertices)
		fixed (int* indicesPtr = indices)
			return Native.SDL_RenderGeometry(in renderer, in texture, (nint)verticesPtr, vertices.Length, (nint)indicesPtr, indices.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool RenderGeometry(in Renderer renderer, in Texture texture, ReadOnlySpan<Vertex> vertices)
	{
		fixed (Vertex* verticesPtr = vertices)
			return Native.SDL_RenderGeometry(in renderer, in texture, (nint)verticesPtr, vertices.Length, 0, 0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool RenderGeometryRaw(in Renderer renderer, in Texture texture, ReadOnlySpan<float> xy, int xyStride, ReadOnlySpan<FColor> color, int colorStride, ReadOnlySpan<float> uv, int uvStride, int numVertices, Span<int> indices)
	{
		fixed (float* xyPtr = xy)
		fixed (FColor* colorPtr = color)
		fixed (float* uvPtr = uv)
		fixed (int* indicesPtr = indices)
			return Native.SDL_RenderGeometryRaw(in renderer, in texture, (nint)xyPtr, xyStride, (nint)colorPtr, colorStride, (nint)uvPtr, uvStride, numVertices, (nint)indicesPtr, indices.Length, 4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool RenderGeometryRaw(in Renderer renderer, in Texture texture, ReadOnlySpan<float> xy, int xyStride, ReadOnlySpan<FColor> color, int colorStride, ReadOnlySpan<float> uv, int uvStride, int numVertices, Span<ushort> indices)
	{
		fixed (float* xyPtr = xy)
		fixed (FColor* colorPtr = color)
		fixed (float* uvPtr = uv)
		fixed (ushort* indicesPtr = indices)
			return Native.SDL_RenderGeometryRaw(in renderer, in texture, (nint)xyPtr, xyStride, (nint)colorPtr, colorStride, (nint)uvPtr, uvStride, numVertices, (nint)indicesPtr, indices.Length, 2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe bool RenderGeometryRaw(in Renderer renderer, in Texture texture, ReadOnlySpan<float> xy, int xyStride, ReadOnlySpan<FColor> color, int colorStride, ReadOnlySpan<float> uv, int uvStride, int numVertices, Span<byte> indices)
	{
		fixed (float* xyPtr = xy)
		fixed (FColor* colorPtr = color)
		fixed (float* uvPtr = uv)
		fixed (byte* indicesPtr = indices)
			return Native.SDL_RenderGeometryRaw(in renderer, in texture, (nint)xyPtr, xyStride, (nint)colorPtr, colorStride, (nint)uvPtr, uvStride, numVertices, (nint)indicesPtr, indices.Length, 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderTextureAddressMode(in Renderer renderer, TextureAddressMode uMode, TextureAddressMode vMode) => Native.SDL_SetRenderTextureAddressMode(in renderer, uMode, vMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderTextureAddressMode(in Renderer renderer, out TextureAddressMode uMode, out TextureAddressMode vMode) => Native.SDL_GetRenderTextureAddressMode(in renderer, out uMode, out vMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<Surface> RenderReadPixels(in Renderer renderer, in Rect rect) => Native.SDL_RenderReadPixels(in renderer, in rect);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderPresent(in Renderer renderer) => Native.SDL_RenderPresent(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DestroyTexture(in Texture texture) => Native.SDL_DestroyTexture(texture);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DestroyRenderer(in Renderer renderer) => Native.SDL_DestroyRenderer(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FlushRenderer(in Renderer renderer) => Native.SDL_FlushRenderer(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint GetRenderMetalLayer(in Renderer renderer) => Native.SDL_GetRenderMetalLayer(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint GetRenderMetalCommandEncoder(in Renderer renderer) => Native.SDL_GetRenderMetalCommandEncoder(renderer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool AddVulkanRenderSemaphores(in Renderer renderer, uint waitStageMask, long waitSemaphore, long signalSemaphore) => Native.SDL_AddVulkanRenderSemaphores(in renderer, waitStageMask, waitSemaphore, signalSemaphore);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetRenderVSync(in Renderer renderer, int vsync) => Native.SDL_SetRenderVSync(in renderer, vsync);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetRenderVSync(in Renderer renderer, out int vsync) => Native.SDL_GetRenderVSync(in renderer, out vsync);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RenderDebugText(in Renderer renderer, float x, float y, string str) => Native.SDL_RenderDebugText(in renderer, x, y, str);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetDefaultTextureScaleMode(in Renderer renderer, ScaleMode scaleMode) => Native.SDL_SetDefaultTextureScaleMode(in renderer, scaleMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetDefaultTextureScaleMode(in Renderer renderer, out ScaleMode scaleMode) => Native.SDL_GetDefaultTextureScaleMode(in renderer, out scaleMode);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Ptr<GpuRenderState> CreateGpuRenderState(in Renderer renderer, in GpuRenderStateCreateInfo createinfo) => Native.SDL_CreateGpuRenderState(in renderer, in createinfo);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetGpuRenderStateFragmentUniforms(ref GpuRenderState state, uint slotIndex, nint data, uint length) => Native.SDL_SetGpuRenderStateFragmentUniforms(ref state, slotIndex, data, length);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetGpuRenderState(in Renderer renderer, in GpuRenderState state) => Native.SDL_SetGpuRenderState(in renderer, in state);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool SetGpuRenderState(in Renderer renderer, nint state) => Native.SDL_SetGpuRenderState(in renderer, state);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DestroyGpuRenderState(in GpuRenderState state) => Native.SDL_DestroyGpuRenderState(state);
}
