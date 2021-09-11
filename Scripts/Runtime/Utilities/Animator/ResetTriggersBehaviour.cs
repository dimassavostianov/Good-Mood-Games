using System.Linq;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.Animator
{
    public class ResetTriggersBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var parameter in animator.parameters.Where(parameter => parameter.type == AnimatorControllerParameterType.Trigger))
                animator.ResetTrigger(parameter.name);
        }
    }
}