using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Slider Sensetivity, Sound, Effects;
    public Dropdown Move, View;

    // Executors
    public AudioMixer Mixer;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void ApplySets()
    {
        player.Sensitivity = (int)Sensetivity.value;
        Mixer.SetFloat("SoundVolume", Sound.value);
        Mixer.SetFloat("EffectsVolume", Effects.value);
        player.MoveMode = (PlayerController.moveMode)Move.value;
        player.ViewMode = (PlayerController.viewMode)View.value;
    }

    public void LoadSets()
    {
        PlayerPrefs.GetInt("Sensetivity", (int)Sensetivity.value);
        PlayerPrefs.GetFloat("Sound", Sound.value);
        PlayerPrefs.GetFloat("Effects", Effects.value);
        PlayerPrefs.GetInt("Move", Move.value);
        PlayerPrefs.GetInt("View", View.value);
    }

    public void SaveSets()
    {
        PlayerPrefs.SetInt("Sensetivity", (int)Sensetivity.value);
        PlayerPrefs.SetFloat("Sound", Sound.value);
        PlayerPrefs.SetFloat("Effects", Effects.value);
        PlayerPrefs.SetInt("Move", Move.value);
        PlayerPrefs.SetInt("View", View.value);
    }
}
