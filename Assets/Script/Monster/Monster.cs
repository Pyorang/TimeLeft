using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.0f;

    private Rigidbody2D rb;
    private BoxCollider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStatus playerStatus = collision.GetComponent<PlayerStatus>();

        if(playerStatus != null)
            playerStatus.HPDown();
    }

    IEnumerator ProcessingDead()
    {
        yield return new WaitForSeconds(0.5f);
        //애니메이션 끝날 때로 변경해야 함.
        Destroy(this.gameObject);
    }

    public void Dead()
    {
        StartCoroutine(ProcessingDead());
    }
}
