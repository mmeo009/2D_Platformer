using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private short hp;
    public Vector3 monsterRespawnPosition;
    public Slider HPBar;

    public short HP
    {
        get { return hp; }
        set
        {
            hp = value;
            HPBar.value = hp;
            Debug.Log(hp);
            if(hp < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void ResetHPBar()
    {
        HPBar.maxValue = hp;
        HPBar.value = hp;
    }

    private void Start()
    {
        ResetHPBar();
    }
}
