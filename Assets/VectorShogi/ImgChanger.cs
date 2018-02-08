using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ImgChanger : MonoBehaviour {
    public Sprite[] splites;
    public Image view;
    private int nowIndex;

    public void ChangeSplite()
    {
        nowIndex++;
        nowIndex %= splites.Length;
        Instantiater.prefabName = $"koma{nowIndex+1}";
        view.sprite = splites[nowIndex];
    }
}
