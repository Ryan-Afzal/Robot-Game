using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block {

	[RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(RectTransform))]
	public abstract class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IHierarchyChangedHandler {

        // Prefabs
        public HorizontalBar horizontalBarPrefab;
        public Text textPrefab;
        public ArgSocket argSocketPrefab;
        public BlockSocket blockSocketPrefab;

        // Inspector Parameters
        public Canvas canvas;

        // Components
        private Image image;
        private Shadow shadow;
        private RectTransform rectTransform;

        // Layout/Sockets
        internal BlockSocket prevSocket;

        protected ArgSocket[] argSockets;
        protected BlockSocket[] blockSockets;

        public virtual Vector4 Border => new Vector4(5, 5, 5, 5);
        public virtual Vector4 Padding => new Vector4(10, 10, 10, 10);
        public virtual float NestedIndent => 10;
        public virtual float VerticalSpacing => 10;
        public virtual Vector2 DefaultSize => new Vector2(100, 50);

        public virtual bool Draggable => true;

        public abstract string[][] Text { get; }

        public void Awake() {
            this.image = GetComponent<Image>();
            this.shadow = GetComponent<Shadow>();
            this.rectTransform = GetComponent<RectTransform>();

            this.shadow.enabled = false;

            var anchor = new Vector2(0.0f, 1.0f);
            this.rectTransform.anchorMin = anchor;
            this.rectTransform.anchorMax = anchor;
            this.rectTransform.pivot = anchor;

            this.rectTransform.SetParent(this.canvas.transform, true);

            this.IntializeTextAndArgSockets(Text);
		}

        public void Start() {
            this.HierarchyChanged();
        }

        public void OnMouseEnter() {
            this.shadow.enabled = true;
        }

        public void OnMouseExit() {
            this.shadow.enabled = false;
        }

        #region Layout

        public Vector2 GetTotalSize() {
            var socketTrans = this.blockSockets[this.blockSockets.Length - 1]
                .GetComponent<RectTransform>();

            return new Vector2(
                Mathf.Max(this.rectTransform.sizeDelta.x, socketTrans.sizeDelta.x),
                this.rectTransform.sizeDelta.y + this.blockSockets[this.blockSockets.Length - 1]
                    .GetComponent<RectTransform>()
                    .sizeDelta
                    .y
                );
        }

        public void HierarchyChanged() {
            this.RecalculatePositions();

            this.prevSocket?.InvokeHierarchyChanged();
        }

        private void RecalculatePositions() {
            var children = this.rectTransform
                .Cast<RectTransform>()
                .ToArray();

            if (children.Length == 0) {
                throw new InvalidOperationException("There should be more children");
            }

            float x = -Padding.x;

            for (int i = 0; i < children.Length - 1; i++) {
                var child = children[i];
                child.GetComponent<HorizontalBar>()?.RecalculatePositions();

                if (child.GetComponent<BlockSocket>() is object) {
                    x = Mathf.Max(x, child.rect.width + NestedIndent);
                } else {
                    x = Mathf.Max(x, child.rect.width);
                }
            }

            float Dy = -Padding.z;

            for (int i = 0; i < children.Length - 1; i++) {
                var child = children[i];

                if (child.GetComponent<BlockSocket>() is object) {
                    child.localPosition = new Vector3(Padding.x + NestedIndent, Dy, 0);
                } else {
                    child.localPosition = new Vector3(Padding.x, Dy, 0);
                }

                Dy -= child.rect.height + VerticalSpacing;
            }

            this.rectTransform.sizeDelta = new Vector2(
                Mathf.Max(x + Padding.x + Padding.y, DefaultSize.x), 
                Mathf.Max((-Dy) + Padding.z + Padding.w, DefaultSize.y)
                );
            this.rectTransform.ForceUpdateRectTransforms();

            var lastSocket = children[children.Length - 1];
            lastSocket.localPosition = new Vector2(Padding.x, -this.rectTransform.rect.height);
        }

        private void IntializeTextAndArgSockets(string[][] text) {
            int i = 0;

            int totalLength = 0;

            for (int k = 0; k < text.Length; k++) {
                totalLength += text[k].Length;
            }

            this.argSockets = new ArgSocket[totalLength - text.Length];
            this.blockSockets = new BlockSocket[text.Length];

            // Populate the first row
            var firstBar = Instantiate(this.horizontalBarPrefab, this.rectTransform);

            var firstText = Instantiate(this.textPrefab, firstBar.transform);
            firstText.text = text[0][0];

            for (int col = 1; col < text[0].Length; col++) {
                this.argSockets[i] = Instantiate(this.argSocketPrefab, firstBar.transform);
                this.argSockets[i].SetParent(this);
                i++;

                var rowText = Instantiate(this.textPrefab, firstBar.transform);
                rowText.text = text[0][col];
            }

            // Populate all the other rows
            for (int row = 1; row < text.Length; row++) {
                this.blockSockets[row - 1] = Instantiate(this.blockSocketPrefab, this.rectTransform);
                this.blockSockets[row - 1].SetParentBlock(this);

                var horizontalBar = Instantiate(this.horizontalBarPrefab, this.rectTransform);

                // Populate Horizontal Bar
                var startText = Instantiate(this.textPrefab, horizontalBar.transform);
                startText.text = text[row][0];

                for (int col = 1; col < text[row].Length; col++) {
                    this.argSockets[i] = Instantiate(this.argSocketPrefab, horizontalBar.transform);
                    this.argSockets[i].SetParent(this);
                    i++;

                    var rowText = Instantiate(this.textPrefab, horizontalBar.transform);
                    rowText.text = text[row][col];
                }
            }

            // Add the socket for the next block
            this.blockSockets[this.blockSockets.Length - 1] = Instantiate(this.blockSocketPrefab, this.rectTransform);
            this.blockSockets[this.blockSockets.Length - 1].SetParentBlock(this);
        }

        #endregion Layout

        #region Drag

        public void OnBeginDrag(PointerEventData eventData) {
            if (Draggable) {
                this.rectTransform.SetParent(this.canvas.transform, true);

                this.prevSocket?.Detach();
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (Draggable) {
                transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (Draggable) {
                var list = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, list);

                var results = list
                    .Select(r => r.gameObject.GetComponent<BlockSocket>())
                    .Where(s => s is object);

                var obj = results.FirstOrDefault(s => this.NoCycle(s));

                if (obj is object) {
                    var result = obj.GetComponent<BlockSocket>();
                    var resultTransform = result.GetComponent<RectTransform>();

                    this.rectTransform.SetParent(resultTransform, true);
                    this.rectTransform.localPosition = new Vector3(-Padding.x, 0, 0);

                    result.Attach(this);
                }
            }
        }

        private bool NoCycle(BlockSocket socket) {
            if (socket is null) {
                return true;
            } else if (ReferenceEquals(socket.parentBlock, this)) {
                return false;
            } else {
                return NoCycle(socket.parentBlock.prevSocket);
            }
        }

        #endregion Drag

        #region Compilation

        protected Block GetNextBlock() {
            return this.blockSockets[this.blockSockets.Length - 1].AttachedBlock;
        }

        public abstract IInstruction Compile();

        #endregion Compilation

    }
}
