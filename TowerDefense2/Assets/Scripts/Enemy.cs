using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] // peidab
    public float speed; // public siis accessib seda ka teistest kohtadest nagu nt EnemyMovement script

    public float health = 100f;

    public int value = 50;

    //public int maxMoney = 99999;

    public GameObject deathEffect;  

    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Slow (float pct)// pct on protsent
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        //if (maxMoney <= 99999)
        //{
        //    PlayerStats.Money += value;
        //}
        //else
        //{
        //    PlayerStats.Money = maxMoney;
        //}
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}
