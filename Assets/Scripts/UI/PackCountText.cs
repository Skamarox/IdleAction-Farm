using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PackCountText : MonoBehaviour
{
    private TMP_Text text;
    private int PackCount;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void ChangeScore(int PackCount) 
    {
        this.PackCount = this.PackCount + PackCount;
        TextOnScreen();
    }

    private void TextOnScreen() 
    {
        text.text = $"{PackCount}/40";
    }
}
