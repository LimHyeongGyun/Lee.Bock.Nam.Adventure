using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicOnOff : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    public void AudioCtr()
    {
        float volume = audioSlider.value;
        if (volume == -40f) audioMixer.SetFloat("bgm", -80);
        else audioMixer.SetFloat("bgm", volume);
    }

    public void ToggleAuidoVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
    public void SoundOn()
    {
        //���� On ó��
        if(AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
    }
    public void SoundOff()
    {
        //���� Off ó��
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
    }
}
