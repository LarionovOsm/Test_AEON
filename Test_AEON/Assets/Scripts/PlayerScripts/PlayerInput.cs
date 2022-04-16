using UnityEngine;

namespace PlayerInputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] GameObject _gameManager;
        private Transform _mainCameraTransform;                  
        private Vector3 _mainCameraForward;
        private Vector3 _movement;
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _mainCameraTransform = Camera.main.transform;
        }
        
        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            _mainCameraForward = Vector3.Scale(_mainCameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            _movement = vertical * _mainCameraForward + horizontal * _mainCameraTransform.right;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _gameManager.GetComponent<GameManager>().Restart();
            }
        }

        private void FixedUpdate()
        {
            _playerMovement.MoveCharacter(_movement);
        }
    }
}
