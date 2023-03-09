using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateAmmoText();
    }

   
    void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"Ammo:{player.currentClip}/{player.maxClipSize}";
    }
}
