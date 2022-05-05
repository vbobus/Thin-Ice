using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShowWinner : MonoBehaviour
{
    public TextMeshProUGUI texST; 


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.playerIndexWon > 0)

            texST.text = "Player: " +  GameManager.instance.playerIndexWon + " Won";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
