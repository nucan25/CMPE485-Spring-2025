using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }
}
