using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACommeAkuma
{
    namespace PirateGrog
    {
        /// <summary>
        /// Bastien Prigent
        /// </summary>
        public class PGAudioSource : Singleton<PGAudioSource>
        {
            private void Awake()
            {
                CreateSingleton(true);
            }

            [Header("AudioSources")]
            public AudioSource[] sourceList;

            public void PlayBeerLiquid()
            {
                sourceList[0].Play();
            }


            public void PlayBeerTapSound()
            {
                sourceList[1].Play();
            }

            public void StopBeerLiquid()
            {
                sourceList[0].Stop();
            }

            public void StopBeerTapSound()
            {
                sourceList[1].Stop();
            }
        }
    }
}