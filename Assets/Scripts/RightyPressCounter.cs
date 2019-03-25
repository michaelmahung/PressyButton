using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


//The purpose of this script is to increment the rightyPresses variable and update the button text.
//This script will also be responsible for activating the achievement checking for the right button.
public class RightyPressCounter : MonoBehaviour {


	private Text thisText;

	void Start () {

		thisText = GetComponentInChildren<Text> ();
	}

	public void rightyPressed ()
	{
        //This function increases the value of rightyPresses by 1, then saves the new value to memory.
        //Afterwards, it updates the text attached to the button and runs the achievement checker.
        GameManager.Instance.rightyPresses += 1;
		PlayerPrefs.SetInt ("Button 2", GameManager.Instance.rightyPresses);
		thisText.text = "" + GameManager.Instance.rightyPresses;
		checkAchiev ();
	}
				
	void checkAchiev ()
	{
        //This switch statement will only run at preset values.
        //Those values being the achievement milestones for the game.
        //Each achievement has its own case set for it.

		switch (GameManager.Instance.rightyPresses) 
		{
		case 1000000:
			Social.ReportProgress (GameManager.Instance.rObsession, 100, (bool success) => {
			});
			break;
		case 500000:
			Social.ReportProgress (GameManager.Instance.rManiac, 100, (bool success) => {
			});
			break;
		case 200000:
			Social.ReportProgress (GameManager.Instance.rFanatic, 100, (bool success) => {
			});
			break;
		case 100000:
			Social.ReportProgress (GameManager.Instance.rEnthusiast, 100, (bool success) => {
			});
			break;
		case 50000:
			Social.ReportProgress (GameManager.Instance.r50000, 100, (bool success) => {
			});
			break;
		case 40000:
			Social.ReportProgress (GameManager.Instance.r40000, 100, (bool success) => {
			});
			break;
		case 30000:
			Social.ReportProgress (GameManager.Instance.r30000, 100, (bool success) => {
			});
			break;
		case 20000:
			Social.ReportProgress (GameManager.Instance.r20000, 100, (bool success) => {
			});
			break;
		case 10000:
			Social.ReportProgress (GameManager.Instance.r10000, 100, (bool success) => {
			});
			break;
		case 5000:
			Social.ReportProgress (GameManager.Instance.r5000, 100, (bool success) => {
			});
			break;
		case 2000:
			Social.ReportProgress (GameManager.Instance.r2000, 100, (bool success) => {
			});
			break;
		case 500:
			Social.ReportProgress (GameManager.Instance.r500, 100, (bool success) => {
			});
			break;
		case 100:
			Social.ReportProgress (GameManager.Instance.r100, 100, (bool success) => {
			});
			break;
		default:
			{}
			break;
		}
	}

}
