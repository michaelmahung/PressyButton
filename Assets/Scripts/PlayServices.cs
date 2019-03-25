using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class PlayServices : MonoBehaviour {


	void Start () {

		#if UNITY_ANDROID

		if (!Social.localUser.authenticated)
		{

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

		Social.localUser.Authenticate ((bool success) => {
			if (success)
			{
				Debug.Log ("Authentication Successful");
			} else {Debug.Log ("Authentication Unsucessful");}
		});
		}

		//loadAchievements ();
			

		#endif


		#if UNITY_IPHONE

		GameCenterPlatform.ShowDefaultAchievementCompletionBanner (true);

		if (!Social.localUser.authenticated) 
		{
			Social.localUser.Authenticate ((bool success) => 
		{
			if (success)
			{
			Debug.Log ("Authentication Successful");
			} else {Debug.Log ("Authentication Unsucessful");}
		});
		}


		#endif
	
		}

	/*public void loadAchievements ()
	{
		Social.LoadAchievements(achievements => {
			if (achievements.Length > 0)
			{
				Debug.Log("Got " + achievements.Length + " achievement instances");
				string myAchievements = "My achievements:\n";
				foreach (IAchievement achievement in achievements)
				{
					myAchievements += "\t" +
						achievement.id + " " +
						achievement.percentCompleted + " " +
						achievement.completed + " " +
						achievement.lastReportedDate + "\n";
				}
				Debug.Log(myAchievements);
			}
			else
				Debug.Log("No achievements returned");
		});

		Social.LoadAchievementDescriptions(descriptions => {
			if (descriptions.Length > 0)
			{
				Debug.Log("Got " + descriptions.Length + " achievement descriptions");
				string achievementDescriptions = "Achievement Descriptions:\n";
				foreach (IAchievementDescription ad in descriptions)
				{
					achievementDescriptions += "\t" +
						ad.id + " " +
						ad.title + " " +
						ad.unachievedDescription + "\n";
				}
				Debug.Log(achievementDescriptions);
			}
			else
				Debug.Log("Failed to load achievement descriptions");
		});
	}*/


}
