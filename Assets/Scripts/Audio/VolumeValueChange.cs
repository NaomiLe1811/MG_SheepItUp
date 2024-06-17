using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource musicSource;

    void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        musicSource = MusicManager.instance.audioSource;
        musicSlider.value = musicSource.volume;
    }

    void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
    }
}
