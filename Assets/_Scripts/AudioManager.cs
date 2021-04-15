using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource = default;  
    [SerializeField] 
    private AudioSource ambienceSource = default;
    [SerializeField]
    private AudioClip music = default;
    private static AudioManager _instance;
    // Start is called before the first frame update  

    private bool mute = false;

    public static void PlaySFX(AudioClip audioClip)
    {
        _instance.sfxSource.PlayOneShot(audioClip);
    }
    public static void SetAmbience(AudioClip audioClip)
    {
        _instance.ambienceSource.Stop();
        _instance.ambienceSource.clip = audioClip;
        _instance.ambienceSource.Play();
    }

    public static void ToggleSound(){

        _instance.mute = !_instance.mute;
        _instance.sfxSource.mute = _instance.mute;
        _instance.ambienceSource.mute = _instance.mute;

    }
    void Awake()
   {
        _instance = this;
        if (music) {
            ambienceSource.loop = true;
            ambienceSource.clip = music;
            ambienceSource.Play();
        }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
