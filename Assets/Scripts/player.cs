using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class player : MonoBehaviour
{

    [SerializeField] public Transform groundCheckTransform = null;
    [SerializeField] public LayerMask playerMask;
    [SerializeField] public TextMeshProUGUI coinCounter;

    private bool jumpInput;
    private int sprintInput;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private int coinIterator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        
        coinIterator = 0;

        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }
        if ((Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) || (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))))
        {
            sprintInput = 5;
        } else
        {
            sprintInput = 3;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        rigidBodyComponent.useGravity = false;

        rigidBodyComponent.velocity = new Vector3(horizontalInput * sprintInput, rigidBodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            rigidBodyComponent.useGravity = true;
            return;
        }

        if (jumpInput)
        {
            float jumpPower = 5f;

            rigidBodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpInput = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            coinIterator++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        coinCounter.text = coinIterator.ToString();
    }
}
