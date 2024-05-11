using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 targetPosition;
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2(Random.Range(-3f, 3f), Random.Range(4f, 2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        child.transform.parent = transform;

        MoveFunction();
    }

    void MoveFunction()
    {

        // Move the enemy smoothly towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(targetPosition, transform.position) <= 0.1f)
        {
            targetPosition = new Vector2(Random.Range(-3f, 3f), Random.Range(4f, 2.5f));
        }
    }
}
