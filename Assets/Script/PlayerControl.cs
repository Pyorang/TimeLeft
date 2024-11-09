using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool isJumping = false;
    private bool isAttacking = false;

    [SerializeField] private float jumpPower = 0.0f;
    [SerializeField] private float attackCoolDown = 0.0f;

    private Rigidbody2D rb;
    [SerializeField] private PlayerAnimation playerAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void WaitForJumpAtk()
    {
        if (Input.GetKeyDown(KeyCode.X) && (!isAttacking))
        {
            if (!isJumping) Jump();
            isJumping = true;
        }
    }

    private void WaitForAtk()
    {
        if(Input.GetKeyDown(KeyCode.Z) && (!isJumping))
        {
            if (!isAttacking) Attack();
            isAttacking = true;
            StartCoroutine(StartAttackCoolDown());
        }
    }

    IEnumerator StartAttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDown);
        isAttacking = false;
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, 1) * jumpPower, ForceMode2D.Impulse);
    }

    private void Attack()
    {
        playerAnim.TriggerAttackAnimation();
        //앞의 몬스터 검사 후 공격
    }

    private void FixedUpdate()
    {
        WaitForAtk();
        WaitForJumpAtk();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
