using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressImpact : MonoBehaviour {

	public GameObject pressObject;
	public Texture2D pressImage;
    public AudioClip[] audioClips;
    private RawImage pressObjectImage;
    private AudioSource pressAudio;
    private int clipIndex;

    void Start ()
	{
        clipIndex = 0;
		pressAudio = GetComponent <AudioSource> ();
        pressObjectImage = pressObject.GetComponentInChildren<RawImage>();
		pressObject.SetActive (false);
	}
		
	void Update () {
		if (Input.GetMouseButtonDown (0) && !SwapScript.panelOut) {
			Vector2 touchPos = Input.mousePosition;
			pressPosition (touchPos);
			playSound ();
		}
	}

    public void SetData(Texture2D image, AudioClip[] clips)
    {
        pressImage = image;
        audioClips = clips;
        pressObjectImage.texture = pressImage;
        clipIndex = 0;
        pressAudio.clip = clips[clipIndex];
    }

	void pressPosition (Vector2 touchPos)
	{
		pressObject.SetActive (true);
		pressObject.transform.position = new Vector3 (touchPos.x, touchPos.y, 0);
		Invoke ("pressed", 0.25f);
	}

	void pressed ()
	{
		pressObject.SetActive (false);
	}
		

	void playSound ()
	{
        if (audioClips.Length > 1)
        {
            if (clipIndex < audioClips.Length)
            {
                pressAudio.clip = audioClips[clipIndex];
                pressAudio.Play();
            }else
            {
                clipIndex = 0;
                pressAudio.clip = audioClips[clipIndex];
                pressAudio.Play();
            }
            clipIndex++;
        } else
        {
            pressAudio.Play();
        }
	}
		
}
