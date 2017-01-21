using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

		private bool paused;

		public GameObject pauseMenu;

		public static bool isMouseOver;

		void Start(){
			Time.timeScale = 1;
			pauseMenu.SetActive (false);
		}

		//Pause/unpause the game
		public void Pause() {
			paused = !paused;
			if (paused) {
				Time.timeScale = 0;
				pauseMenu.SetActive (true);
			}
			else {
				Time.timeScale = 1;
				pauseMenu.SetActive (false);
			}
		}

		public void Quit(){
			SceneManager.LoadScene ("Main Menu");
		}

		//isMouseOver is used to determine if the shooter should fire or not
		//(shouldn't fire if the player is trying to pause)
		public void OnPointerEnter(PointerEventData p) {
			isMouseOver = true;
		}

		public void OnPointerExit(PointerEventData p) {
			isMouseOver = false;
		}

		public void setMouseOver(bool over){
			isMouseOver = over;
		}


}
