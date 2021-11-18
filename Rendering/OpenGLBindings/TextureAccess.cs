namespace OpenGLBindings
{
    /// <summary>
    /// Used in GL.BindImageTexture
    /// </summary>
    public enum TextureAccess
    {
        /// <summary>
        /// Original was GL_READ_ONLY = 0x88B8
        /// </summary>
        ReadOnly = 35000,
        /// <summary>
        /// Original was GL_WRITE_ONLY = 0x88B9
        /// </summary>
        WriteOnly,
        /// <summary>
        /// Original was GL_READ_WRITE = 0x88BA
        /// </summary>
        ReadWrite
    }
}