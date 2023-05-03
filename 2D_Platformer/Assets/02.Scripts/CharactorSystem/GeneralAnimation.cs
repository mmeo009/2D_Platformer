using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStates
{
    Idle, 
    Run, 
    Attack, 
    Jump, 
    Die
}
public class GeneralAnimation : StatSystem
{
    protected CharacterStates nowState;
    //코루틴 분배기 : 상태값을 String 값으로 변환하여 코루틴을 실행하게 해줌
    protected virtual void StateUpdate(CharacterStates newState)
    {
        StopCoroutine(nowState.ToString());
        nowState = newState;
        Debug.Log(nowState);
        StartCoroutine(nowState.ToString());
    }
    IEnumerator Idle()
    {
        while(true)
        {
            //yield return null : 다음 프레임에 실행을 재개한다.
            //yield return new WaitForSeconds : 지정된 시간 후에 재개한다.
            //yield return new WaitForSecondsRealtime :  Time.timescale 값에 영향을 받지 않고 지정된 시간 후에 재개한다.
            //yield return new WaitForFixedUpdate : 모든 스크립트에서 모든 FixedUpdate가 호출된 후에 재개한다.
            //yield return new WaitForEndOfFrame : 모든 카메라와 GUI가 렌더링을 완료하고, 스크린에 프레임을 표시하기 전에 호출된다.
            //yield return StartCoroutine() : 코루틴을 연결하고 코루틴이 완료된 후에 재개한다.
            yield return null;
        }
    }
    IEnumerator Run()
    {
        while(true)
        {
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        while(true)
        {
            yield return null;
        }
    }
    IEnumerator Jump()
    {
        while(true)
        {
            yield return null;
        }
    }
    IEnumerator Die()
    {
        while(true)
        {
            yield return null;
        }
    }
}