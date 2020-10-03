using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ControllerEventSystem : MonoBehaviour {

    [SerializeField]
    private Button btnMain;
	[SerializeField]
	private bool dPadNavigationOnly;
    [SerializeField]
    private Selectable m_curSelected;
    [SerializeField]
    private Selectable m_lastSelected;
    [SerializeField]
	private float _scrollSpeed = 8;





    public delegate void ClickDelegate();
    public static event ClickDelegate onClicked; // can subscribe a sound

    public delegate void SelectDelegate();
    public static event SelectDelegate onSelected; // can subscribe a sound or another action

    private PointerEventData eventSystem; // Is used to send simple events
    private bool canSelect = true; //used to delay selection of buttons;
	private bool initialStart;
	private bool isScrolling;
	private GameObject[] contents;
	private bool canClick = true;
	public static float scrollSpeed; 
 
	//Only support mac and windows input out of the box
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX ||UNITY_EDITOR_WIN

	void Awake(){
		//Gets active event system
		eventSystem = new PointerEventData(EventSystem.current);
	}
    void Start () {
		scrollSpeed = _scrollSpeed;
        //Sees if a button was assigned and if not checks for any button in the scene
        if (btnMain == null)
        {
            btnMain = (Button)FindObjectOfType (typeof (Button));
            ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
            eventSystem.selectedObject = m_curSelected.gameObject;

        }
		StandaloneInputModule module =  (StandaloneInputModule)FindObjectOfType (typeof(StandaloneInputModule));
		module.repeatDelay =1;
        m_curSelected = btnMain;

    

        SelectCur(); // Selects the first button
		initialStart = true;

		EventSystem.current.sendNavigationEvents = !dPadNavigationOnly;

		ScrollRect[] scrollBars =  FindObjectsOfType(typeof(ScrollRect)) as ScrollRect[];
		foreach (ScrollRect scroll in scrollBars) {
			scroll.transform.gameObject.AddComponent<AutoScrollBar> ();

		}
	
    }
	

	void Update () {

		if (Input.anyKey && EventSystem.current.currentSelectedGameObject) {
			m_lastSelected = m_curSelected;
			m_curSelected = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable> ();
		}

        //Finds buttons on disable
        if (m_curSelected == null || m_curSelected.gameObject.active == false || m_curSelected.transform.parent.gameObject.active == false)
        {
			
            m_curSelected = (Selectable)FindObjectOfType(typeof(Selectable));
            if (m_lastSelected != null)
            {
				if(m_curSelected.gameObject){
                ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
                ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
                eventSystem.selectedObject = m_curSelected.gameObject;
				}
            }



        }


        //Sends the SubmitEvent
		if (Input.GetButton ("Submit")) {
			if(EventSystem.current.sendNavigationEvents == false)
			Click ();
		}

       /* //Sends the Navigation events for Mac
		#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        if (Input.GetButtonDown("DPadX-") && canSelect)
        {
            StartCoroutine(CanMove());
            SelectRight();
        }
        if (Input.GetButtonDown("DPadX") && canSelect)
        {
            StartCoroutine(CanMove());
            SelectLeft();
        }
        if (Input.GetButtonDown("DPadY") && canSelect)
        {
            StartCoroutine(CanMove());
            SelectUp();
        }
        if (Input.GetButtonDown("DPadY-") && canSelect)
        {
            StartCoroutine(CanMove());
            SelectDown();
        }
#endif */
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
		// Sends the Navigation events for windows 
		if (Input.GetAxis("PS4_DPadHorizontal") > 0 && canSelect)
		{
			StartCoroutine(CanMove());
			SelectRight();
			if (onSelected != null)
				onSelected();

		}
		if (Input.GetAxis("PS4_DPadHorizontal") < 0 && canSelect)
		{
			StartCoroutine(CanMove());
			SelectLeft();
			if (onSelected != null)
				onSelected();
		}
		if (Input.GetAxis("PS4_DPadVertical") > 0 && canSelect)
		{
			StartCoroutine(CanMove());
			SelectUp();
			if (onSelected != null)
				onSelected();
		}
		if (Input.GetAxis("PS4_DPadVertical") < 0 && canSelect)
		{
			StartCoroutine(CanMove());
			SelectDown();
			if (onSelected != null)
				onSelected();
		}
		#endif

    }


    //Selects the object above the m_curSelected
    void SelectUp()
    {
		isScrolling = false;
        SelectFromLast(); // Sees if the current object still exists

        if (m_curSelected.FindSelectableOnUp() != null)
        {
            m_lastSelected = m_curSelected;
            m_curSelected = m_lastSelected.FindSelectableOnUp();
            ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
            ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
            eventSystem.selectedObject = m_curSelected.gameObject;
         
        }

    }

    //Called in start to select the first button
    void SelectCur()
    {
		isScrolling = false;
		if (m_curSelected == null ||  eventSystem == null)
			return;
        ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
        eventSystem.selectedObject = m_curSelected.gameObject;
		StartCoroutine (HighlightFirst ());
    }

    //selects the object under the m_curSelected
    void SelectDown()
    {
		isScrolling = false;
        SelectFromLast(); // Sees if the current object still exists 

        if (m_curSelected.FindSelectableOnDown() != null)
        {
            m_lastSelected = m_curSelected;
            m_curSelected = m_lastSelected.FindSelectableOnDown();
            ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
            ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
            eventSystem.selectedObject = m_curSelected.gameObject;
           
        }
    }

    //selects the object to the right of the m_curSelected
    void SelectRight()
    {
		isScrolling = false;
        SelectFromLast(); // Sees if the current object still exists

        if (m_curSelected.FindSelectableOnRight() != null)
        {
            m_lastSelected = m_curSelected;
            m_curSelected = m_lastSelected.FindSelectableOnRight();
            ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
            ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
            eventSystem.selectedObject = m_curSelected.gameObject;
      
        }
    }

    //selects the object to the left of the m_curSelected
    void SelectLeft()
    {
		isScrolling = false;
        SelectFromLast(); // Sees if the current object still exists

        if (m_curSelected.FindSelectableOnLeft() != null)
        {
            m_lastSelected = m_curSelected;
            m_curSelected = m_lastSelected.FindSelectableOnLeft();
            ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
            ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
            eventSystem.selectedObject = m_curSelected.gameObject;
           
        }
    }


    //Submits a click event
    void Click()
    {
		if (canClick == false)
			return;
        if (m_curSelected != null)
        {
            StartCoroutine(ClickAction());
            if(onClicked != null)
            {
                onClicked();
            }
			StartCoroutine (CanClick ());
        }
    }


    void SelectFromLast()
	{
		isScrolling = false;
		if (m_curSelected == null && m_lastSelected == null) {
			m_curSelected = eventSystem.selectedObject.GetComponent<Selectable> ();
		} else {
			if (m_curSelected == null) {
				m_curSelected = m_lastSelected;
			}
		}
	}
    
    //Delays the clicks so that each state is visable. Prevents double clicks on toggles
    IEnumerator ClickAction()
    {
		if (m_curSelected != null) {
			ExecuteEvents.Execute (m_curSelected.gameObject, eventSystem, ExecuteEvents.deselectHandler);
			yield return new WaitForEndOfFrame();
			ExecuteEvents.Execute (m_curSelected.gameObject, eventSystem, ExecuteEvents.pointerDownHandler);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
		if (m_curSelected != null) {
			ExecuteEvents.Execute (m_curSelected.gameObject, eventSystem, ExecuteEvents.pointerUpHandler);
			ExecuteEvents.Execute (m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
			ExecuteEvents.Execute (m_curSelected.gameObject, eventSystem, ExecuteEvents.pointerClickHandler);
		}

    }

	IEnumerator CanClick(){
		canClick = false;
		yield return new WaitForSeconds(.2f);
		canClick = true;

		yield break;
	}

    //Delays the move action
    IEnumerator CanMove()
    {
		if(!dPadNavigationOnly)
		EventSystem.current.sendNavigationEvents = false;
        canSelect = false;
        yield return new WaitForSeconds(.1f);
        canSelect = true;
		if(!dPadNavigationOnly)
		EventSystem.current.sendNavigationEvents = true;

        yield break;
    }

    void OnDisable()
	{
		canClick = true;
		canSelect = true;
		if(dPadNavigationOnly)
		EventSystem.current.sendNavigationEvents = true;
		ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.deselectHandler);
        ExecuteEvents.Execute(eventSystem.selectedObject, eventSystem, ExecuteEvents.deselectHandler);
		m_lastSelected = m_curSelected;
		m_curSelected = null;
    }

	void OnEnable(){

		if(initialStart = true){
			//Sees if a button was assigned and if not checks for any button in the scene
			if (btnMain == null)
			{
				btnMain = (Button)FindObjectOfType (typeof (Button));
				m_curSelected = btnMain;
				ExecuteEvents.Execute(m_curSelected.gameObject, eventSystem, ExecuteEvents.selectHandler);
				eventSystem.selectedObject = (btnMain!=null) ? btnMain.gameObject:null;

			}
			m_curSelected = btnMain;


			EventSystem.current.SetSelectedGameObject(m_curSelected.gameObject);

			SelectCur(); // Selects the first button
			StartCoroutine(HighlightFirst());

		}
	}

	IEnumerator HighlightFirst(){
			yield return null;
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(m_curSelected.gameObject);
	}
#endif
}
