using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RotateCube : MonoBehaviour,IBeginDragHandler,IDragHandler
{
    private int _angle = 90;
    private Vector3 main;//нужный поворот
    [SerializeField] private float speed;//скорость поворота
    [SerializeField] Transform player;//главный куб
    public UnityEvent Move;
    public UnityEvent GameOver;

    private void Start()
    {
        main = new Vector3(0, 0, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x)< Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.y > 0)
            {
                main.x += _angle;
                main.z = 0;
                player.transform.DORotateQuaternion(Quaternion.Euler(main), speed);
                if (AnswersController.NumberAnswer == 0)
                    Move.Invoke();
                else
                    GameOver.Invoke();
            }
            else
            {
                main.x -= _angle;
                main.z = 0;
                player.transform.DORotateQuaternion(Quaternion.Euler(main), speed);
                if (AnswersController.NumberAnswer == 1)
                    Move.Invoke();
                else
                    GameOver.Invoke();
            }
        }
        else
        {
            if (eventData.delta.x > 0)//right
            {
                main.y -= _angle;
                main.z = 0;
                player.transform.DORotateQuaternion(Quaternion.Euler(main), speed);
                if (AnswersController.NumberAnswer == 3)
                    Move.Invoke();
                else
                    GameOver.Invoke();
            }
            else//left
            {
                main.y += _angle;
                main.z = 0;
                player.transform.DORotateQuaternion(Quaternion.Euler(main), speed);
                if (AnswersController.NumberAnswer == 2)
                    Move.Invoke();
                else
                    GameOver.Invoke();
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {

    }

}
