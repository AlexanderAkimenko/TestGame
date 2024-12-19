using DG.Tweening;
using UnityEngine;


public class LightAnimation : MonoBehaviour
{
    [SerializeField] private Transform lightTransform; 
    [SerializeField] private Vector3 moveOffset = new Vector3(0, 0, 5); 
    [SerializeField] private float duration = 2f; 
    [SerializeField] private Ease easeType = Ease.InOutSine; 

    private void Start()
    {
        Vector3 startPosition = lightTransform.position;
        
        Vector3 targetPosition = startPosition + moveOffset;
        
        lightTransform.DOMove(targetPosition, duration)
            .SetEase(easeType) 
            .SetLoops(-1, LoopType.Yoyo);
    }
}


