using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SpriteDict")]
public class SpriteDict : ScriptableObject
{
    public List<NamedSprite> NamedSprites;
}

[Serializable]
public class NamedSprite
{
    public string Name;
    public Sprite Sprite;
}
