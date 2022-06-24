using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureDead : MonoBehaviour
{
    private int RespawnTime = 3;
    private CultureCut cultureCut;


    private void Start()
    {
        cultureCut = GetComponent<CultureCut>();
    }

    public void SetProperty(int Respawntime)
    {
        this.RespawnTime = Respawntime;
    }

    public void Dead() 
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        Vector3 Scale = transform.localScale;
        transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(RespawnTime);
        transform.localScale = Scale;
        cultureCut.Respawn();
    }
}
