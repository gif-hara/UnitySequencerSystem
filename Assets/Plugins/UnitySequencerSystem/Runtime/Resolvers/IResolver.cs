namespace UnitySequencerSystem.Resolvers
{
    /// <summary>
    /// Represents a resolver interface that resolves a type T using a container.
    /// </summary>
    /// <typeparam name="T">The type to be resolved.</typeparam>
    public interface IResolver<T>
    {
        /// <summary>
        /// Resolves the specified type T using the given container.
        /// </summary>
        /// <param name="container">The container used for resolving.</param>
        /// <returns>The resolved instance of type T.</returns>
        T Resolve(Container container);
    }
}
