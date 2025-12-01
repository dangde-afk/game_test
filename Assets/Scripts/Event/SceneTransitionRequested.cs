using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer.Core;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Event dùng để chuyển sang scene khác khi được gọi.
    /// </summary>
    public class SceneTransitionRequested : Simulation.Event<SceneTransitionRequested>
    {
        public string sceneName;

        public override void Execute()
        {
            Debug.Log("SceneTransitionRequested: chuyển sang scene " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}