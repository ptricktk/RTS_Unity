using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoManager : MonoBehaviour {

    public static InfoManager Current;

    public Image profilePic;
    public Text infoLine1, infoLine2, infoLine3;

    public InfoManager()
    {
        Current = this;
    }

	void Start () {

        ClearLines();
        ClearPic();

	}
	
    public void SetLines(string line1, string line2, string line3)
    {
        infoLine1.text = line1;
        infoLine2.text = line2;
        infoLine3.text = line3;
    }

    public void ClearLines()
    {
        SetLines("", "", "");
    }

    public void SetPicture(Sprite pic)
    {
        profilePic.sprite = pic;
        profilePic.color = Color.white;
    }

    public void ClearPic()
    {
        profilePic.color = Color.clear;
    }
       
}
