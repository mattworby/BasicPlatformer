using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public Transform headStomp = null;
    [SerializeField] public LayerMask enemyMask;

    private Rigidbody rigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(Time.timeScale > 0)
        {
            transform.Translate(new Vector3(1f, rigidBodyComponent.velocity.y, 0) * Time.deltaTime);
        }

        if (Physics.OverlapSphere(headStomp.position, 0.1f, enemyMask).Length == 1)
        {
            Destroy(gameObject);
        }
    }
}
