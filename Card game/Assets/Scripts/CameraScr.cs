using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 2f;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z); //Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
