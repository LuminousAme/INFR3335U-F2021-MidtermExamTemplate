using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int coins;
    [SerializeField] private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (coins >= 10)
        {
            SceneManager.LoadScene("End");
        }

        coinText.text = "Coins: " + coins;
    }
}
