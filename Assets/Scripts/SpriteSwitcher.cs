using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour {
    /*
    [SerializeField]
    SpriteDict NamedSprites;

    public string CurrentSpriteName = "default";
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(string newSpriteName)
    {
        Debug.Log(string.Format("Will change sprite from {0} to {1}", CurrentSpriteName, newSpriteName));
        var newSprite = NamedSprites.GetSprite(newSpriteName);
        if (newSprite == null)
        {
            Debug.LogError("New sprite is null; probabbly invalid sprite name: "
                + newSpriteName + " in object: " + transform.parent.name + "_" + gameObject.name);
            return;
        }

        CurrentSpriteName = newSpriteName;
        spriteRenderer.sprite = newSprite;
    }*/
}
