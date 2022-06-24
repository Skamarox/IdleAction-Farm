using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum Animation { Idle, Run, Cut }
    private static Animation stateType = Animation.Idle;

    public static void SetState(Animation type, bool value)
    {
        stateType = type;
        StateController(value);
    }

    public static Animation GetState() 
    {
        return stateType;
    }

    private static void StateController(bool value) 
    {
        switch(stateType)
        {
            case Animation.Idle:
                CharacterAnimation.SetBool("Idle", value);
                break;

            case Animation.Run:
                CharacterAnimation.SetBool("Idle", value);
                break;

            case Animation.Cut:
                CharacterAnimation.SetBool("Cut", value);
                break;
        }
    }

}
