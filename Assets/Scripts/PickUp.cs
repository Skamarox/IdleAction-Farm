using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Pack pack;
    private BackPack backPack;

    private void Start()
    {
        backPack = FindObjectOfType<BackPack>();
    }

    public void SetPack(Pack pack)
    {
        this.pack = pack; 
    }

    public Pack GetPack()
    {
        return pack;
    }

    public bool CheckPack(Pack pack)
    {
        if (this.pack = pack)
            return true;
        return false;
    }

    public void Pick() 
    {
        if (pack != null && backPack.IsFull() == false)
        {
            pack.MoveInBackPack();
        }
    }
}
