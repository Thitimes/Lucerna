using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector3 InitialScale;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        InitialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x > 0.5f || x < -0.5f)
        {
            rb.velocity = new Vector2(x * speed * Time.deltaTime, rb.velocity.y);

        }
        if (x == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (y > 0.5f || y < -0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed * Time.deltaTime);

        }
        if (y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
      /*  if (x < -0.5)
        {
            Vector3 scale = transform.localScale;
            scale.x = -InitialScale.x;
            scale.y = InitialScale.y;
            transform.localScale = scale;
        }
        else if (x > 0.5)
        {
            Vector3 scale = transform.localScale;
            scale.x = InitialScale.x;
            scale.y = InitialScale.y;
            transform.localScale = scale;
        }*/
    }
}