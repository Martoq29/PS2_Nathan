using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatue : MonoBehaviour
{
    public AnimatorOverrideController blueAnim;
    public AnimatorOverrideController redAnim;

    public void BlueSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = blueAnim as AnimatorOverrideController;
    }

    public void RedSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = redAnim as AnimatorOverrideController;
    }
}
