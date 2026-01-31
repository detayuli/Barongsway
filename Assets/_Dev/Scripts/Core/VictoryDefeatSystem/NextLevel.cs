using UnityEngine;
using UnityEngine.SceneManagement;


        [RequireComponent(typeof(Collider2D))]
        public class NextLevel : MonoBehaviour
        {
            private void Start()
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
            void OnTriggerEnter2D(Collider2D collision)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }