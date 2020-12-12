using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACommeAkuma
{
    namespace SaveThePirate
    {
        /// <summary>
        /// PARET Paul
        /// </summary>
        public class AudioManagerScript : MonoBehaviour
        {
            [Header("AudioSources")]
            public AudioSource[] sourceList;

            public void PlayExploVFX()
            {
                sourceList[0].Play();
            }

        }
    }
}

