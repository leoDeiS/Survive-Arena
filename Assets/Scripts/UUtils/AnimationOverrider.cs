using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUtils.Animations
{
    public static class AnimationOverrider
    {
        public static AnimatorOverrideController SetOverrideController(Animator animator)
        {
            AnimatorOverrideController overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController;
            return overrideController;
        }

        public static void OverrideAnimation(AnimatorOverrideController controller, int index, AnimationClip clip)
        {
            controller[controller.runtimeAnimatorController.animationClips[index].name] = clip;
        }
    }
}
