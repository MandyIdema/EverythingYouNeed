using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EndGameFunction : MonoBehaviour
{

    //This script is meant to end the game. it is inserted on the player character and the game ends when the health < 0. When it dies a screen will pop up, this will be the game over screen.


    [Header("--- UI ---")]

    //Insert your game over screen here
    [SerializeField]
    private GameObject GameoverCanvas;

    //Insert your UI here (optional)
    public GameObject GameCanvas;

    private void Awake()
    {
        GameoverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        Death();
    }

    private void Death()
    {
        if (this.GetComponent<Health>().CurrentHealth < 0)
        {
            EndGame();
        }
    }


    public void EndGame()
    {
            Time.timeScale = 0;
            Debug.Log("Game over");
            GameoverCanvas.SetActive(true);
            GameCanvas.SetActive(false);
    }


    //(OPTIONAL)
  /*  private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.GetComponent<Health>().CurrentHealth < 0)
            {
                EndGame();
            }
        }
    }*/

}
