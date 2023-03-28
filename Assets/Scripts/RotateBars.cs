using UnityEngine;

public class RotateBars : MonoBehaviour
{
    #region Scripts

    [SerializeField] private GameManager _gameManager;

    #endregion

    #region Variables

    [SerializeField] private float rotateSpeed;

    #endregion

    private void Update()
    {
        if (_gameManager.startGame)
        {
            gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
