namespace HK.UnitySequencerSystem.Resolvers
{
    /// <summary>
    /// データ取得を行うインターフェイス
    /// </summary>
    public interface IResolver<T>
    {
        /// <summary>
        /// データを取得する
        /// </summary>
        T Resolve(Container container);
    }
}
