using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    
    public List<Card> container = new(); //Used for shuffling
    public static int deckSize = 40;
    public List<Card> deck = new();
    public static List<Card> staticDeck = new();

    public GameObject cardinDeck1; 
    public GameObject cardinDeck2;
    public GameObject cardinDeck3;
    public GameObject cardinDeck4;

    public GameObject cardToHand;
    public GameObject[] Clones;
    public GameObject Hand;

    private static readonly WaitForSeconds _waitForSeconds1 = new(.5f);

    void Start()
    {
        deckSize = deck.Count;
        //[lines 13 - ]Functionality is for testing deck implementation and card drawing.
        //Replace with specialized deck populating later.
        int x; //used to randomly select cards from CardDatabase for populating deck
        for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, 8);
            deck[i] = CardDatabase.cardList[x];
        }

        StartCoroutine(StartGame());

    }

    void Update()
    {
        //Deck decreases in size as it runs out of cards
        staticDeck = deck;
        if (deckSize <= 30)
        {
            cardinDeck1.SetActive(false);
        }
        else if (deckSize <= 20)
        {
            cardinDeck2.SetActive(false);
        }
        else if(deckSize <= 10)
        {
            cardinDeck3.SetActive(false);
        }
        else if(deckSize < 1)
        {
            cardinDeck4.SetActive(false);
        }

        if(TurnSystem.startTurn == true)
        {
            StartCoroutine(DrawCard(1));
            TurnSystem.startTurn = false;
        }
    }

    IEnumerator StartGame()
    {
        StartCoroutine(DrawCard(5));
        return null;
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    //Adds given amount of cards to hand
    IEnumerator DrawCard(int drawAmount)
    {
        for(int i = 0; i < drawAmount; i++)
        {
            yield return _waitForSeconds1;
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }

}
