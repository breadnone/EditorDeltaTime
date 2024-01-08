**Editor Delta Time**  
A simple utility for deltaTime and frameCount simulation while in Edit mode in Unity3d.  

**Installation**  
Download the .zip then unpack it to Assets folder.

**Usage**  
- Add the namespace `using EditorDelta;`
- Can be used as follow :
```
var delta = EditorDelta.deltaTime;
var frame = EditorDelta.frameCount;
```  
**Note**
- This is just a simulation based on screen's refresh's rate and will not be as accurate as Unity's runtime deltaTime. But it should be close enough.
- Note that this is for custom editor only(edit mode), not runtime.
