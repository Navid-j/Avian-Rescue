using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_MoveMent : MonoBehaviour
{

    public float speed = 2f;
    public float xRange = 3f;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 6);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {

        //transform.Translate(Vector2.up  * speed * Time.deltaTime);

        if (transform.position.y > 8)
        {
            Destroy(gameObject);

        }

        if (transform.position.y < -12)
        {
            Destroy(gameObject);

        }


        float x = Mathf.Clamp(transform.position.x, -xRange , xRange);
        transform.position = new Vector2(x, transform.position.y);

    }


}
