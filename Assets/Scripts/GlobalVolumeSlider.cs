using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeSlider : MonoBehaviour {

	private Slider volumeSlider;

    void Start()
    {
		volumeSlider = GetComponent<Slider>();
		volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(delegate {ChangeGlobalVolume(); });
    }

	void Update()
	{
		volumeSlider.value = AudioListener.volume;
	}

    void ChangeGlobalVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
