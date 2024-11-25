using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool notDead = true;
    private bool isJumping = false;
    private bool isAttacking = false;

    [SerializeField] private LayerMask monsterCheck;
    private PlayerAnimation playerAnim;
    private PlayerStatus playerStatus;

    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        if (notDead)
        {
            Debug.DrawRay(transform.position, Vector3.right * playerStatus.AttackRange, Color.red);
            WaitForAtk();
            WaitForJumpAtk();
        }
    }

    public void SetNotDead(bool notDead)
    {
        this.notDead = notDead;
    }

    IEnumerator StartAtkCoolDown()
    {
        yield return new WaitForSeconds(playerStatus.AttackCoolDown);
        isAttacking = false;
    }

    IEnumerator StartJumpAtkCoolDown()
    {
        yield return new WaitForSeconds(playerStatus.AttackCoolDown);
        isJumping = false;
    }

    private Monster CheckMonsterInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, playerStatus.AttackRange, monsterCheck);
        if (hit.collider != null)
            return hit.collider.GetComponent<Monster>();
        return null;
    }

    private void Attack()
    {
        playerAnim.TriggerAttackAnimation();
        
        Monster monster = CheckMonsterInRange();
        if(monster != null)
            monster.Dead();
    }

    private void JumpAtk()
    {
        playerAnim.TriggerJumpAttackAnimation();

        Monster monster = CheckMonsterInRange();
        if (monster != null)
            monster.Dead();
    }

    private void WaitForAtk()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (!isJumping))
        {
            if (!isAttacking) Attack();
            isAttacking = true;
            StartCoroutine(StartAtkCoolDown());
        }
    }

    private void WaitForJumpAtk()
    {
        if (Input.GetKeyDown(KeyCode.X) && (!isAttacking))
        {
            if (!isJumping) JumpAtk();
            isJumping = true;
            StartCoroutine(StartJumpAtkCoolDown());
        }
    }

    public void OnAttackBtnClicked()
    {
        if (!isJumping)
        {
            if (!isAttacking) Attack();
            isAttacking = true;
            StartCoroutine(StartAtkCoolDown());
        }
    }

    public void OnJumpAttackBtnClicked()
    {
        if (!isAttacking)
        {
            if (!isJumping) JumpAtk();
            isJumping = true;
            StartCoroutine(StartJumpAtkCoolDown());
        }
    }
}
