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

    private void Start()
    {
        for (int i = 0; i < Lenght; i++)
        {
            GameObject ChainLinkInstance = Instantiate(ChainLink, transform.GetChild(transform.childCount - 1).position - new Vector3(0, ChainLinkLenght, 0), new Quaternion(), transform);
            ChainLinkInstance.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(transform.childCount - 2).GetComponent<Rigidbody2D>();
            ChainLinkInstance.GetComponent<DistanceJoint2D>().connectedBody = ChainLinkInstance.GetComponent<HingeJoint2D>().connectedBody;
        }
        GameObject GeorgeMineInstance = Instantiate(GeorgeMine, transform.GetChild(transform.childCount - 1).position - new Vector3(0, GeorgeMineOffset, 0), new Quaternion(), transform);
        GeorgeMineInstance.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(transform.childCount - 2).GetComponent<Rigidbody2D>();
        GeorgeMineInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(0.01f, 0.05f));
    }
}
