using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cameraFollow;
    private float numberOfStair = 0;
    private GameplayController gameplayController;




    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        //gameplayController = GetComponent<GameplayController>();
        gameplayController = GameplayController.instance;
    }

    void Update()
    {

        if (!playerDied)
        {

            if (rb.velocity.sqrMagnitude > 60)
            {

                playerDied = true;
                cameraFollow.CanFollow = false;


                GameplayController.instance.ShowPanelDied();

                SoundManager.instance.GameEndSound();
               // GameplayController.instance.RestartGame();

            }

        }

    } // update

    void OnTriggerEnter(Collider target)
    {

        if (target.tag == "Coin")
        {

            target.gameObject.SetActive(false);

            SoundManager.instance.PickedUpCoin();
            GameplayController.instance.IncrementScore();
            Debug.Log("test interaction");
        }

        if (target.tag == "Spike")
        {

            Debug.Log("Spike nè");
            cameraFollow.CanFollow = false;

            //StartCoroutine(gameplayController.ShowPanelAfterDelay());
            GameplayController.instance.ShowPanelDied();

            SoundManager.instance.GameEndSound();
            //GameplayController.instance.RestartGame();
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision target)
    {

        if (target.gameObject.tag == "EndPlatform")
        {

            SoundManager.instance.GameStartSound();
            GameplayController.instance.RestartGame();

        }


        if (target.gameObject.tag == "Platform")
        {
            numberOfStair++;
            GameplayController.instance.IncrementStair();
            
        }      
    }
} // class