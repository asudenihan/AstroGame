using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.Find("Astronaut").transform.position + offset;

        Vector3 cameraPos = GameObject.Find("Main Camera").transform.position;
        Vector3 playerPos = new Vector3(GameObject.Find("Main Camera").transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z - 5);
        gameObject.transform.position = playerPos;

    }
}