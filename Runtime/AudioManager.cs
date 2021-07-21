using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

/*
THANK YOU BRACKEYS
*/

namespace Basic
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public List<Sound> sounds = new List<Sound>();

        void Awake()
        {
            if (AudioManager.instance != null)
            {
                Destroy(gameObject);
                Debug.LogError("There can only be one AudioManager");
                return;
            }

            DontDestroyOnLoad(gameObject);

            AudioManager.instance = this;

            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
            }
        }

        public void Play(string _name)
        {
            Sound sound = sounds.Find(sounds => sounds.name == _name);
            if (sound != null)
                sound.source.Play();
            else
                Debug.LogError("No sound with name " + _name + " exists.");
        }
    }
}
