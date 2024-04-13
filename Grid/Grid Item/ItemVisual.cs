using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace AliceGames.Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ItemVisual : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private VisualParams visualParams;

        public void InitializeVisual(Vector2 position, Transform parent)
        {
            //Custom effects & animations here
            //Or:
            //PlayEffect();
            //Or:
            transform.localPosition = position;
            transform.SetParent(parent);
        }

        private void PlayKillVFX()
        {
            //Custom effects & animations here
            //Or:
            PlayEffect();
        }

        public void OnReactVFX()
        {
            //Custom effects & animations here
            //Or:
            PlayEffect();
        }

        public void VisualReset()
        {
            if (!spriteRenderer) return;

            //Do reset here
        }

        private void PlayEffect(/*effect parameters if necessary*/bool animateEffect = true, float effectTime = 0.5f)
        {
            spriteRenderer.enabled = true;

            if(animateEffect)
            {
                //Do animated effect with parameters here
            }
            else
            {
                //Do non-animated effect with parameters here
            }
        }

        [Serializable]
        public struct VisualParams
        {
            public float itemScaleTime;
            public Color itemSelectColor;
            public Color itemDefaultColor;
        }
    }
}
