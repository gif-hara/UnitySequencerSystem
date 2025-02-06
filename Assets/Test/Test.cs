using System;
using System.Collections.Generic;
using System.Threading;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#endif
using TMPro;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour
    {
        [SerializeReference, SubclassSelector]
        private ResolverProjectTestClassResolver r;
        
        async void Start()
        {
        }
    }
}
