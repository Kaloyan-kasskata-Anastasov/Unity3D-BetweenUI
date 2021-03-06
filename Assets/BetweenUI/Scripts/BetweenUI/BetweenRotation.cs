﻿namespace Assets.BetweenUI.Scripts.BetweenUI
{
    using UnityEngine;

    /// <summary>
    /// Rotate the object's local Rotation.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Rotation")]
    public class BetweenRotation : BetweenBase
    {
        public Vector3 From;
        public Vector3 To;

        private Transform trans;

        private Transform CachedTransform
        {
            get
            {
                if (this.trans == null)
                {
                    this.trans = GetComponent<Transform>();
                }

                return this.trans;
            }
        }

        /// <summary>
        /// Transition's current value.
        /// </summary>
        private Quaternion Value
        {
            set
            {
                this.CachedTransform.localRotation = value;
            }
        }

        /// <summary>
        /// Transit the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = Quaternion.Euler(new Vector3(
                Mathf.Lerp(this.From.x, this.To.x, timeFactor),
                Mathf.Lerp(this.From.y, this.To.y, timeFactor),
                Mathf.Lerp(this.From.z, this.To.z, timeFactor)));
        }

        public void Reset()
        {
            ToForCurrent();
            FromForCurrent();
        }

        [ContextMenu("Current rotation for To")]
        public void ToForCurrent()
        {
            this.To = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z);
        }

        [ContextMenu("Current rotation for From")]
        public void FromForCurrent()
        {
            this.From = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z);
        }
    }
}
