using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHolder : MonoBehaviour {

    public Texture2D ButtonImage;
    public AudioClip[] ButtonClips;
    public ButtonData data;
    private RawImage image;
	private PressImpact pressImpact;

	void Start ()
	{
        pressImpact = GameObject.FindObjectOfType<PressImpact>();
        image = GetComponentInChildren<RawImage>();
        ButtonImage = data.ButtonImage;
        ButtonClips = data.ButtonAudioClips;
        image.texture = ButtonImage;
	}

    public void PressedButton()
    {
        pressImpact.SetData(ButtonImage, ButtonClips);
    }
}
