using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour {

    [SerializeField]
    SpriteDict NamedSprites;

    public string CurrentSprite = "default";
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(string newSpriteName)
    {
        Debug.Log(string.Format("Will change sprite from {0} to {1}", CurrentSprite, newSpriteName));
        var newSprite = NamedSprites.GetSprite(newSpriteName);
        if (newSprite == null)
        {
            Debug.LogError("New sprite is null; probabbly invalid sprite name: " + newSpriteName);
            return;
        }

        CurrentSprite = newSpriteName;
        spriteRenderer.sprite = newSprite;
    }
}
