using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private int hashDoRunning;
    private int hashDoWalking;
    private int hashDo2Hands;
    private int hashDoFighting;
    private int hashDoRifle;

    private int idxLayerCombat;

    const float stepFadeValue = 0.01f;
    const float stepFadeDuration = 0.01f;

    private Coroutine coroutineFadeIn;
    private Coroutine coroutineFadeOut;

    [SerializeField]
    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        hashDoRunning = Animator.StringToHash("isRunning");
        hashDoWalking = Animator.StringToHash("isWalking");
        hashDo2Hands = Animator.StringToHash("is2Hands");
        hashDoFighting = Animator.StringToHash("isFighting");
        hashDoRifle = Animator.StringToHash("isRifle");

        idxLayerCombat = animator.GetLayerIndex("CombatPosture");

    }

// Update is called once per frame
    void Update()
    {
        
    }

    public void DoRunning(bool running_)
    {
        animator.SetBool(hashDoRunning, running_);
    }
    public void DoWalking(bool walking_)
    {
        animator.SetBool(hashDoWalking, walking_);
    }
    public void Do2HandsPosture()
    {
        FadeInCombatLayer();
        animator.SetBool(hashDo2Hands, true);
        animator.SetBool(hashDoFighting, false);
        animator.SetBool(hashDoRifle, false);
    }
    public void DoFightingPosture()
    {
        FadeInCombatLayer();
        animator.SetBool(hashDo2Hands, false);
        animator.SetBool(hashDoFighting, true);
        animator.SetBool(hashDoRifle, false);
    }

    public void DoRiflePosture()
    {
        FadeInCombatLayer();
        animator.SetBool(hashDo2Hands, false);
        animator.SetBool(hashDoFighting, false);
        animator.SetBool(hashDoRifle, true);
    }

    internal void RealeasePosture()
    {
        FadeOutCombatLayer();
        animator.SetBool(hashDo2Hands, false);
        animator.SetBool(hashDoFighting, false);
        animator.SetBool(hashDoRifle, false);
    }

    void FadeInCombatLayer()
    {
        if(coroutineFadeOut != null)
            StopCoroutine(coroutineFadeOut);

        coroutineFadeIn = StartCoroutine(DoFadeCombatLayer(1.0f));
    }

    void FadeOutCombatLayer()
    {
       if(coroutineFadeIn != null)
            StopCoroutine(coroutineFadeIn);

        coroutineFadeOut = StartCoroutine(DoFadeCombatLayer(0.0f));
    }

    IEnumerator DoFadeCombatLayer(float fadeDestination)
    {

        float layerWeight = animator.GetLayerWeight(idxLayerCombat);
        int nbSteps = (int)(Mathf.Abs(layerWeight - fadeDestination) / stepFadeValue);

        for (int step = 0; step < nbSteps; step++)
        {
/*            Debug.Log("Stepping Weight : " + step + ":" + layerWeight);
*/            
            animator.SetLayerWeight(idxLayerCombat, Mathf.Lerp(layerWeight, fadeDestination, (float)step  / (float)nbSteps));
            layerWeight = animator.GetLayerWeight(idxLayerCombat);

            yield return new WaitForSeconds(stepFadeDuration);

        }

        yield return null;

    }
}
