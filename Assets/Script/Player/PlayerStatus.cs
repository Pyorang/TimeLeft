using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int hp = 3;

    [SerializeField] private float attackCoolDown = 1f;       // 1
    [SerializeField] private float attackRange = 7.5f;          // 7.5

    private PlayerAnimation playerAnimation;
    private PlayerControl playerControl;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerControl = GetComponent<PlayerControl>();
    }

    public float AttackCoolDown
    {
        get { return attackCoolDown; }
        set { attackCoolDown = value; }
    }

    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }

    public void HPDown()
    {
        hp--;
        
        if(hp <=0)
        {
            Die();
            return;
        }

        //���ڰŸ��� �ִϸ��̼� ����
    }

    public void Die()
    {
        //�״� �ִϸ��̼� ó��
        playerControl.SetNotDead(false);
    }
}
