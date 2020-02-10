using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting.Block {

  public abstract class BlockInstruction : MonoBehaviour {
    
    private string startText;
    private string[] text;
    private IArgInstruction[] args;
    
    protected void Init(string startText, params string[] text) {
      this.startText = startText;
      this.text = text;
      this.args = new IArgInstruction[this.text.Length];
    }
    
    public BlockInstruction Previous { get; private set; }
    public BlockInstruction Next { get; private set; }
    
    public abstract IInstruction GetCompiledValue();
    
  }
  
}
