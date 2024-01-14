namespace UnitySequencerSystem.Resolvers
{
    public interface IResolver<T>
    {
        T Resolve(Container container);
    }
}
