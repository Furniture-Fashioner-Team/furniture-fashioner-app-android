# Furniture Fashioner App
The main repository for the development of an AR-driven mobile app for placing and modifying furniture and other 3D objects in the device's camera view. The application aims to offer the user a means to place virtual objects in their preferred scene, for example viewing a piece of furniture in their environment for decoration purposes. Because of our limited resources, the application is developed only for Android. For now...

This project is developed using **Unity 3D**, and most of the code is composed of **C#-scripts** to modify assets and objects in Unity's scene view. The naming convention we are using in the code is **CamelCase**. The Augmented Reality features utilize Unity's **AR Foundation framework**. The 3D furniture used in the project is modelled using **Blender**. The app is being developed and tested using several Android devices, including different phones and a tablet.

We are utilising some Unity Asset Store assets for the completion of this project. ChatGPT is used for consultation and as an aid in problem-solving. Duplicate and delete icons are from https://www.flaticon.com/. Links to the sound effects we used are https://freesound.org/people/SplatFreeSound/sounds/413690/ and https://freesound.org/people/MATRIXXX_/sounds/506546/. The sound effects may have been edited before we used them. If additional specific sources or tools are used, they will be stated here.

## Installing the app
If you are interested in trying the application, you can download the latest .apk file from the link https://developer.cloud.unity3d.com/share/share.html?shareId=oswmHWtmW1TtVKIrIrNiDav4CH1xo6W7PDsbow1O4nw.
You can also find the latest downloadable version in the **Builds folder.** You can install it by copying the .apk file to any folder in your device and then opening it with your phone. You may need to change your phone's settings to allow the installation.

If you are cloning the project, be sure to change the build settings to 'Android', since by default it's 'Windows, Mac, Linux'. From Edit > Project Settings > Editor you also need to change the 'Device' setting to 'Any Android Device'. Based on your device or software version you might need to change some other settings too, but for most devices the application should work with these changes.

## Development Diary
For **Sprint 1** the plan was to have a working camera view with rudimental objects, such as a cube or a triangle, and to be able to move, rotate and scale the object. We managed to implement the camera view and created working scripts for object rotation, as well as size manipulation.

For **Sprint 2** our focus was on developing surface recognition and identification + user interface modification so that the user can select from multiple objects. New 3D models for furniture were also added.

For **Sprint 3** we aimed to solidify our communication skills to keep track of working progress more effectively. In regards to the development of the app, we were focusing on developing more nuanced ways to navigate the application as well as manipulate objects (deletion/duplication). We were also intending to further develop plane detection as well as object anchoring, but did not quite get them ready for the sprint review.

For **Sprint 4** we got the plane detection and object initialization working, and we also changed the object moving so that it only moves along detected surfaces. Additionally, we incorporated sound effects in our app, for object selection, duplication and deletion. For the rest of the sprint, we used our time to finalize our app and to make sure everything works. 
