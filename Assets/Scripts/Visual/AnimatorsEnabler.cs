using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorsEnabler : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;



    private IEnumerator EnableAnimators()
    {
        foreach (var animator in _animators)
        {
            animator.enabled = false;
        }
        yield return null;
        foreach (var animator in _animators)
        {
            animator.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
        }
    }
}
