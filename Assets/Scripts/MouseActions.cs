﻿using System.Collections;
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


    public GameObject AttachedObject;

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

        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
    }

    public void Attach(GameObject attachedObject)
    {
        AttachedObject = attachedObject;
        tongue.SetActive(true);
        mimics.ChangeFace("lick");
        this.AttachedObject.GetComponent<SpriteSwitcher>().ChangeSprite("falling");
    }

    public void Drop()
    {

        // start some effect
        //Debug.Log("DropFromHand");
        AttachedObject = null;
        tongue.SetActive(false);
        mimics.ChangeFaceToCurrent();
    }


    public void AttachedEaten(GameObject attachedObject)
    {
        if (this.AttachedObject == attachedObject)
        {
            this.AttachedObject = null;
            tongue.SetActive(false);
            mimics.ChangeFace("default");
        }
    }



    //not used
    public void ThrowAttached(GameObject attachedObject)
    {
        // start Some effect ...

        AttachedObject = null;
        tongue.SetActive(false);
        mimics.ChangeFace("default");
    }

    public void EatAttached(GameObject attachedObject)
    {
        AttachedObject = null;
    }

}
