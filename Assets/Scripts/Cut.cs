using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    private CultureCut Target;
    [SerializeField] private GameObject Tool;

    public void SetCulture(CultureCut Target)
    {
        this.Target = Target;
    }

    public bool TargetIsThis(CultureCut target) 
    {
        if (Target == target)
            return true;
        return false;
    }

    public void DoCut()
    {
        if (Target == null || Target.IsDead())
            return;

        Vector3 direction = Target.transform.position - transform.position;
        Vector3 dir = new Vector3(direction.x, 0f, direction.z);
        Quaternion r = Quaternion.LookRotation(dir);
        transform.rotation = r;
        Tool.SetActive(true);
        State.SetState(State.Animation.Cut, true);
    }

    //Вызывается из Animator Event. Название анимации "Cut"
    private void Cutting()
    {
        Target?.Cut();
    }

    private void Update()
    {
        if (Target == null)
        {
            State.SetState(State.Animation.Cut, false);
            Tool.SetActive(false);
            return;
        }
    }
}
