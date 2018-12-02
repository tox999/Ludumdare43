using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MouseActions : MonoBehaviour {

    [SerializeField]
    string settingsPath = "Assets/Data/Settings.asset";
    [SerializeField]
    GameObject tongue;
    [SerializeField]
    Mimics mimics;
    Settings settings;

    GameObject attachedObject;

    [HideInInspector]
    public KeyCode Action1 = KeyCode.Mouse0;

    // Use this for initialization
    void Awake ()
    {
        
        //settings = AssetDatabase.LoadAssetAtPath<Settings>(settingsPath);
        //Action1 = settings.Action1;
    }

    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetKey(Action1))
        //{
        //    Drop(attachedObject);

        //}
    }

    public void Attach(GameObject attachedObject)
    {
        this.attachedObject = attachedObject;
        tongue.SetActive(true);
        mimics.ChangeFace("lick");
    }

    public void Drop(GameObject attachedObject)
    {
        // start some effect
        Debug.Log("DropFromHand");
        this.attachedObject = null;
        tongue.SetActive(false);
        mimics.ChangeFace("default");
    }

    public void ThrowAttached(GameObject attachedObject)
    {
        // start Some effect ...

        this.attachedObject = null;
        tongue.SetActive(false);
        mimics.ChangeFace("default");
    }

    public void EatAttached(GameObject attachedObject)
    {
        this.attachedObject = null;
    }
}
