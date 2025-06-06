using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TriggerAttackAnimation() { anim.SetTrigger("Attack"); }
    public void TriggerJumpAttackAnimation() { anim.SetTrigger("JumpAttack"); }
}
