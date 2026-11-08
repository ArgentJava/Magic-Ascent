using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OppHP : MonoBehaviour
{
    public static float maxHP;
    public static float currentHP;
    public float hp;
    public Image health;
    public TextMeshProUGUI hpText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHP = 100;
        currentHP = 75;
    }

    // Update is called once per frame
    void Update()
    {
        hp = currentHP;

        hpText.text = currentHP.ToString();
        health.fillAmount = currentHP / maxHP;
    }
}
