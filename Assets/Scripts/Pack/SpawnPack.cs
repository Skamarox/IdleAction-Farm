using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPack
{
    public static void Spawn(PackScriptObject pack, Transform transform, Marker marker) 
    {
        Pack p = Object.Instantiate(pack.pack, transform.position, pack.pack.transform.rotation);
        p.SetProperty(pack.StackValue, marker, pack.GoldValue);
        p.Drop(Player.Instance.transform);
    }
}
