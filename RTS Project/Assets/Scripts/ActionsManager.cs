using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionsManager : MonoBehaviour {

    public static ActionsManager current;

    public Button[] buttons;

    private List<Action> actionCalls = new List<Action>();

    public ActionsManager()
    {
        current = this;
    }

    public void ClearButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
            actionCalls.Clear();
        }
    }

    public void AddButton(Sprite pic, Action onClick)
    {
        int index = actionCalls.Count;
        buttons[index].gameObject.SetActive(true);
        buttons[index].GetComponent<Image>().sprite = pic;
        actionCalls.Add(onClick);
    }

    public void OnButtonClick(int index)
    {
        actionCalls[index]();
    }

	// Use this for initialization
	void Start () {
		for (int i = 0; i < buttons.Length; i++ )
        {
            var index = i;
            buttons[index].onClick.AddListener(delegate() {
                OnButtonClick(index);
            });

        }

        ClearButtons();
	}
	
}
