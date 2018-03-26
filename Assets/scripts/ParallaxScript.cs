using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    private float offset;

    public int speed;

    public GameObject Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            offset = Player.transform.position.x / speed;
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
