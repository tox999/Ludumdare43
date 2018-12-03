using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimics : MonoBehaviour {

    [SerializeField]
    SpriteDict Faces;

    public string CurrentFace = "default";
    SpriteRenderer spriteRenderer;
 
	// Use this for initialization
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //ChangeFace(CurrentFace);
    }

    public void ChangeFace(string newFace)
    {
<<<<<<< HEAD
        //Debug.Log("Change face: " + newFace);
=======
>>>>>>> f91522b4fcbd6512d0b8f7452ba5aee6697a760e
        var newSprite = Faces.GetSprite(newFace);
        if (newSprite == null)
        {
            Debug.LogError("New sprite is null; probabbly invalid face name.");
            return;
        }
        
        CurrentFace = newFace;
        spriteRenderer.sprite = newSprite;
            
    }
}
