using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class ButtonOptions : MonoBehaviour {

	public GameObject connectButton;
	private Image cbImage;
	private Int64 lPresses;
	private Int64 rPresses;
	private Int64 tPresses;
	private Text buttonText;
	private bool quitting = false;
	private bool lSent = false;
	private bool tSent = false;
	private bool rSent = false;
    private Image buttonColor;

	void Start ()
	{
		//PlayerPrefs.DeleteAll ();
		buttonText = GetComponentInChildren <Text> ();
		cbImage = connectButton.GetComponent <Image> ();
        buttonColor = GetComponent<Image>();
		quitting = false;
	}

	public void leaderboards ()
	{
		Social.ShowLeaderboardUI ();
	}

	public void achievements ()
	{
		Social.ShowAchievementsUI ();
	}

	public void signIn ()
	{
#if UNITY_ANDROID

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate ((bool success) => {
            if (success)
            {
                Debug.Log("Authentication Successful");
            }
		});
#endif

#if UNITY_IPHONE

            Social.localUser.Authenticate ((bool success) => {
			if (success)
			{
				Debug.Log ("Authentication Successful");
			} else {Debug.Log ("Authentication Unsucessful");}
		});

#endif

        if (Social.localUser.authenticated) {
			cbImage.color = Color.green;
		}
		else {cbImage.color = Color.red;}
	}

	public void Quit ()
	{
        reportLeft();
        reportRight();
        reportTotal();
        StartCoroutine (quitGame ());
	}

	public void reportLeft ()
	{
		if (!lSent) {

			lPresses = Convert.ToInt64 (GameManager.Instance.leftyPresses);

			Social.ReportScore (lPresses, GameManager.Instance.leftyScores, (bool success) => {
				if (success) {
                    lSent = true;
                    buttonColor.color = Color.green;
				} else {
                    buttonColor.color = Color.red;
				}
			});
		} else {
		}
	}

	public void reportRight ()
	{
		if (!rSent) {

			rPresses = Convert.ToInt64 (GameManager.Instance.rightyPresses);

			Social.ReportScore (rPresses, GameManager.Instance.rightyScores, (bool success) => {
				if (success) {
                    rSent = true;
                    buttonColor.color = Color.green;
				} else {
                    buttonColor.color = Color.red;
				}
			});
		} else {
		}
	}

	public void reportTotal ()
	{
		if (!tSent) {

			tPresses = Convert.ToInt64 (GameManager.Instance.leftyPresses + GameManager.Instance.rightyPresses);

			Social.ReportScore (tPresses, GameManager.Instance.totalScores, (bool success) => {
				if (success) {
                    tSent = true;
                    buttonColor.color = Color.green;
				} else {
                    buttonColor.color = Color.red;
				}
			});
		} else {
		}
	}
	IEnumerator quitGame ()
	{
        if (!quitting)
        {
            quitting = true;
            buttonText.text = "3";
            yield return new WaitForSeconds(1);
            buttonText.text = "2";
            yield return new WaitForSeconds(1);
            buttonText.text = "1";
            yield return new WaitForSeconds(1);
            buttonText.text = "Quitting";
            yield return new WaitForSeconds(1);
            Application.Quit();
        }
        else { }
	}
}




