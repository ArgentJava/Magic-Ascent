using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int cardID;
    public string cardName;
    public int cardCost;
    public int cardPower;
    public string cardDescription;

    public Card()
    {

    }

    public Card(int ID, string name, int cost, int power, string description)
    {
        cardID = ID;
        cardName = name;
        cardCost = cost;
        cardPower = power;
        cardDescription = description;
    }

}
