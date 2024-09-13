using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIPractice
{
    public class InventoryDragHandler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        private CanvasGroup _canvasGroup;
        private Vector3 _originalPosition;
        private Transform _originalParent;
        private bool droppedOnSlot; // Variable para verificar si se soltó en una casilla válida.

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _originalPosition = transform.position;
            _originalParent = transform.parent; // Guardar el padre original.
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
            droppedOnSlot = false; // Reiniciar cada vez que comenzamos a arrastrar.
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;

            // Si no se soltó en una casilla válida, volver a la posición original.
            if (!droppedOnSlot)
            {
                transform.position = _originalPosition;
                transform.SetParent(_originalParent); // Regresar al padre original.
            }
        }

        // Método público para permitir que la casilla lo notifique cuando es soltado en ella.
        public void SetDroppedOnSlot(bool dropped)
        {
            droppedOnSlot = dropped;
        }
    }
}
