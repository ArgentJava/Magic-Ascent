using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    
    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None"));
        cardList.Add(new Card(1, "Invoker", 1, 1, "None"));
        cardList.Add(new Card(2, "Harvester", 1, 1, "None"));
        cardList.Add(new Card(3, "Cultist", 1, 1, "None"));
        cardList.Add(new Card(4, "Dwarf", 1, 1, "None"));
    }

}