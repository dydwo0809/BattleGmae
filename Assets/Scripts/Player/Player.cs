using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Player : MonoBehaviour
{
    public float speed { get; set; } = 10f;
    public Rigidbody playerRigidbody;

    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (pv.IsMine)
        {
            // ��Ʈ��ũ Ȯ���� ���� �ӽ� �̵� �ڵ�
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * speed;
            float zSpeed = zInput * speed;

            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
            playerRigidbody.velocity = newVelocity;
        }
        
    }
}
