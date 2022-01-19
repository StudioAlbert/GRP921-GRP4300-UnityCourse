using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    
    [SerializeField]
    private float rotateSpeed = 10;

    private bool nextMove;

    public void StartAutoMove()
    {
        StopCoroutine("AutoMoveRoutine");
        StartCoroutine("AutoMoveRoutine");
    }

    public void ResetNextMove()
    {
        nextMove = true;
    }

    IEnumerator AutoMoveRoutine()
    {
        do
        {

            // Move forward ----------------------------------------------------------------
            int nbStepsForward = UnityEngine.Random.Range(5, 15);
            for (int i = 0; i < nbStepsForward; i++)
            {
                transform.Translate(Vector3.forward * moveSpeed);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(() => nextMove == true);
            nextMove = false;

            // Turn around ----------------------------------------------------------------
            int nbStepsRotate = UnityEngine.Random.Range(5, 15);
            for (int i = 0; i < 10; i++)
            {
                transform.Rotate(transform.up, rotateSpeed);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(() => nextMove == true);
            nextMove = false;

        } while (true);

    }

}
