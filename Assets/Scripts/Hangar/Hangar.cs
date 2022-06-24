using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    private Transform myTransform;
    private Transform player;
    [SerializeField] private float RangeForDrop = 6f;
    private BackPack backPack;
    private Queue<Pack> packs = new Queue<Pack>();

    private void Start()
    {
        myTransform = transform;
        backPack = FindObjectOfType<BackPack>();
        player = Player.Instance.transform;
        StartCoroutine(MovePackInHangar());
    }

    private IEnumerator MovePackInHangar() 
    {
        while(true)
        {
            float distance = Vector3.Distance(myTransform.position, player.position);
            if(distance < RangeForDrop)
            {
                packs = backPack.GetPack();
                while(packs.Count > 0)
                {
                    packs.Dequeue().DropInHangar(transform, 4f);
                    yield return new WaitForSeconds(0.1f);
                }
            }
            yield return null;
        }
    }
}
