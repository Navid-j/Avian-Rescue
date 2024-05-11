using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player_Movment : MonoBehaviour
{
    public static int COUNTER = 0;

    public float speed = 3f;
    public float xRange = 3f;
    public float yRange = 5.5f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public GameObject victoryDialog;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(Vector2.right * speed * v * Time.deltaTime);
        transform.Translate(Vector2.down * speed * h * Time.deltaTime);


        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }


        if (COUNTER >= 9)
        {

            StartCoroutine(goFinish());

        }
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.rotation);
    }

    IEnumerator goFinish()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(4f);
        victoryDialog.SetActive(true);
        COUNTER = 0;
        //Time.timeScale = 0f;

    }

}
