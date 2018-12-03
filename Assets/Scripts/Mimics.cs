using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimics : MonoBehaviour {

    [SerializeField]
    SpriteDict Faces;

    public string CurrentFace = "default";
    SpriteRenderer spriteRenderer;
 
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }	

    public void ChangeFace(string newFace)
    {
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
