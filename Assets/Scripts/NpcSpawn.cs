using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NpcSpawn : MonoBehaviour
{

    public GameObject carPrefab;
    private float timer;
    public float intervalTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector2 position = new Vector2(Random.Range(-3, 3), transform.position.y);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -90));

        if(timer > intervalTime)
        {
        Instantiate(carPrefab, position, rotation);
        timer = 0f;
        }

    }
}
