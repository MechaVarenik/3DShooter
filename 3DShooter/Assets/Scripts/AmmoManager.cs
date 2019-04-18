using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = PlayerVariable.currentAmmo[PlayerVariable.selectedWeapon] + " / " + PlayerVariable.totalAmmo[PlayerVariable.selectedWeapon];
    }

}
