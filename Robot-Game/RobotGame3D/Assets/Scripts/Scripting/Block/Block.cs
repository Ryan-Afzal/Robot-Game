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
	[RequireComponent(typeof(RectTransform))]
	public class Block : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        // Prefabs
        public HorizontalBar horizontalBarPrefab;
        public Text textPrefab;
        public ArgSocket argSocketPrefab;
        public BlockSocket blockSocketPrefab;

        public Canvas canvas;
        public Vector4 padding;
        public float verticalSpacing;
        public string[][] textCells;

        [HideInInspector]
        public string[,] text;

        private Image image;
        private RectTransform rectTransform;

        private ArgSocket[] argSockets;

        internal BlockSocket prevSocket;

        private BlockSocket[] blockSockets;

		public void Awake() {
            // TEMP
            this.textCells = new string[][] {
                new string[] { "Print ", " to the console" },
                new string[] { "" }
            };

            this.text = new string[textCells.Length, textCells[0].Length];
            for (int r = 0; r < this.textCells.Length; r++) {
                for (int c = 0; c < this.textCells[r].Length; c++) {
                    this.text[r, c] = this.textCells[r][c];
                }
            }
            // TEMP

			this.rectTransform = GetComponent<RectTransform>();
			this.image = GetComponent<Image>();

            var anchor = new Vector2(0.0f, 1.0f);
            this.rectTransform.anchorMin = anchor;
            this.rectTransform.anchorMax = anchor;
            this.rectTransform.pivot = anchor;

            this.rectTransform.SetParent(this.canvas.transform, true);

            this.IntializeTextAndArgSockets(this.text);
		}

        public void Start() {
            this.HierarchyChanged();
        }

        private void IntializeTextAndArgSockets(string[,] text) {
            int i = 0;
            this.argSockets = new ArgSocket[text.Length - text.GetLength(0)];
            this.blockSockets = new BlockSocket[text.GetLength(0)];
            
            // Populate the first row
            var firstBar = Instantiate(this.horizontalBarPrefab, this.rectTransform);

            var firstText = Instantiate(this.textPrefab, firstBar.transform);
            firstText.text = text[0, 0];

            for (int col = 1; col < text.GetLength(1); col++) {
                this.argSockets[i] = Instantiate(this.argSocketPrefab, firstBar.transform);
                i++;

                var rowText = Instantiate(this.textPrefab, firstBar.transform);
                rowText.text = text[0, col];
            }

            // Populate all the other rows
            for (int row = 1; row < text.GetLength(0); row++) {
                this.blockSockets[row - 1] = Instantiate(this.blockSocketPrefab, this.rectTransform);
                this.blockSockets[row - 1].SetParentBlock(this);

                var horizontalBar = Instantiate(this.horizontalBarPrefab, this.rectTransform);

                // Populate Horizontal Bar
                var startText = Instantiate(this.textPrefab, horizontalBar.transform);
                startText.text = text[row, 0];

                for (int col = 1; col < text.GetLength(1); col++) {
                    this.argSockets[i] = Instantiate(this.argSocketPrefab, horizontalBar.transform);
                    i++;

                    var rowText = Instantiate(this.textPrefab, horizontalBar.transform);
                    rowText.text = text[row, col];
                }
            }

            // Add the socket for the next block
            this.blockSockets[this.blockSockets.Length - 1] = Instantiate(this.blockSocketPrefab, this.rectTransform);
            this.blockSockets[this.blockSockets.Length - 1].SetParentBlock(this);
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

            float x = -this.padding.x;

            foreach (var child in children) {
                child.GetComponent<HorizontalBar>()?.RecalculatePositions();
                x = Mathf.Max(x, child.rect.width);
            }

            float Dy = -this.padding.z;

            for (int i = 0; i < children.Length - 1; i++) {
                var child = children[i];

                child.localPosition = new Vector3(this.padding.x, Dy, 0);

                Dy -= child.rect.height + this.verticalSpacing;
            }

            this.rectTransform.sizeDelta = new Vector2(x + this.padding.x + this.padding.y, (-Dy) + this.padding.z + this.padding.w);
            this.rectTransform.ForceUpdateRectTransforms();

            var lastSocket = children[children.Length - 1];
            lastSocket.localPosition = new Vector2(this.padding.x, -this.rectTransform.rect.height);
        }

        #region Drag

        public void OnBeginDrag(PointerEventData eventData) {
            this.rectTransform.SetParent(this.canvas.transform, true);

            this.prevSocket?.Detach();
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData) {
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
                this.rectTransform.localPosition = new Vector3(-this.padding.x, 0, 0);

                result.Attach(this);
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

    }
}
