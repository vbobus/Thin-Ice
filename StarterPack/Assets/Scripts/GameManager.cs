using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int currentAmountOfPenguins;

    [SerializeField] private GameObject twoPlayerLines;

    [SerializeField] private GameObject fourPlayerLines;


    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI playerWonText;

    public int playerIndexWon = 0;

    //<< Change for player or something later
    [SerializeField] private List<Penguin> currentPenguins;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public int AddPenguin(Penguin loPenguin)
    {
        currentAmountOfPenguins++;
        if (currentAmountOfPenguins >= 2)
        {
            twoPlayerLines.SetActive(true);
        }
        if (currentAmountOfPenguins > 2)
        {
            fourPlayerLines.SetActive(true);
        }

        currentPenguins.Add(loPenguin);

        return currentAmountOfPenguins;
    }


    public void DeadPenguin(Penguin loPenguin)
    {
        currentAmountOfPenguins--;
        currentPenguins.Remove(loPenguin);

        if (currentAmountOfPenguins <= 1)
        {
            if (currentAmountOfPenguins == 1)
                playerIndexWon = currentPenguins[0].playerNumber;
            else
                playerIndexWon = 0;

            currentAmountOfPenguins = 0;
            
            currentPenguins.Clear();

            SceneManager.LoadScene("EndScreen");
        }
    }
    

}
