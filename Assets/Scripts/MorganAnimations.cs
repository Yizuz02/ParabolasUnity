using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorganAnimations : MonoBehaviour
{
    private float _timer;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>120f){
            _animator.SetTrigger("LongIdle");
        }
    }
}
