using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayID;

    public int cardID;
    public string cardName;
    public int cardCost;
    public int cardPower;
    public string cardDescription;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayID];
    }

    void Update()
    {
        cardID = displayCard[0].cardID;
        cardName = displayCard[0].cardName;
        cardCost = displayCard[0].cardCost;
        cardPower = displayCard[0].cardPower;
        cardDescription = displayCard[0].cardDescription;

        nameText.text = (" " + cardName);
        costText.text = (" " + cardCost);
        powerText.text = (" " + cardPower);
        descriptionText.text = (" " + cardDescription);
    }

}
