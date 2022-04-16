using UnityEngine;

public class MessegeActivator : MonoBehaviour
{
    [SerializeField] GameObject _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Finish")
        {
            _gameManager.GetComponent<GameManager>().SuccessfulMessege();
        }
        else
        {
            _gameManager.GetComponent<GameManager>().LoseMessege();
        }
    }
}
