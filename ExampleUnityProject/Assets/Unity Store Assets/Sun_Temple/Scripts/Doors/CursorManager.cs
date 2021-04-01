using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SunTemple{
	
	public class CursorManager : MonoBehaviour {

		public static CursorManager instance;

		public Sprite defaultCursor;
		public Sprite lockedCursor;
		public Sprite doorCursor;
		public Sprite eCursor;

		private UnityEngine.UI.Image img;


		void Awake () {
			instance = this;
			img = GetComponent<UnityEngine.UI.Image> ();						
		}


		public void SetCursorToLocked(){
			img.sprite = lockedCursor;
			
		}

		public void SetCursorToDoor(){
			img.sprite = doorCursor;
		}

		public void SetCursorToE(){
			img.sprite = eCursor; 
		}
		public void SetCursorToDefault(){
			img.sprite = defaultCursor; 
		}
		

	}
}
