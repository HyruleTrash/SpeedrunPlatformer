using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public int Difficulty;
    public string theme;
    public int sizeW;

    public GameObject Player;

    private void Start()
    {
        for (int i = 0; i < transform.GetChild(3).transform.childCount; i++)
        {
            if (transform.GetChild(3).transform.GetChild(i).GetComponent<George>())
            {
                transform.GetChild(3).transform.GetChild(i).GetComponent<George>().Player = Player;
            }
            if (transform.GetChild(3).transform.GetChild(i).GetComponent<Clam>())
            {
                transform.GetChild(3).transform.GetChild(i).GetComponent<Clam>().player = Player;
            }
        }
    }
}
