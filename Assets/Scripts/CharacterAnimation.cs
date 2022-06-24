using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation
{
    private static Animator anim;
    private static Animator animator
    {
        get
        {
            if(anim == null)
                anim = Object.FindObjectOfType<Animator>();
            return anim;
        }
    }

    public static void SetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }
}
