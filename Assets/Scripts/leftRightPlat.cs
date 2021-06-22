using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRightPlat : MonoBehaviour
{
    Vector3 Vec;
    private float origPos;
    private float currentPos;
    private int direction;
    private int moving;

    // Start is called before the first frame update
    void Start()
    {
        Vec = transform.localPosition;
        origPos = Vec.x;
        direction = 1;
        moving = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        currentPos = Vec.x;

        if ((currentPos - origPos) >= 1.5f)
        {
            direction = 0;
        }
        if ((currentPos - origPos) <= 0f)
        {
            direction = 1;
        }
        if (direction == 1 && moving == 1)
        {
            movePlat(0.02f);
        }
        else if (direction == 0 && moving == 1)
        {
            movePlat(-0.02f);
        }
    }

    void movePlat(float speed)
    {
        Vec.x += speed;
        transform.localPosition = Vec;
        currentPos = Vec.x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetParent(transform);
        moving = 1;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
