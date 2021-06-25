using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateLevel : MonoBehaviour
{

    [SerializeField] public GameObject block;
    [SerializeField] public GameObject backWall;

    Vector3 Vec;
    private float origPosX;
    private float origPosY;

    private float maxWidth = 500;
    private float maxHeight = 500;
    private float xScale;

    private float height;

    // Start is called before the first frame update
    void Start()
    {
        Vec = transform.localPosition;
        origPosX = Vec.x;
        origPosY = Vec.y;
        generate(origPosX, origPosY);

    }

    private void generate(float oPosX, float oPosY)
    {

        for (float x = oPosX; x < maxWidth; x++)
        {
            xScale = x / maxWidth;
            height = Mathf.PerlinNoise(xScale * 100f, 0.0f);

            if (!(Random.Range(0, 15) == 10))
            {
                Instantiate(block, new Vector3(x, height, 0f), Quaternion.identity);
            }

            if (x == 0)
            {
                Instantiate(backWall, new Vector3(oPosX - 0.5f, height + 4.9f, 0f), Quaternion.AngleAxis(90f, new Vector3(0, 0, -1)));
            }
        }
    }
}
