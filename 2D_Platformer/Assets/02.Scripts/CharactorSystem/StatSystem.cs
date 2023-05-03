using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
   
    protected BaisicStats Stats;

    protected virtual void StatSetting(int hp, int atk, float moveSpeed, float jumpForce)
    {
        Stats.HP = hp;
        Stats.ATK = atk;
        Stats.MoveSpeed = moveSpeed;
        Stats.JumpForce = jumpForce;
    }
    protected struct BaisicStats
    {
        public int HP;
        public int ATK;
        public float MoveSpeed;
        public float JumpForce;
    }
}
