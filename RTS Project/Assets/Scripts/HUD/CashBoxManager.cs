﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CashBoxManager : MonoBehaviour {

    public Text CashField;
	
	// Update is called once per frame
	void Update () {
        CashField.text = "$ " + (int)Player.Default.credits;
	}
}
