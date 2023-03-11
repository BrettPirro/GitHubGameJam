using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.AudioSystems 
{
    public class AudioManager : MonoBehaviour
    {
        AudioSource AudSource;



        private void Awake()
        {
            AudSource = GetComponent<AudioSource>();
        }

        public IEnumerator AudioFadeOut(float time)
        {
            while (AudSource.volume != 0)
            {

                AudSource.volume -= Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator AudioFadeIn(float time)
        {
            while (AudSource.volume != 1)
            {

                AudSource.volume += Time.deltaTime / time;
                yield return null;
            }
        }

        public void ChangeAmbientAudio(AudioClip audioClip)
        {
            AudSource.clip = audioClip;
            AudSource.Play();
        }



        public static AudioSource PlayClipAt(AudioClip clip, Vector3 pos, float spatialBlend, float volume)
        {
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = pos;
            AudioSource aSource = tempGO.AddComponent<AudioSource>();
            aSource.clip = clip;
            aSource.spatialBlend = spatialBlend;
            aSource.volume = volume;
            aSource.Play();
            Destroy(tempGO, clip.length);
            return aSource;
        }

    }

}
