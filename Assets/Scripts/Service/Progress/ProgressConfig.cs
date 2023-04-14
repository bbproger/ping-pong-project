using UnityEngine;

namespace Service.Progress
{
    [CreateAssetMenu(fileName = "Progress Config", menuName = "Config/Progress Config", order = 0)]
    public class ProgressConfig : ScriptableObject
    {
        [SerializeField] private int progressPerLevel;
        [SerializeField] private int progressPerLevelUp;

        public int ProgressPerLevel => progressPerLevel;
        public int ProgressPerLevelUp => progressPerLevelUp;
    }
}