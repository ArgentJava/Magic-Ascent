using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Card
{
    public int cardID;
    public string cardName;
    public int cardCost;
    public int cardHealth;
    public int cardPower;
    public string cardDescription;
    public Sprite cardSprite;

    public Card()
    {

    }

    public Card(int ID, string name, int cost, int health, int power, string description, Sprite sprite)
    {
        cardID = ID;
        cardName = name;
        cardCost = cost;
        cardHealth = health;
        cardPower = power;
        cardDescription = description;
        cardSprite = sprite;

    }

}
