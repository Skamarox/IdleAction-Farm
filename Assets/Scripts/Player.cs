using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static GameObject player;
    public static GameObject Instance 
    {
        get
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag("Player");
            return player;
        }
    }
}
