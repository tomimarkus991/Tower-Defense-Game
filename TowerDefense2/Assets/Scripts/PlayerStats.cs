using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Money Settings")]
    public static int Money;
    public int startMoney = 400;

    [Header("Player Lives")]
    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
