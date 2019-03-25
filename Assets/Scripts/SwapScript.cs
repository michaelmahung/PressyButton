using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapScript : MonoBehaviour {

	public GameObject swapPanel;
	public static bool panelOut;

	void Start () {

		swapPanel.SetActive (false);
	}

	public void openPanel ()
	{
		swapPanel.SetActive (true);
		panelOut = true;
	}

	public void closePanel ()
	{
		swapPanel.SetActive (false);
		panelOut = false;
	}

}
