using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pack", menuName = "Custom Objects/Pack")]
public class PackScriptObject : ScriptableObject
{
    public Pack pack;
    public int StackValue;
    public int GoldValue;
    public float Range;
}
