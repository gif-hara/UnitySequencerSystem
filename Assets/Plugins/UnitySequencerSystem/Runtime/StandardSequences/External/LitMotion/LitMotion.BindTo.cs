#if USS_SUPPORT_LIT_MOTION
using LitMotion;
using LitMotion.Adapters;
using UnityEngine;

namespace UnitySequencerSystem.LitMotion
{
    public interface IBindTo<TValue, TOptions, TAdapter>
        where TValue : unmanaged
        where TOptions : unmanaged, IMotionOptions
        where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
    {
        MotionHandle Bind(MotionBuilder<TValue, TOptions, TAdapter> motionBuilder, Container container);
    }

    public interface IBindToVector3 : IBindTo<Vector3, NoOptions, Vector3MotionAdapter>
    {
    }

    public interface IBindToVector2 : IBindTo<Vector2, NoOptions, Vector2MotionAdapter>
    {
    }
}
#endif
