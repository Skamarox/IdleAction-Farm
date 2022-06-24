using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin
{
    private static Image coinImage;
    private static Image CoinImage
    {
        get
        {
            if(coinImage == null)
                coinImage = Resources.Load<Image>("Coin");
            return coinImage;
        }
    }
    private static PackCountText scoreText;
    private static PackCountText S_Text
    {
        get
        {
            if (scoreText == null)
                scoreText = Object.FindObjectOfType<PackCountText>();
            return scoreText;
        }
    }

    private static GoldText goldText;
    private static GoldText G_Text
    {
        get
        {
            if(goldText == null)
                goldText = Object.FindObjectOfType<GoldText>();
            return goldText;
        }
    }


    private static float MoveDuration = 0.5f;
    private static int ScoreValue;
    private static int GoldValue;

    private static List<Image> Coins = new List<Image>();

    public static void Spawn(Transform spawnPosition)
    {
        Image newCoin = null;
        if (ImageFromPool() == null)
        {
            newCoin = Object.Instantiate(CoinImage, G_Text.transform);
            Coins.Add(newCoin);
        }
        else
        {
            newCoin = ImageFromPool();
            newCoin.gameObject.SetActive(true);
        }
        newCoin.transform.position = Camera.main.WorldToScreenPoint(spawnPosition.position);
        CoinMove(newCoin.rectTransform, newCoin.gameObject);
    }

    private static Image ImageFromPool() 
    {
        if(Coins.Count > 0)
        {
            foreach(Image img in Coins)
            {
                if(img.gameObject.activeInHierarchy == false)
                {
                    return img;
                }
            }
        }
        return null;
    }

    public static void SetValue(int score, int gold)
    {
        ScoreValue = score;
        GoldValue = gold;
    }

    private static void CoinMove(Transform transform, GameObject coin)
    {
        transform.DOMove(G_Text.transform.position, MoveDuration).OnComplete(() =>
        {
            G_Text.ChangeGold(GoldValue);
            S_Text.ChangeScore(ScoreValue);
            coin.SetActive(false);
        });
    }


}
