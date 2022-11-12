using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    [SerializeField] float boost = 750f;
    [SerializeField] float direc = 50f;
    bool boostkey;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        boostkey = Input.GetKey(KeyCode.Space);
        float tilt = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(tilt, 0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * direc * Time.deltaTime))));
        }
    }

    void FixedUpdate()
    {
        if (boostkey)
        {
            rb.AddRelativeForce(Vector3.up * boost * Time.deltaTime);
        }
    }

}