using UnityEngine;

[CreateAssetMenu(fileName = "TutorialTextData", menuName = "Tutorial/TutorialTextData")]
public class TutorialTextData : ScriptableObject
{
    [System.Serializable]
    public class StepText
    {
        public TutorialStep step;
        [TextArea]
        public string text;
    }

    public StepText[] tutorialSteps;
}
