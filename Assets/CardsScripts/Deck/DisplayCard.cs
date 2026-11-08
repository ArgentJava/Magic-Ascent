using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new();
    public int displayID;

    public int cardID;
    public string cardName;
    public int cardCost;
    public int cardHealth;
    public int cardPower;
    public string cardDescription;
    public Sprite cardSprite;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;
    public Image sprite;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    void Start()
    {

        numberOfCardsInDeck = PlayerDeck.deckSize;

        displayCard[0] = CardDatabase.cardList[displayID];

        
    }

    void Update()
    {

        cardID = displayCard[0].cardID;
        cardName = displayCard[0].cardName;
        cardCost = displayCard[0].cardCost;
        cardHealth = displayCard[0].cardHealth;
        cardPower = displayCard[0].cardPower;
        cardDescription = displayCard[0].cardDescription;
        cardSprite = displayCard[0].cardSprite;

        nameText.text = (" " + cardName);
        costText.text = (" " + cardCost);
        powerText.text = (" " + cardPower);
        descriptionText.text = (" " + cardDescription);
        sprite.sprite = cardSprite;

        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }
        staticCardBack = cardBack;

        if(this.CompareTag("Clone"))
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }



    }

}
