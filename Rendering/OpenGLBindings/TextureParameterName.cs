namespace OpenGLBindings
{
    /// <summary>
    /// Used in GL.TexParameter, GL.TexParameterI and 6 other functions
    /// </summary>
    public enum TextureParameterName
    {
        /// <summary>
        /// Original was GL_TEXTURE_WIDTH = 0x1000
        /// </summary>
        TextureWidth = 0x1000,
        /// <summary>
        /// Original was GL_TEXTURE_HEIGHT = 0x1001
        /// </summary>
        TextureHeight = 4097,
        /// <summary>
        /// Original was GL_TEXTURE_COMPONENTS = 0x1003
        /// </summary>
        TextureComponents = 4099,
        /// <summary>
        /// Original was GL_TEXTURE_INTERNAL_FORMAT = 0x1003
        /// </summary>
        TextureInternalFormat = 4099,
        /// <summary>
        /// Original was GL_TEXTURE_BORDER_COLOR = 0x1004
        /// </summary>
        TextureBorderColor = 4100,
        /// <summary>
        /// Original was GL_TEXTURE_BORDER_COLOR_NV = 0x1004
        /// </summary>
        TextureBorderColorNv = 4100,
        /// <summary>
        /// Original was GL_TEXTURE_BORDER = 0x1005
        /// </summary>
        TextureBorder = 4101,
        /// <summary>
        /// Original was GL_TEXTURE_MAG_FILTER = 0x2800
        /// </summary>
        TextureMagFilter = 10240,
        /// <summary>
        /// Original was GL_TEXTURE_MIN_FILTER = 0x2801
        /// </summary>
        TextureMinFilter = 10241,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_S = 0x2802
        /// </summary>
        TextureWrapS = 10242,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_T = 0x2803
        /// </summary>
        TextureWrapT = 10243,
        /// <summary>
        /// Original was GL_TEXTURE_RED_SIZE = 0x805C
        /// </summary>
        TextureRedSize = 32860,
        /// <summary>
        /// Original was GL_TEXTURE_GREEN_SIZE = 0x805D
        /// </summary>
        TextureGreenSize = 32861,
        /// <summary>
        /// Original was GL_TEXTURE_BLUE_SIZE = 0x805E
        /// </summary>
        TextureBlueSize = 32862,
        /// <summary>
        /// Original was GL_TEXTURE_ALPHA_SIZE = 0x805F
        /// </summary>
        TextureAlphaSize = 32863,
        /// <summary>
        /// Original was GL_TEXTURE_LUMINANCE_SIZE = 0x8060
        /// </summary>
        TextureLuminanceSize = 32864,
        /// <summary>
        /// Original was GL_TEXTURE_INTENSITY_SIZE = 0x8061
        /// </summary>
        TextureIntensitySize = 32865,
        /// <summary>
        /// Original was GL_TEXTURE_PRIORITY = 0x8066
        /// </summary>
        TexturePriority = 32870,
        /// <summary>
        /// Original was GL_TEXTURE_PRIORITY_EXT = 0x8066
        /// </summary>
        TexturePriorityExt = 32870,
        /// <summary>
        /// Original was GL_TEXTURE_RESIDENT = 0x8067
        /// </summary>
        TextureResident = 32871,
        /// <summary>
        /// Original was GL_TEXTURE_DEPTH = 0x8071
        /// </summary>
        TextureDepth = 32881,
        /// <summary>
        /// Original was GL_TEXTURE_DEPTH_EXT = 0x8071
        /// </summary>
        TextureDepthExt = 32881,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_R = 0x8072
        /// </summary>
        TextureWrapR = 32882,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_R_EXT = 0x8072
        /// </summary>
        TextureWrapRExt = 32882,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_R_OES = 0x8072
        /// </summary>
        TextureWrapROes = 32882,
        /// <summary>
        /// Original was GL_DETAIL_TEXTURE_LEVEL_SGIS = 0x809A
        /// </summary>
        DetailTextureLevelSgis = 32922,
        /// <summary>
        /// Original was GL_DETAIL_TEXTURE_MODE_SGIS = 0x809B
        /// </summary>
        DetailTextureModeSgis = 32923,
        /// <summary>
        /// Original was GL_DETAIL_TEXTURE_FUNC_POINTS_SGIS = 0x809C
        /// </summary>
        DetailTextureFuncPointsSgis = 32924,
        /// <summary>
        /// Original was GL_SHARPEN_TEXTURE_FUNC_POINTS_SGIS = 0x80B0
        /// </summary>
        SharpenTextureFuncPointsSgis = 32944,
        /// <summary>
        /// Original was GL_SHADOW_AMBIENT_SGIX = 0x80BF
        /// </summary>
        ShadowAmbientSgix = 32959,
        /// <summary>
        /// Original was GL_TEXTURE_COMPARE_FAIL_VALUE = 0x80BF
        /// </summary>
        TextureCompareFailValue = 32959,
        /// <summary>
        /// Original was GL_DUAL_TEXTURE_SELECT_SGIS = 0x8124
        /// </summary>
        DualTextureSelectSgis = 33060,
        /// <summary>
        /// Original was GL_QUAD_TEXTURE_SELECT_SGIS = 0x8125
        /// </summary>
        QuadTextureSelectSgis = 33061,
        /// <summary>
        /// Original was GL_CLAMP_TO_BORDER = 0x812D
        /// </summary>
        ClampToBorder = 33069,
        /// <summary>
        /// Original was GL_CLAMP_TO_EDGE = 0x812F
        /// </summary>
        ClampToEdge = 33071,
        /// <summary>
        /// Original was GL_TEXTURE_4DSIZE_SGIS = 0x8136
        /// </summary>
        Texture4DsizeSgis = 33078,
        /// <summary>
        /// Original was GL_TEXTURE_WRAP_Q_SGIS = 0x8137
        /// </summary>
        TextureWrapQSgis = 33079,
        /// <summary>
        /// Original was GL_TEXTURE_MIN_LOD = 0x813A
        /// </summary>
        TextureMinLod = 33082,
        /// <summary>
        /// Original was GL_TEXTURE_MIN_LOD_SGIS = 0x813A
        /// </summary>
        TextureMinLodSgis = 33082,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_LOD = 0x813B
        /// </summary>
        TextureMaxLod = 33083,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_LOD_SGIS = 0x813B
        /// </summary>
        TextureMaxLodSgis = 33083,
        /// <summary>
        /// Original was GL_TEXTURE_BASE_LEVEL = 0x813C
        /// </summary>
        TextureBaseLevel = 33084,
        /// <summary>
        /// Original was GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C
        /// </summary>
        TextureBaseLevelSgis = 33084,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_LEVEL = 0x813D
        /// </summary>
        TextureMaxLevel = 33085,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D
        /// </summary>
        TextureMaxLevelSgis = 33085,
        /// <summary>
        /// Original was GL_TEXTURE_FILTER4_SIZE_SGIS = 0x8147
        /// </summary>
        TextureFilter4SizeSgis = 33095,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_CENTER_SGIX = 0x8171
        /// </summary>
        TextureClipmapCenterSgix = 33137,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_FRAME_SGIX = 0x8172
        /// </summary>
        TextureClipmapFrameSgix = 33138,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_OFFSET_SGIX = 0x8173
        /// </summary>
        TextureClipmapOffsetSgix = 33139,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8174
        /// </summary>
        TextureClipmapVirtualDepthSgix = 33140,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_LOD_OFFSET_SGIX = 0x8175
        /// </summary>
        TextureClipmapLodOffsetSgix = 33141,
        /// <summary>
        /// Original was GL_TEXTURE_CLIPMAP_DEPTH_SGIX = 0x8176
        /// </summary>
        TextureClipmapDepthSgix = 33142,
        /// <summary>
        /// Original was GL_POST_TEXTURE_FILTER_BIAS_SGIX = 0x8179
        /// </summary>
        PostTextureFilterBiasSgix = 33145,
        /// <summary>
        /// Original was GL_POST_TEXTURE_FILTER_SCALE_SGIX = 0x817A
        /// </summary>
        PostTextureFilterScaleSgix = 33146,
        /// <summary>
        /// Original was GL_TEXTURE_LOD_BIAS_S_SGIX = 0x818E
        /// </summary>
        TextureLodBiasSSgix = 33166,
        /// <summary>
        /// Original was GL_TEXTURE_LOD_BIAS_T_SGIX = 0x818F
        /// </summary>
        TextureLodBiasTSgix = 33167,
        /// <summary>
        /// Original was GL_TEXTURE_LOD_BIAS_R_SGIX = 0x8190
        /// </summary>
        TextureLodBiasRSgix = 33168,
        /// <summary>
        /// Original was GL_GENERATE_MIPMAP = 0x8191
        /// </summary>
        GenerateMipmap = 33169,
        /// <summary>
        /// Original was GL_GENERATE_MIPMAP_SGIS = 0x8191
        /// </summary>
        GenerateMipmapSgis = 33169,
        /// <summary>
        /// Original was GL_TEXTURE_COMPARE_SGIX = 0x819A
        /// </summary>
        TextureCompareSgix = 33178,
        /// <summary>
        /// Original was GL_TEXTURE_COMPARE_OPERATOR_SGIX = 0x819B
        /// </summary>
        TextureCompareOperatorSgix = 33179,
        /// <summary>
        /// Original was GL_TEXTURE_LEQUAL_R_SGIX = 0x819C
        /// </summary>
        TextureLequalRSgix = 33180,
        /// <summary>
        /// Original was GL_TEXTURE_GEQUAL_R_SGIX = 0x819D
        /// </summary>
        TextureGequalRSgix = 33181,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_CLAMP_S_SGIX = 0x8369
        /// </summary>
        TextureMaxClampSSgix = 33641,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_CLAMP_T_SGIX = 0x836A
        /// </summary>
        TextureMaxClampTSgix = 33642,
        /// <summary>
        /// Original was GL_TEXTURE_MAX_CLAMP_R_SGIX = 0x836B
        /// </summary>
        TextureMaxClampRSgix = 33643,
        /// <summary>
        /// Original was GL_TEXTURE_LOD_BIAS = 0x8501
        /// </summary>
        TextureLodBias = 34049,
        /// <summary>
        /// Original was GL_DEPTH_TEXTURE_MODE = 0x884B
        /// </summary>
        DepthTextureMode = 34891,
        /// <summary>
        /// Original was GL_TEXTURE_COMPARE_MODE = 0x884C
        /// </summary>
        TextureCompareMode = 34892,
        /// <summary>
        /// Original was GL_TEXTURE_COMPARE_FUNC = 0x884D
        /// </summary>
        TextureCompareFunc = 34893,
        /// <summary>
        /// Original was GL_TEXTURE_SWIZZLE_R = 0x8E42
        /// </summary>
        TextureSwizzleR = 36418,
        /// <summary>
        /// Original was GL_TEXTURE_SWIZZLE_G = 0x8E43
        /// </summary>
        TextureSwizzleG = 36419,
        /// <summary>
        /// Original was GL_TEXTURE_SWIZZLE_B = 0x8E44
        /// </summary>
        TextureSwizzleB = 36420,
        /// <summary>
        /// Original was GL_TEXTURE_SWIZZLE_A = 0x8E45
        /// </summary>
        TextureSwizzleA = 36421,
        /// <summary>
        /// Original was GL_TEXTURE_SWIZZLE_RGBA = 0x8E46
        /// </summary>
        TextureSwizzleRgba = 36422,
        /// <summary>
        /// Original was GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA
        /// </summary>
        DepthStencilTextureMode = 37098,
        /// <summary>
        /// Original was GL_TEXTURE_TILING_EXT = 0x9580
        /// </summary>
        TextureTilingExt = 38272
    }
}