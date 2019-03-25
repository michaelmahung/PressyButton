using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#if UNITY_IPHONE
using UnityEngine.SocialPlatforms.GameCenter;
#endif


//Remember that when calling variables from the GameManager, you need to add Gamemanager.Instance, or else it will not be able to find the variable you are looking for.
//One thing to note is that with this approach, the GameManager object will not be created until it is called for the first time.

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    //Here we are creating a publicly accessable version of the GameManager instance.
    //We will tell the script that if no such object exists, to create one, or otherwise simply use the current instance as the one active instance.
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }

    }

    //Next we create our variables. Because theyre all public properties, it uses less memory than static variables with the same global access.
    public int rightyPresses { get; set; }
    public int totalPresses { get; set; }
    public int leftyPresses { get; set; }
    public string l100 { get; private set; }
    public string r100 { get; private set; }
    public string l500 { get; private set; }
    public string r500 { get; private set; }
    public string l2000 { get; private set; }
    public string r2000 { get; private set; }
    public string l5000 { get; private set; }
    public string r5000 { get; private set; }
    public string l10000 { get; private set; }
    public string r10000 { get; private set; }
    public string l20000 { get; private set; }
    public string r20000 { get; private set; }
    public string l30000 { get; private set; }
    public string r30000 { get; private set; }
    public string l40000 { get; private set; }
    public string r40000 { get; private set; }
    public string l50000 { get; private set; }
    public string r50000 { get; private set; }
    public string lEnthusiast { get; private set; }
    public string rEnthusiast { get; private set; }
    public string lFanatic { get; private set; }
    public string rFanatic { get; private set; }
    public string lManiac { get; private set; }
    public string rManiac { get; private set; }
    public string lObsession { get; private set; }
    public string rObsession { get; private set; }
    public string leftyScores { get; private set; }
    public string rightyScores { get; private set; }
    public string totalScores { get; private set; }

    void Awake ()
    {
        //When the instance is created we need to generate our playerprefs.
        if (PlayerPrefs.HasKey("Button 2"))
        {
            rightyPresses = PlayerPrefs.GetInt("Button 2");
        }
        else
        {
            rightyPresses = 0;
        }

        if (PlayerPrefs.HasKey("Button 1"))
        {
            leftyPresses = PlayerPrefs.GetInt("Button 1");
        }
        else
        {
            leftyPresses = 0;
        }

        _instance = this;
    }

    void Start()
    {

    //Next we can set our achievement and leaderboard ID's according to the device being used. 

    #if UNITY_ANDROID

        l100 = "CgkI3Yj6pOYLEAIQAQ";
        r100 = "CgkI3Yj6pOYLEAIQAg";
        l500 = "CgkI3Yj6pOYLEAIQCg";
        r500 = "CgkI3Yj6pOYLEAIQCw";
        l2000 = "CgkI3Yj6pOYLEAIQDg";
        r2000 = "CgkI3Yj6pOYLEAIQDw";
        l5000 = "CgkI3Yj6pOYLEAIQFA";
        r5000 = "CgkI3Yj6pOYLEAIQFQ";
        l10000 = "CgkI3Yj6pOYLEAIQIA";
        r10000 = "CgkI3Yj6pOYLEAIQIQ";
        l20000 = "CgkI3Yj6pOYLEAIQKA";
        r20000 = "CgkI3Yj6pOYLEAIQKQ";
        l30000 = "CgkI3Yj6pOYLEAIQLA";
        r30000 = "CgkI3Yj6pOYLEAIQLQ";
        l40000 = "CgkI3Yj6pOYLEAIQLg";
        r40000 = "CgkI3Yj6pOYLEAIQLw";
        l50000 = "CgkI3Yj6pOYLEAIQMA";
        r50000 = "CgkI3Yj6pOYLEAIQMQ";
        lEnthusiast = "CgkI3Yj6pOYLEAIQNA";
        rEnthusiast = "CgkI3Yj6pOYLEAIQNQ";
        lFanatic = "CgkI3Yj6pOYLEAIQNg";
        rFanatic = "CgkI3Yj6pOYLEAIQNw";
        lManiac = "CgkI3Yj6pOYLEAIQOA";
        rManiac = "CgkI3Yj6pOYLEAIQOQ";
        lObsession = "CgkI3Yj6pOYLEAIQOg";
        rObsession = "CgkI3Yj6pOYLEAIQOw";
        leftyScores = "CgkI3Yj6pOYLEAIQBQ";
        rightyScores = "CgkI3Yj6pOYLEAIQBg";
        totalScores = "CgkI3Yj6pOYLEAIQBw";

    #endif

    #if UNITY_IPHONE

		l100 = "grp.l100";
		r100 = "grp.r100";
		l500 = "grp.l500";
		r500 = "grp.r500";
		l2000 = "grp.l2000";
		r2000 = "grp.r2000";
		l5000 = "grp.l5000";
		r5000 = "grp.r5000";
		l10000 = "grp.l10000";
		r10000 = "grp.r10000";
		l20000 = "grp.l20000";
		r20000 = "grp.r20000";
		l30000 = "grp.l30000";
		r30000 = "grp.r30000";
		l40000 = "grp.l40000";
		r40000 = "grp.r40000";
		l50000 = "grp.l50000";
		r50000 = "grp.r50000";
		lEnthusiast = "grp.lEnthusiast";
		rEnthusiast = "grp.rEnthusiast";
		lFanatic = "grp.lFanatic";
		rFanatic = "grp.rFanatic";
		lManiac = "grp.lManiac";
		rManiac = "grp.rManiac";
		lObsession = "grp.lObsession";
		rObsession = "grp.rObsession";
		leftyScores = "grp.leftyPresses";
		rightyScores = "grp.rightyPresses";
		totalScores = "grp.totalPresses";



    #endif
    }

}
