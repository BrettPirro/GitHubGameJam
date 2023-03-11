using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.AudioSystems 
{
    public class InitalAudioForScene : MonoBehaviour
    {
        [SerializeField] AudioClip AmbientAudio;
        private void Start()
        {
            if (AmbientAudio == null)
            {
                Debug.LogWarning("This Scene is lacking ambient music go find the obj that set it in scene");
            }
            else
            {
                AudioManager ambientAudioMan = FindObjectOfType<AudioManager>();

                ambientAudioMan.ChangeAmbientAudio(AmbientAudio);
            }

        }

    }
}
