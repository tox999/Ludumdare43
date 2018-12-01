using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="GameSettings")]
public class Settings : ScriptableObject
{
    #region Controls
    public KeyCode Action1 = KeyCode.Mouse0;
    public KeyCode Action2 = KeyCode.Mouse1;
    #endregion
}
