﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ENEMYTYPE enemyType;
    Animator animator;
    
    float currentHp = 200f;
    float maxHp = 200f;
    float enemyHp;

    public ENEMYTYPE Type { get { return enemyType; } set { enemyType = value; } }
    public float Hp { get { return enemyHp; } }

    public void Initialize(ENEMYTYPE type)
    {
        animator = gameObject.GetComponent<Animator>();
        enemyType = type;
        EnemyTypeToString();
    }

    //에너미 속성대로 이름 뜨게 하기
    public void EnemyTypeToString()
    {
        transform.name = enemyType.ToString();
    }

    //에너미가 공격 당할 때
    public void Damage(float damage)
    {
        animator.SetTrigger("IsHit");
        currentHp -= damage;
        enemyHp = currentHp / maxHp;

        if (currentHp <= 0)
        {
            StartCoroutine(EnemyDie());
        }
    }

    public void Attack()
    {
        animator.SetTrigger("IsAttack");
    }

    public void WaitAtk(int wait)
    {
        animator.SetInteger("IsWait", wait);
    }

    public void Victory()
    {
        animator.SetTrigger("IsVictory");
    }

    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(1.0f);
        animator.SetTrigger("IsDie");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().IsVictory();
        yield return new WaitForSeconds(3.0f);
        GameObject.Find("SceneChange").GetComponent<LoadScene>().FromPuzzleToBattle();
    }
}
