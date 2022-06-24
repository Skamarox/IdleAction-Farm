using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pack : MonoBehaviour, IMarker
{
    [SerializeField] private float JumpPower = 2f;
    [SerializeField] private int JumpNumber = 1;
    [SerializeField] private float JumpDuration = 0.5f;
    private int StackValue = 10;
    private int GoldValue;
    private Material[] Materials;
    private PickUp _PickUp;
    private BackPack _BackPack;
    private Vector3 PackScale;
    private Marker _Marker;

    private void Start()
    {
        PackScale = transform.localScale;
        _BackPack = FindObjectOfType<BackPack>();
        _PickUp = FindObjectOfType<PickUp>();
        Materials = GetComponent<MeshRenderer>().materials;
    }

    public void SetProperty(int StackValue, Marker marker, int GoldValue)
    {
        this.StackValue = StackValue;
        _Marker = marker;
        marker.Add(this, transform);
        this.GoldValue = GoldValue;
    }

    public int GetStackValue() 
    {
        int Value = StackValue;
        return Value;
    }

    public void Drop(Transform character)
    {
        float offset = 1.5f;
        float x = Random.Range(character.position.x - offset, character.position.x + offset);
        float z = Random.Range(character.position.z - offset, character.position.z + offset);
        Vector3 RandomCharacterPosition = new Vector3(x, character.position.y, z);
        transform.DOJump(RandomCharacterPosition, JumpPower, JumpNumber, JumpDuration).OnComplete(() =>
        {
            if(_BackPack.IsFull() == false)
            {
                _PickUp.Pick();
            }
        });
    }

    public void DropInHangar(Transform Target, float JumpPower = 0)
    {
        if (JumpPower == 0) JumpPower = this.JumpPower;

        gameObject.SetActive(true);
        transform.localScale = GetScale();
        transform.parent = null;

        transform.DOJump(Target.position, JumpPower, JumpNumber, JumpDuration).OnComplete(() =>
        {
            Vector3 v3 = Target.localScale;
            float ShakePower = 0.2f;
            Target.DOShakePosition(JumpDuration, ShakePower);
            _BackPack.MinusPack(StackValue);
            Coin.Spawn(Target);
            Coin.SetValue(-StackValue, GoldValue);
            gameObject.SetActive(false);
        });
    }

    public void MoveInBackPack()
    {
        if (_BackPack.IsFull())
            return;
        float durationScale = 0.25f;
        transform.DOScale(new Vector3(0f, 0f, 0f), durationScale);
        transform.DOMove(_BackPack.transform.position, durationScale).OnComplete(() =>
        {
            _BackPack.AddPack(this);
            _Marker.RemoveFromMarker(this, transform);
        });
    }

    public Vector3 GetScale()
    {
        return PackScale;
    }

    public void ChangeColor(Color color)
    {
        foreach (Material material in Materials)
        {
            material.color = color;
        }
    }

    public void SetTarget()
    {
        _PickUp.SetPack(this);
    }

    public void RemoveTarget()
    {
        if(_PickUp.GetPack() == this)
        _PickUp.SetPack(null);
    }
}
