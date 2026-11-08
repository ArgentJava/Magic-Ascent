using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new();
    
    void Awake()
    {
        /*Card formatting
        cardList.Add(new Card([cardID], "[cardName]", [cardCost], [cardHealth], [cardPower], "[cardDescription]"));
        */
        //Minion Cards -------------------------------------------------------------------------------------------//
        cardList.Add(new Card(0, "Name", 0, 0, 0, "Description", Resources.Load<Sprite>("Minions/matMinionHarvester") )); //This is an example card

        //Invoker
        cardList.Add(new Card(1, "Invoker_minion_1", 1, 1, 2, "Weak invoker minion", Resources.Load<Sprite>("Minions/matMinionInvoker") ));
        cardList.Add(new Card(2, "Invoker_minion_2", 2, 4, 4, "Stronger invoker minion", Resources.Load<Sprite>("Minions/matMinionInvoker") ));

        //Harvester
        cardList.Add(new Card(3, "Harvester_minion_1", 1, 1, 2, "Weak harvester minion", Resources.Load<Sprite>("Minions/matMinionHarvester") ));
        cardList.Add(new Card(4, "Harvester_minion_2", 4, 6, 1, "Stronger harvester minion", Resources.Load<Sprite>("Minions/matMinionHarvester") ));

        //Cultist
        cardList.Add(new Card(5, "Cultist_minion_1", 1, 1, 1, "Weak cultist minion", Resources.Load<Sprite>("Minions/matMinionCultist") ));
        cardList.Add(new Card(6, "Cultist_minion_2", 1, 1, 1, "Stronger cultist minion", Resources.Load<Sprite>("Minions/matMinionCultist") ));

        //Dwarf
        cardList.Add(new Card(7, "Dwarf_minion_1", 1, 1, 1, "Weak dwarf minion", Resources.Load<Sprite>("Minions/matMinionDwarf") ));
        cardList.Add(new Card(8, "Dwarf_minion_2", 1, 1, 1, "Stronger dwarf minion", Resources.Load<Sprite>("Minions/matMinionDwarf") ));

        
        //--------------------------------------------------------------------------------------------------------//

    }

}