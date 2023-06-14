using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class George : MonoBehaviour
{
    public int Lenght = 1;
    public GameObject ChainLink;
    public GameObject GeorgeMine;
    public float ChainLinkLenght = 0.44f;
    public float GeorgeMineOffset = 0.94f;
    public GameObject Player;

    private void Start()
    {
        for (int i = 0; i < Lenght; i++)
        {
            GameObject ChainLinkInstance = Instantiate(ChainLink, transform.GetChild(transform.childCount - 1).position + new Vector3(0, ChainLinkLenght, 0), new Quaternion(), transform);
            ChainLinkInstance.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(transform.childCount - 2).GetComponent<Rigidbody2D>();
            if (i != 0)
            {
                ChainLinkInstance.GetComponent<DistanceJoint2D>().connectedBody = ChainLinkInstance.GetComponent<HingeJoint2D>().connectedBody;
            }
            else
            {
                Destroy(ChainLinkInstance.GetComponent<DistanceJoint2D>());
            }
        }
        GameObject GeorgeMineInstance = Instantiate(GeorgeMine, transform.GetChild(transform.childCount - 1).position + new Vector3(0, GeorgeMineOffset, 0), new Quaternion(), transform);
        GeorgeMineInstance.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(transform.childCount - 2).GetComponent<Rigidbody2D>();
        GeorgeMineInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(0.01f, 0.05f));
        GeorgeMineInstance.GetComponent<Rigidbody2D>().mass = transform.childCount * 0.2f;
        GeorgeMineInstance.GetComponent<GeorgeAttraction>().Player = Player;
        GeorgeMineInstance.GetComponent<GeorgeExplosion>().Player = Player;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<HingeJoint2D>())
            {
                transform.GetChild(i).GetComponent<HingeJoint2D>().enabled = true;
            }
            if (transform.GetChild(i).GetComponent<DistanceJoint2D>())
            {
                transform.GetChild(i).GetComponent<DistanceJoint2D>().enabled = true;
            }
        }
    }
}
