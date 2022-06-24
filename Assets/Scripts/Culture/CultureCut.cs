using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CultureCut : MonoBehaviour, IMarker
{
    [SerializeField] private PackScriptObject pack;
    private CultureDead cultureDead;
    private int HitCount;
    private int MaxHitCount;
    private Material[] Materials;
    private Cut _Player;
    private Marker _Marker;
    [SerializeField] private float ShakeDuration = 0.2f;
    [SerializeField] private float ShakeStranght = 0.075f;

    private void Start()
    {
        _Player = Player.Instance.GetComponent<Cut>();
        Materials = GetComponent<MeshRenderer>().materials;
        cultureDead = GetComponent<CultureDead>();
    }

    public void SetProperty(int HitCount, Marker _Marker)
    {
        MaxHitCount = HitCount;
        this.HitCount = MaxHitCount;
        _Marker.Add(this, transform);
        this._Marker = _Marker;
    }

    public bool IsDead() 
    {
        if (HitCount <= 0)
            return true;
        return false;
    }

    public void Respawn()
    {
        HitCount = MaxHitCount;
    }

    public void Cut()
    {
        HitCount--;
        SpawnPack.Spawn(pack, transform, _Marker);
        transform.DOShakeScale(ShakeDuration, ShakeStranght);
        if (HitCount == 0)
        {
            cultureDead.Dead();
            RemoveTarget();
        }
    }

    public void ChangeColor(Color color)
    {
        foreach(Material material in Materials)
        {
            material.color = color;
        }
    }

    public void SetTarget()
    {
        if (IsDead())
        {
            RemoveTarget();
            return;
        }

            _Player.SetCulture(this);
    }

    public void RemoveTarget()
    {
        if(_Player.TargetIsThis(this))
        _Player.SetCulture(null);
    }
}
