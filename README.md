# Furniture Fashioner App
The main repository for the development of an AR-driven mobile app for placing and modifying furniture and other 3D objects in the device's camera view. The application aims to offer the user a means to place virtual objects in their preferred scene, for example viewing a piece of furniture in their environment for decoration purposes. Because of our limited resources, the application is developed only for Android, for now.

## Tools and Additional Resources
This project is developed using **Unity 3D**, and most of the code is composed of **C#-scripts** to modify assets and objects in Unity's scene view. The Augmented Reality features utilize Unity's **AR Foundation framework**. The Unity version used for this project is **2022.3.8f1**. Unity's documentation can be found [here](https://docs.unity.com/) and [here](https://docs.unity3d.com/Manual/index.html).

The naming convention we are using in the code is **CamelCase**. The 3D furniture used in the project is modelled using **Blender**. **ChatGPT** has been used for consultation and as an aid in problem-solving. The app is developed and tested using several Android devices, including different phones and a tablet.

Duplicate and delete icons are from [Flaticon](https://www.flaticon.com/). The sound effects we used are from [SplatFreeSound](https://freesound.org/people/SplatFreeSound/sounds/413690/) and [MATRIXXX_](https://freesound.org/people/MATRIXXX_/sounds/506546/), on **FreeSound**. The sound effects may have been edited before we used them, using **Audacity**. 
If any additional specific sources or tools are used, they will be stated here.

## Installation
If you are interested in trying the application, you can download the latest .apk file from [this link](https://developer.cloud.unity3d.com/share/share.html?shareId=qQEogVJ29HgMsvJCw6--Wqv4CH1xo6W7PDsbow1O4nw) (updated 1.12.2023). The link opens a QR code that you can use to download the file directly to your phone.
To install the app, you should have the file in any folder in your device. If the installation does not start automatically, open the file in your phone. You may also need to change your phone's settings to allow unknown sources.

If you are cloning the project, be sure to change the build settings to 'Android', since by default it's 'Windows, Mac, Linux'. From Edit > Project Settings > Editor you also need to change the 'Device' setting to 'Any Android Device'. Based on your device or software version you might need to change some other settings too, but for most devices the application should work with these changes.

## Using the App
The app uses surface detection to determine where to place the furniture objects. Before the object can be placed, the user must wait for the round marker to appear, to indicate the detected floor. **The speed and accuracy of the surface detection can vary on different devices**, but to get the best results, the room should be well-lit. White-colored surfaces can also be more difficult to detect, as opposed to surfaces with more contrast. If the phone doesn't seem to find any surfaces, moving the device horizontally and vertically might help.

When the floor is detected, the user can choose a furniture to place on the location of the marker, by navigating to the menu from top left menu icon. Tap the desired furniture, and then 'To camera' button, to see the furniture in the camera view.

The furniture can be moved by dragging with one finger (the object turns blue). To rotate the object horizontally, use two fingers (green). Tapping a furniture opens an object-specific menu (yellow), from where you can duplicate or delete it. 

## Project Structure
As with Unity the scripts are usually linked to game objects rather than directly to each other, and some of the connecting happens in editor as opposed to in-code, visualizing the project's architecture is somewhat difficult. In the project structure, most of the development happens in [Assets](https://github.com/Furniture-Fashioner-Team/furniture-fashioner-app-android/tree/main/Assets) folder. The **scripts** are divided into subfolders that describe their use: 
- ARCamera - camera view related scripts
- Menu - menu-related scripts
- Global - scripts that determine global variables, to be used in both camera and menu.
- MockData - scripts related to managing the furniture selection and their thumbnails.
- ObjectManipulation - scripts that handle functionalities directly related to furniture objects and manipulating them with screen touch controls.
- UserInterface - scripts that manage UI elements, such as icons and the place marker, as well as the color indication of the user's touch on the object.

The **FakeDatabase** folder contains the 3D furniture models. Their designated file type is **.fbx**. Additional resources, such as icons and sound files, are located in the **Resources** folder. 

## Issues and further development
Our ideas for further development of the app are opened as [issues](https://github.com/Furniture-Fashioner-Team/furniture-fashioner-app-android/issues). The listed issues are either functionalities we have discussed during the development process but deemed them lower priority than the features we have focused on, or additional features we have come up with during the final sprint.

## Development Diary
Our project's user stories and development tasks can be found in [User_stories.md](https://github.com/Furniture-Fashioner-Team/furniture-fashioner-app-android/blob/main/user_stories.md). The ones with a checkmark are completed. The ones that are crossed over we have either left uncompleted (see issues above) or deemed unnecessary for our project's finalization.

### Sprint 1
The plan was to have a working camera view with rudimental objects, such as a cube or a triangle, and to be able to move, rotate and scale the object. We managed to implement the camera view and created working scripts for object rotation, as well as size manipulation.

### Sprint 2 
Our focus was on developing surface recognition and identification + user interface modification so that the user can select from multiple objects. New 3D models for furniture were also added.

### Sprint 3
We worked towards solidifying our communication skills, to keep track of working progress more effectively. In regards to the development of the app, we were focusing on developing more nuanced ways to navigate the application as well as manipulate objects (deletion/duplication). We were also intending to further develop plane detection as well as object anchoring, but did not quite get them ready for the sprint review.

### Sprint 4
We got the plane detection and object initialization working, and we also changed the object moving so that it only moves along detected surfaces. Additionally, we incorporated sound effects in our app, for object selection, duplication and deletion. We investigated the possibility to implement a screenshot/camera functionality to take a picture of the view, but it proved too time-consuming, so we left it out. For the rest of the sprint, we used our time to finalize our app and to make sure everything works as intended. 
