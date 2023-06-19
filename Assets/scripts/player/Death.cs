using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    GameObject player;
    public GameObject DeathUI;
    private PauseMenu puase;

    private void Start()
    {
        player = GameObject.Find("player");
        puase = DeathUI.GetComponent<PauseMenu>();
        
    }

    private void Update()
    {
        if (player.transform.position.y < -12)
        {
            player.transform.position = new Vector3(player.transform.position.x, -13);
            TriggerDeathFade();
        }
    }

    public void DeathTransition()
    {
        // change later to scene transition game over
        puase.Died();
    }

    public void TriggerDeath()
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Jump>().enabled = false;
        player.GetComponent<SpriteRenderer>().color = Color.red;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<pickUp>().enabled = false;
        player.GetComponent<walll_Jump>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<PlayerStates>().enabled = false;
        Destroy(player.GetComponent<SpringJoint2D>());
        Destroy(player.GetComponent<Rigidbody2D>());
    }

    public void TriggerDeathFade()
    {
        transform.GetComponent<Animator>().SetTrigger("Died");
    }
}
