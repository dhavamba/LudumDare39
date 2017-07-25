using UnityEngine;

namespace Pool
{
    public interface IPool
    {
        /// <summary>
        /// Reset valus for gameObjects
        /// </summary>
        void Reset(GameObject obj);

        /// <summary>
        /// Disable GameObject after specific time
        /// </summary>
        void DestroyForTime(GameObject obj, float time);
    }
}
