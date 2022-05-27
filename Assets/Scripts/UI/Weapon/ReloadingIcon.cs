using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadingIcon : BaseUIBehaviour
{
    [SerializeField] private Image _rotateImage;
    [SerializeField] private float _rotateSpeed;

    private IEnumerator Rotate()
    {
        while(true)
        {
            _rotateImage.transform.Rotate(0,0, -1 * _rotateSpeed);
            yield return null;
        }
    }

    public override void Show()
    {
        base.Show();
        StartCoroutine(Rotate());
    }

    public override void Hide()
    {
        StopAllCoroutines();
        base.Hide();
    }
}
