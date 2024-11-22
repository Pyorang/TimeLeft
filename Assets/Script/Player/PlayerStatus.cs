using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int lifeCount = 3;

    [SerializeField] private float attackCoolDown = 1f;
    [SerializeField] private float attackRange = 7.5f;

    public delegate void LifeCountChanged(int lifeCount);
    public static event LifeCountChanged OnLifeCountChanged;

    private PlayerAnimation playerAnimation;
    private PlayerControl playerControl;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerControl = GetComponent<PlayerControl>();
    }

    public int LifeCount
    {
        get { return lifeCount; }
        private set
        {
            lifeCount = value;
            OnLifeCountChanged?.Invoke(lifeCount);
        }
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
        LifeCount--;
        
        if(LifeCount <=0)
        {
            Die();
            return;
        }

        //깜박거리는 애니메이션 연출
    }

    public void Die()
    {
        //죽는 애니메이션 처리
        playerControl.SetNotDead(false);
    }
}
