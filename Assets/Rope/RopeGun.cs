using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    [SerializeField] private float _spring = 100f;
    [SerializeField] private float _damper = 5f;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private RopeState _currentRopeState;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private PlayerMovement _playerMovement;

    public SpringJoint SpringJoint;

    private float _length;

    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }

        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if (distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active && !_playerMovement.Grounded)
            {
                _playerMovement.Jump();
            }
            DestroySpring();
        }

        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        _length = 1f;
        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }
        _hook.StopFix();
        _hook.gameObject.SetActive(true);
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;
        _currentRopeState = RopeState.Fly;    
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = _hook.Rigidbody;
            SpringJoint.anchor = _ropeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = _spring;
            SpringJoint.damper = _damper;

            _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            SpringJoint.maxDistance = _length;

            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            _currentRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
