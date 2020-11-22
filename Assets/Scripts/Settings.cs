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
        LoadSets();
        ApplySets();
    }

    public void ApplySets()
    {
        player.Sensitivity = PlayerPrefs.GetInt("Sensetivity");
        Mixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("Sound"));
        Mixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("Effects"));
        player.MoveMode = (PlayerController.moveMode)PlayerPrefs.GetInt("Move");
        player.ViewMode = (PlayerController.viewMode)PlayerPrefs.GetInt("View");

        switch (player.MoveMode)
        {
            case PlayerController.moveMode.FixedStick:
                player.MoveStick.SetMode(JoystickType.Fixed);
                break;
            case PlayerController.moveMode.FloatingStick:
                player.MoveStick.SetMode(JoystickType.Floating);
                break;
            case PlayerController.moveMode.DynamicStick:
                player.MoveStick.SetMode(JoystickType.Dynamic);
                break;
            default:
                player.MoveStick.SetMode(JoystickType.Fixed);
                break;
        }

        player.ViewStick.gameObject.SetActive(true);
        switch (player.ViewMode)
        {
            case PlayerController.viewMode.FixedStick:
                player.ViewStick.SetMode(JoystickType.Fixed);
                break;
            case PlayerController.viewMode.FloatingStick:
                player.ViewStick.SetMode(JoystickType.Floating);
                break;
            case PlayerController.viewMode.DynamicStick:
                player.ViewStick.SetMode(JoystickType.Dynamic);
                break;
            case PlayerController.viewMode.Swipe:
                player.ViewStick.gameObject.SetActive(false);
                break;
            default:
                player.ViewStick.SetMode(JoystickType.Fixed);
                break;
        }
    }

    public void LoadSets()
    {
        Sensetivity.value = PlayerPrefs.GetInt("Sensetivity");
        Sound.value = PlayerPrefs.GetFloat("Sound");
        Effects.value = PlayerPrefs.GetFloat("Effects");
        Move.value = PlayerPrefs.GetInt("Move");
        View.value = PlayerPrefs.GetInt("View");
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
