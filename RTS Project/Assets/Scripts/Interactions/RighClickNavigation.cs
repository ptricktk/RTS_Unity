using UnityEngine;
using System.Collections;
using System;

public class RighClickNavigation : Interaction {

    public float relaxDistance = 5;

    private UnityEngine.AI.NavMeshAgent _agent;
    private Vector3 _target = Vector3.zero;
    private bool _selected = false;
    private bool _isActive = false;

    public override void Deselect()
    {
        _selected = false;
    }

    public override void Select()
    {
        _selected = true;
    }

    public void SendToTarget()
    {
        _agent.SetDestination(_target);
        _agent.Resume();
        _isActive = true;
    }
    
    void Start () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update () {
        if (_selected && Input.GetMouseButtonDown(1))
        {
            var tempTarget = RtsManager.current.ScreenPointToMapPosition(Input.mousePosition);
            if (tempTarget.HasValue)
            {
                _target = tempTarget.Value;
                SendToTarget();
            }
        }	

        if (_isActive && Vector3.Distance(_target, transform.position) < relaxDistance)
        {
            _agent.Stop();
            _isActive = false;
        }
	}
}
