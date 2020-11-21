using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Slider Sensetivity, Sound, Effects;
    public Dropdown Move, View, Language;

    // Executors
    public AudioMixer Mixer;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void CheckSets()
    {
        player.Sensitivity = (int)Sensetivity.value;
        Mixer.SetFloat("SoundVolume", Sound.value);
        Mixer.SetFloat("EffectsVolume", Effects.value);
        // player.MoveMode = ;
    }
}
