using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animator component

    // Sets a boolean parameter in the Animator by name
    public void SetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }
}
