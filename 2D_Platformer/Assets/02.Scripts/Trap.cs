using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject Target;
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float Speed;

    private void OnTrOnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("À¸¾Ó");
            Target.transform.position = StartPos;
            Target.SetActive(true);
        }
    }

    private void Update()
    {
        if(Target.activeSelf)
        {
            Target.transform.position = Vector2.MoveTowards(Target.transform.position, EndPos, Speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(StartPos, EndPos);
    }
}
