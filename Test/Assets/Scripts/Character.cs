using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    


    [SerializeField] private int HealthPoints = 3;
    [SerializeField] private float InvulnerabilityTime = 3f;
    [SerializeField] private Text HealthpPointText;
    [SerializeField] private Text ScoreText;

    public int Score { private set; get; }
    private Animator animator;
    private bool invulnerability = false;
    private Collider2D[] colliders; 
    private float LastHurtTime = 0;

    public void Start()
    {
        
        animator = GetComponent<Animator>();
        colliders = GetComponents<Collider2D>();
        LayerMask.GetMask();
        HealthpPointText.text = "HP: " + HealthPoints;
        ScoreText.text = "Score: " + Score;
    }

    public void AddHealthPoint()
    {
        HealthPoints++;
        HealthpPointText.text = "HP: " + HealthPoints.ToString();
    }

    public void AddScore(int x)
    {
        Score += x;
        ScoreText.text = "Score: " + Score;
    }

    public void Hurt()
    {
        
        if(!invulnerability)
        {
            if (HealthPoints > 0)
            {
                
                StartCoroutine(Invulnerability(InvulnerabilityTime));
                HealthPoints--;
                HealthpPointText.text = "HP: " + HealthPoints.ToString();

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        



    }

    IEnumerator Invulnerability(float InvulnerabilityTime)
    {
        invulnerability = true;



        int Player = LayerMask.NameToLayer("Player");
        int Enemy = LayerMask.NameToLayer("Enemy");


        Physics2D.IgnoreLayerCollision(Enemy,Player);

        animator.SetLayerWeight(1, 1);

        foreach (Collider2D collider2D in colliders)
        {
            collider2D.enabled = false;
            collider2D.enabled = true;
        }

        yield return new WaitForSeconds(InvulnerabilityTime);

        animator.SetLayerWeight(1, 0);

        Physics2D.IgnoreLayerCollision(Enemy, Player,false);


        

        invulnerability = false;

    }


}
