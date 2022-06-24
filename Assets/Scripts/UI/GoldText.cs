using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GoldText : MonoBehaviour
{
    private RectTransform rectTransform;
    private TMP_Text text;
    private int Gold;
    [SerializeField] private float DurationShake = 0.5f;
    [SerializeField] private float StenghtShake = 20;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TMP_Text>();
    }

    public void ChangeGold(int Gold)
    {
        this.Gold = this.Gold + Gold;
        TextOnScreen();
    }

    private void TextOnScreen()
    {
        rectTransform.DOShakeAnchorPos(DurationShake, StenghtShake);
        text.text = $"Gold: {Gold}";
    }
}
