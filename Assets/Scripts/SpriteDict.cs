using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SpriteDict")]
public class SpriteDict : ScriptableObject
{
    public List<NamedSprite> NamedSprites;

    public Sprite GetSprite(string name)
    {
        foreach (var namedSprite in NamedSprites)
        {
            if (namedSprite.Name == name)
                return namedSprite.Sprite;
        }

        return null;
    }
}
