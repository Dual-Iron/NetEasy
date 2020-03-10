using System;

namespace NetEasy
{
    /// <summary>Thrown during loading an invalid <see cref="Module"/>.</summary>
    [Serializable]
    public class ModuleLoadException : Exception
    {
        /// <inheritdoc/>
        public ModuleLoadException() : base("An error occurred while loading.") { }
        /// <inheritdoc/>
        public ModuleLoadException(string message) : base(message) { }
        /// <inheritdoc/>
        public ModuleLoadException(string message, Type type) : base(message + " (offending type: " + type.FullName + ")") { }
        /// <inheritdoc/>
        public ModuleLoadException(string message, Exception inner) : base(message, inner) { }
        /// <inheritdoc/>
        protected ModuleLoadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
