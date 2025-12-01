using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    public class NextZone : MonoBehaviour
    {
        [Tooltip("Tên scene cần chuyển đến")]
        public string nextSceneName = "GamplayScene2";

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                Debug.Log("Player đã vào VictoryZone - chuẩn bị chuyển cảnh");
                var ev = Schedule<SceneTransitionRequested>();
                ev.sceneName = nextSceneName;
            }
        }
    }
}