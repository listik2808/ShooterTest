using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Hero
{
    public class Aiming : MonoBehaviour
    {
        public const string Aim = "Aim";
        [SerializeField] private Camera _camera;
        [SerializeField] private Animator _animator;
        [SerializeField] private Image _aim;

        private Coroutine _zoomCoroutine;

        private void Update()
        {
            if(UnityEngine.Input.GetMouseButtonDown(1))
            {
                _aim.gameObject.SetActive(false);
                _animator.SetBool(Aim,true);
                if (_zoomCoroutine != null)
                    StopCoroutine(_zoomCoroutine);
                _zoomCoroutine = StartCoroutine(AimFieldofView(_camera,50,0.3f));
            }
            if(UnityEngine.Input.GetMouseButtonUp(1))
            {
                _aim.gameObject.SetActive(true);
                _animator.SetBool(Aim, false);
                if (_zoomCoroutine != null)
                    StopCoroutine(_zoomCoroutine);
                _zoomCoroutine = StartCoroutine(AimFieldofView(_camera, 60, 0.3f));
            }
        }

        private IEnumerator AimFieldofView(Camera targetCamera,float toView,float duration)
        {
            float counter = 0;
            float fromView = targetCamera.fieldOfView;

            while(counter < duration)
            {
                counter += Time.deltaTime;
                float viewTime = counter / duration;
                targetCamera.fieldOfView = Mathf.Lerp(fromView, toView, viewTime);
                yield return null;
            }
        }
    }
}