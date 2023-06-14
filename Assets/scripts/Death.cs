using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }

    public void DeathTransition()
    {
        // change later to scene transition game over
        AppHelper.Quit();
    }

    public void TriggerDeathFade()
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Jump>().enabled = false;
        player.GetComponent<SpriteRenderer>().color = Color.red;
        transform.GetComponent<Animator>().SetTrigger("Died");
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<pickUp>().enabled = false;
        player.GetComponent<walll_Jump>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<PlayerStates>().enabled = false;
        Destroy(player.GetComponent<SpringJoint2D>());
        Destroy(player.GetComponent<Rigidbody2D>());
    }
}
