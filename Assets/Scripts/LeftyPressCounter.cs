using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


//The purpose of this script is to increment the leftyPresses variable and update the button text.
//This script will also be responsible for activating the achievement checking for the left button.
public class LeftyPressCounter : MonoBehaviour {

	private Text thisText;

	void Start () {

        //Here were grabbing the text to change.
        thisText = GetComponentInChildren<Text>();
			
	}

	public void leftyPressed ()
	{
        //This function increases the value of leftyPresses by 1, then saves the new value to memory.
        //Afterwards, it updates the text attached to the button and runs the achievement checker.
		GameManager.Instance.leftyPresses += 1;
		PlayerPrefs.SetInt ("Button 1", GameManager.Instance.leftyPresses);
		thisText.text = "" + GameManager.Instance.leftyPresses;
		checkAchiev ();
	}
		
	void checkAchiev ()
	{
        //This switch statement will only run at preset values.
        //Those values being the achievement milestones for the game.
        //Each achievement has its own case set for it.

        switch (GameManager.Instance.leftyPresses) 
		{
		case 1000000:
			Social.ReportProgress (GameManager.Instance.lObsession, 100, (bool success) => {
			});
			break;
		case 500000:
			Social.ReportProgress (GameManager.Instance.lManiac, 100, (bool success) => {
			});
			break;
		case 200000:
			Social.ReportProgress (GameManager.Instance.lFanatic, 100, (bool success) => {
			});
			break;
		case 100000:
			Social.ReportProgress (GameManager.Instance.lEnthusiast, 100, (bool success) => {
			});
			break;
		case 50000:
			Social.ReportProgress (GameManager.Instance.l50000, 100, (bool success) => {
			});
			break;
		case 40000:
			Social.ReportProgress (GameManager.Instance.l40000, 100, (bool success) => {
			});
			break;
		case 30000:
			Social.ReportProgress (GameManager.Instance.l30000, 100, (bool success) => {
			});
			break;
		case 20000:
			Social.ReportProgress (GameManager.Instance.l20000, 100, (bool success) => {
			});
			break;
		case 10000:
			Social.ReportProgress (GameManager.Instance.l10000, 100, (bool success) => {
			});
			break;
		case 5000:
			Social.ReportProgress (GameManager.Instance.l5000, 100, (bool success) => {
			});
			break;
		case 2000:
			Social.ReportProgress (GameManager.Instance.l2000, 100, (bool success) => {
			});
			break;
		case 500:
			Social.ReportProgress (GameManager.Instance.l500, 100, (bool success) => {
			});
			break;
		case 100:
			Social.ReportProgress (GameManager.Instance.l100, 100, (bool success) => {
			});
			break;
		default:
			{}
			break;
		}

	}

}
