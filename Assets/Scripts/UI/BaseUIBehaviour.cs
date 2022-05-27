using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject _content;
    [SerializeField] protected bool _hideOnAwake;

    protected virtual void Awake()
    {
        if(_hideOnAwake)
        {
            Hide();
        }
    }

    public virtual void Show()
    {
        _content.SetActive(true);
    }

    public virtual void Hide()
    {
        _content.SetActive(false);
    }
}
