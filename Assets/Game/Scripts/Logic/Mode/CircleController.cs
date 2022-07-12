using System.Collections;
using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class CircleController : MonoBehaviour
    {
        [SerializeField] private CircleView prefab;
        private bool canSpawn = true;


        public void BlockSpawn()
        {
            canSpawn = false;
        }

        public void UnblockSpawn()
        {
            canSpawn = true;
        }

        public void StartMode(int count, PlayerView playerView,RequirementView requirementView)
        {
            
            StartCoroutine(Spawn(count, playerView,requirementView));
        }

        private IEnumerator Spawn(int count, PlayerView playerView,RequirementView requirementView)
        {
           
            for (int i = 0; i < count; i++)
            {
               
                
                yield return new WaitUntil(() => canSpawn);
                float randomSecond = Random.Range(0.5f, 2f);
                yield return new WaitForSeconds(randomSecond);

                var pos=GetRandomNearPosition(playerView.transform.position);

                bool isFinal=false;
                if (i == count - 1)
                {
                    isFinal = true;
                }
                CircleView circleView = Instantiate(prefab, pos, Quaternion.identity);
                CircleModel circleModel = new CircleModel(isFinal);
                CirclePresenter circlePresenter = new CirclePresenter(circleView,circleModel, this,playerView,requirementView);
                
                circlePresenter.Enable();

                BlockSpawn();
            }
           
            
            
        }

        private Vector3 GetRandomNearPosition(Vector3 position)
        {
            float deltaX = Random.Range(2f, 3f);
            float deltaY = Random.Range(3f, 4f);
            int sign = Random.Range(-1, 2);

            var pos = position;
            pos.x += deltaX * sign;
            pos.y += deltaY;
            return pos;
        }
    }
}