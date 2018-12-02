using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimics : MonoBehaviour {

    [SerializeField]
    SpriteDict Faces;

    public string CurrentFace = "Default";
    SpriteRenderer Face;
 
	// Use this for initialization
	void Awake ()
    {
        Face = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //ChangeFace(CurrentFace);
	}

    public void ChangeFace(string newFace)
    {
        
            var newSprite = Faces.GetSprite(newFace);
            if (newSprite == null)
            {
                Debug.LogError("New sprite is null; probabbly invalid face name.");
                return;
            }

            Face.sprite = newSprite ;
          
    }
}
