using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float moveSpeed;
    public float rotateSpeed;
    [HideInInspector] public Vector3 moveDir;
    [HideInInspector] public Rigidbody rb;

    public GameObject go;
    IControllable ColtrollableObj;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ColtrollableObj = go.GetComponent<IControllable>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ColtrollableObj.Attack();
        //Move Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir = moveInput.normalized * moveSpeed;
        if(moveInput != Vector3.zero)
        {
            ColtrollableObj.Move();

            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(moveDir.z) + Mathf.Abs(moveDir.x));
        }

    }
}
