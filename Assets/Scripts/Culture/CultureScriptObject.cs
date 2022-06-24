using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Culture", menuName = "Custom Objects/Culture")]
public class CultureScriptObject : ScriptableObject
{
    public GameObject Prefab;
    public float RangeForHit;
    public int HitCount;
    public int RespawnTime;
}
