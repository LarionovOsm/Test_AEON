using UnityEngine;

namespace PlayerInputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _playerSpeed = 5.0f;
        private Rigidbody _playerRigidbody;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            _playerRigidbody.AddForce(movement * _playerSpeed);
        }
    }
}
