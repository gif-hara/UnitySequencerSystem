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
        MotionHandle BindTo(MotionBuilder<TValue, TOptions, TAdapter> motionBuilder, Container container);
    }

    public interface IBindToRect : IBindTo<Rect, NoOptions, RectMotionAdapter>
    {
    }
}
#endif
