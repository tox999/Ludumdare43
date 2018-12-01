using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MouseActions : MonoBehaviour {

    [SerializeField]
    string settingsPath = "Assets/Data/Settings";
    Settings settings;

    KeyCode Action1;

    // Use this for initialization
    void Awake ()
    {
        settings = settings ?? AssetDatabase.LoadAssetAtPath<Settings>(settingsPath);
        Action1 = settings.Action1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(Action1))
        {
            //do action

        }
    }
}
