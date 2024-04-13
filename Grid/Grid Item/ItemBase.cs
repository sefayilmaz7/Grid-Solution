using System;
using UnityEngine;

namespace AliceGames.Core
{
    [RequireComponent(typeof(ItemVisual), typeof(BoxCollider2D))]
    [Serializable]
    public class ItemBase : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private ItemVisual itemVisual;
        public int X;
        public int Y;
        public ItemType itemType;
        
        public void Initialize(int[] coordinates, Vector2 position, Transform parent, Cell cell, ItemType type)
        {
            X = coordinates[0];
            Y = coordinates[1];
            itemType = type;
            itemVisual.InitializeVisual(position, parent);
            cell.SetItem(this);
        }

        public void InputReact()
        {
            itemVisual.OnReactVFX(); 
        }

        public void SwitchCollider(bool value) { boxCollider2D.enabled = value; }

        public bool IsEmpty()
        {
            return itemType == ItemType.Empty;
        }
        
        //Getter/Setters
        public Vector2 GetCoordinates() { return new Vector2(X, Y); }

        public ItemVisual GetVisual() { return itemVisual; }

        public enum ItemType
        {
            Empty,
        }
    }
}