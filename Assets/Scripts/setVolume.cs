using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject MasterSlider;
    public GameObject EfectSlider;
    public GameObject MusicSlider;


    void Start() 
    {
        MasterSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Master");
        EfectSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Efects");
        MusicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
    }

    public void SetMaster (float sliderValue)
    {
        PlayerPrefs.SetFloat("Master", sliderValue);
        mixer.SetFloat("VolMaster", Mathf.Log10(sliderValue) * 20);
    }
    public void SetEffects(float sliderValue)
    {
        PlayerPrefs.SetFloat("Efects", sliderValue);
        mixer.SetFloat("VolEfects", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusic(float sliderValue)
    {
        PlayerPrefs.SetFloat("Music", sliderValue);
        mixer.SetFloat("VolMusic", Mathf.Log10(sliderValue) * 20);
    }
}
