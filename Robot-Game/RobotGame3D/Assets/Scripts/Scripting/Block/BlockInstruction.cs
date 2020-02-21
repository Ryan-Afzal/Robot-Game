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

    public abstract class BlockInstruction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IHierarchyChangeHandler {

        public static readonly Vector3 ArgTextOffset = new Vector3(1, 0, 0);

        private Image image;
        private Shadow shadow;
        private RectTransform rectTransform;

        public string startText;
        public string[] text;

        public Vector3 offset = new Vector3(0, -100, 0);

        public Canvas canvas;

        public GameObject textCellPrefab;
        public GameObject argSocketPrefab;

        private Text[] textCells;
        private ArgSocket[] argSockets;

        public bool Locked { get; set; }

        public BlockInstruction Previous { get; set; }
        public BlockInstruction Next { get; set; }

        public void Awake() {
            this.rectTransform = GetComponent<RectTransform>();
            this.image = GetComponent<Image>();
            this.shadow = GetComponent<Shadow>();

            this.textCells = new Text[this.text.Length + 1];
            this.argSockets = new ArgSocket[this.text.Length];

            this.textCells[0] = Instantiate(this.textCellPrefab, this.rectTransform, false).GetComponent<Text>();
            this.textCells[0].text = this.startText;

            var pos = this.textCells[0].rectTransform.position + new Vector3(this.textCells[0].rectTransform.rect.width / 2, 0, 0) + ArgTextOffset;

            for (int i = 0; i < this.argSockets.Length; i++) {
                this.argSockets[i] = Instantiate(this.argSocketPrefab, this.rectTransform, false).GetComponent<ArgSocket>();
                this.argSockets[i].Base = this;
                this.argSockets[i].transform.position = pos;

                pos += new Vector3(this.argSockets[i].rectTransform.rect.width / 2, 0, 0) + ArgTextOffset;

                this.textCells[i + 1] = Instantiate(this.textCellPrefab, this.rectTransform, false).GetComponent<Text>();
                this.textCells[i + 1].text = this.text[i];
                this.textCells[i + 1].transform.position = pos;

                pos += new Vector3(this.textCells[i + 1].rectTransform.rect.width / 2, 0, 0) + ArgTextOffset;
            }

            this.rectTransform.ForceUpdateRectTransforms();
        }

        public virtual void Start() {

        }

        public virtual void Update() {
            this.shadow.enabled = RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, Input.mousePosition);
        }

        public virtual void HierarchyChanged() {
            if (Next is object) {
                Next.HierarchyChanged();
            }

            for (int i = 0; i < this.argSockets.Length; i++) {
                this.argSockets[i].HierarchyChanged();
            }
        }

        private void SetColorDrag() {
            this.image.color = Color.green;
        }

        private void SetColorEndDrag() {
            this.image.color = Color.white;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (!Locked) {
                this.rectTransform.SetParent(this.canvas.transform, true);

                if (Previous is object) {
                    Previous.Next = null;
                    Previous = null;
                }

                SetColorDrag();
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (!Locked) {
                transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!Locked) {
                var list = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, list);

                var results = list
                    .Select(r => r.gameObject)
                    .Where(o => !ReferenceEquals(this.gameObject, o));

                if (results.FirstOrDefault(o => o.GetComponent<TrashSlot>() is object) is object) {
                    Destroy(gameObject);
                    return;
                }

                var obj = results.FirstOrDefault(o => o.GetComponent<BlockInstruction>() is object);

                if (obj is object) {
                    var result = obj.GetComponent<BlockInstruction>();
                    var resultTransform = result.GetComponent<RectTransform>();

                    this.rectTransform.position = resultTransform.position + this.offset;
                    this.rectTransform.SetParent(resultTransform, true);

                    Previous = result;
                    Previous.Next = this;
                }

                SetColorEndDrag();
            }
        }

        public abstract IInstruction GetCompiledInstruction();

    }

}
