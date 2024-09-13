using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIPractice
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image slotImage; 
        private Color originalColor;

        private void Start()
        {
            originalColor = slotImage.color;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedObject = eventData.pointerDrag;

            if (droppedObject != null)
            {
                InventoryDragHandler dragHandler = droppedObject.GetComponent<InventoryDragHandler>();
                if (dragHandler != null)
                {
                    dragHandler.SetDroppedOnSlot(true);
                }
                
                droppedObject.transform.SetParent(transform);
                
                droppedObject.transform.position = transform.position;
                
                StartCoroutine(HighlightSlot());
            }
        }
        
        private IEnumerator HighlightSlot()
        {
            slotImage.color = Color.green;
            
            yield return new WaitForSeconds(0.5f);
            
            slotImage.color = originalColor;
        }
    }
}
