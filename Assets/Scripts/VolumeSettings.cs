using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    void Awake()
    {
        masterSlider.minValue = 0.0001f;
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.minValue = 0.0001f;
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.minValue = 0.0001f;
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);


    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20.0f);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20.0f);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20.0f);
    }

}
