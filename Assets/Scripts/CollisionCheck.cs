using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.GameEnd();
        }
    }

    
}
