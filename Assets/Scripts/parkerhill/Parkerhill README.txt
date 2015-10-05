


class Debug
	



"controller" - (non-visible) game object that implements controls and actions


[Object][Feature].cs - scripts that implement behaviors of an object

[Object][Feature]Actions.cs - scripts that implement actions associated with UI events



CameraVRMode class
	SetVRMode( bool )
	GetVRMode()


TO SET CAMERA MODE
	Hierarchy
		GameController
			CameraVRMode component

		UI Panel
			CameraVRModeActions component
			attach buttons (toggles) to actions functions

	Build Settings
		Target Android or ios for Cardboard and un-check "Virtual Reality Supported"
		Target Windows for Rift and check "Virtual Reality Supported"
