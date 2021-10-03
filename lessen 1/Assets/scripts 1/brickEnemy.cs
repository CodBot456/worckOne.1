using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickEnemy : MonoBehaviour
{
    public GameObject player;
    public float distance;
    Vector3 translation;
    public float downSpeed=-35;
    public float upSpeed=12;
    public float speed;
    Vector3 startPoint;
    public float maxDistance;
    bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    
    {
        distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        translation = new Vector3(0,speed * Time.deltaTime, 0);
        transform.position += translation;
        if (transform.position.y >= startPoint.y)
        {
            speed = downSpeed;
        }
        if (distance <= maxDistance && isMove == false)
        {
            isMove = true;
        }
        if (distance > maxDistance && transform.position.y >= startPoint.y)
        {
            speed = 0;
            isMove = false;
        } 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        speed = upSpeed;
    }
   
}
