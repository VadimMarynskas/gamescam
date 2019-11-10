using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class End : MonoBehaviour
{



    public GameObject EndMenu;
    public Text ScoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            EndMenu.SetActive(true);
            ScoreText.text = "Ваш щет: " + collision.GetComponent<Character>().Score;
            Time.timeScale = 0;



        }
    }
}
