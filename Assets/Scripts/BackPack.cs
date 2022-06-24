using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackPack : MonoBehaviour
{
    private PackCountText Score;
    private float AnimDuration = 0.15f;
    private Queue<Pack> packs = new Queue<Pack>();
    private int CurrentCountPack = 0;
    private int MaxCountPack = 40;

    private void Start()
    {
        Score = FindObjectOfType<PackCountText>();
        transform.DOLocalMoveX(-0.1f, AnimDuration).SetLoops(-1, LoopType.Yoyo);
    }

    public void AddPack(Pack pack) 
    {
        if (CurrentCountPack < MaxCountPack)
        {
            CurrentCountPack = CurrentCountPack + pack.GetStackValue();
            packs.Enqueue(pack);
            Score.ChangeScore(pack.GetStackValue());
            pack.transform.parent = transform;
            pack.transform.position = transform.position;
            pack.transform.rotation = transform.rotation;
            pack.gameObject.SetActive(false);
        }

        if(CurrentCountPack == MaxCountPack)
        {
            packs.Peek().transform.localScale = packs.Peek().GetScale();
            packs.Peek().gameObject.SetActive(true);
        }
    }

    public bool IsFull() 
    {
        if (CurrentCountPack >= MaxCountPack)
            return true;
        return false;
    }

    public void MinusPack(int pack)
    {
        CurrentCountPack = CurrentCountPack - pack;
    }

    public Queue<Pack> GetPack() 
    {
        return packs;
    }

    public void StartShake()
    {
        transform.DOPlay();
    }

    public void EndShake()
    {
        transform.DOPause();
    }
}
