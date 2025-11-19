using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public EnemyController enemy;

        public override void Execute()
        {
            enemy._collider.enabled = false;
            enemy.control.enabled = false;

            // PHẦN QUAN TRỌNG - CHO QUÁI RƠI XUỐNG
            var rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true;
                rb.velocity = new Vector2(0, -6f); // tốc độ rơi
                rb.gravityScale = 3f; // có thể chỉnh tùy ý
            }

            if (enemy._audio && enemy.ouch)
                enemy._audio.PlayOneShot(enemy.ouch);
        }
    }
}
