using System;
using UnityEngine;

namespace HK.UnitySequencerSystem.Resolvers
{
    public abstract class Vector3Resolver : IResolver<Vector3>
    {
        public abstract Vector3 Resolve(Container container);

        [Serializable]
        public sealed class Constant : Vector3Resolver
        {
            [SerializeField]
            private Vector3 value;

            public override Vector3 Resolve(Container container)
            {
                return value;
            }
        }

        [Serializable]
        public sealed class NameVector3 : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public override Vector3 Resolve(Container container)
            {
                return container.Resolve<Vector3>(name);
            }
        }

        [Serializable]
        public sealed class ReferenceTransform : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            [SerializeField]
            private CoordinateType coordinateType;

            public enum CoordinateType
            {
                World,
                Local,
            }

            public override Vector3 Resolve(Container container)
            {
                return coordinateType switch
                {
                    CoordinateType.World => target.position,
                    CoordinateType.Local => target.localPosition,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
        }

        [Serializable]
        public sealed class NameTransform : Vector3Resolver
        {
            [SerializeField]
            private string name;

            [SerializeField]
            private CoordinateType coordinateType;

            public enum CoordinateType
            {
                World,
                Local,
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return coordinateType switch
                {
                    CoordinateType.World => target.position,
                    CoordinateType.Local => target.localPosition,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
        }
    }
}
