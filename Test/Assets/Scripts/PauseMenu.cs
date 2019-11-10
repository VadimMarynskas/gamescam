using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool P = false;
    public GameObject PauseMenuUI;

    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("LOL");
            if(P)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);

        Time.timeScale = 0;
        P = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);

        Time.timeScale = 1;
        P = false;
    }

}
