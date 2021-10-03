using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muve : MonoBehaviour

{
    SpriteRenderer spriteRenderer;
    public float distance;
    Vector3 translation;
    public float speed;
    Vector3 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //получаем доступ к спрайтрендереру

        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        translation = new Vector3(speed * Time.deltaTime, 0,0);
        transform.position += translation;
        if (transform.position.x > startPoint.x + distance)
            {
            speed = -speed;
            spriteRenderer.flipX = true; //отобразить по оси X
            }
        
        if (transform.position.x < startPoint.x - distance)
        {
            speed = -speed;
            spriteRenderer.flipX = false; //отобразить по оси X
        }
    }
}
