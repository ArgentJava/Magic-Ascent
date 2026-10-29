using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public bool isOpponentTurn;
    public int turnCount;
    public TextMeshProUGUI turnText;

    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public static bool startTurn;

    void Start()
    {
        isYourTurn = true;
        isOpponentTurn = false;
        turnCount = 1;

        maxMana = 1;
        currentMana = 1;

        startTurn = false;
    }

    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = ("Turn: "+turnCount+"\nYour turn");
        }
        else
        {
            turnText.text = ("Turn: " + turnCount + "\nOpponent turn");
        }

        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndYourTurn()
    {
        if (isYourTurn == true)
        {
            isOpponentTurn = true;
            isYourTurn = false;
            turnCount += 1;
        }
        else { /*Do nothing. Preferrably button is disabled*/ }
    }
    public void EndOpponentTurn()
    {
        if (isOpponentTurn == true)
        {
            isYourTurn = true;
            isOpponentTurn = false;
            turnCount += 1;
            maxMana += 1;
            currentMana = maxMana;
        }
        else { /*Do nothing. Preferrably button is disabled*/ }
    }

}
