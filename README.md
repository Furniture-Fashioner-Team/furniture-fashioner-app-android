# Furniture Fashioner App
The main repository for the development of an AR-driven mobile app for placing and modifying furniture and other 3D objects in the device's camera view. The application aims to offer the user a means to place virtual objects in their preferred scene, for example viewing a piece of furniture in their environment for decoration purposes. Right now our focus is on developing the Android version of the application.

This project is developed using **Unity 3D**, and most of the code is composed of **C#-scripts** to modify assets and objects in Unity's scene view. The naming convention we are using in the code is **CamelCase**. The Augmented Reality features utilize Unity's **AR Foundation framework**. The 3D furniture used in the project is modelled using **Blender**. The app is being developed and tested using several Android devices, including different phones and a tablet.

We are utilising some Unity Asset Store assets for the completion of this project. Chat GPT is used for consultation and as an aid in problem-solving. If additional specific sources or tools are used, they will be stated here.

## Installation
If you are interested in downloading the application on your Android device, you can find the latest downloadable version in the **Builds folder.** You can install it by copying the .apk file to any folder in your device and then opening it with your phone. You may need to change your phone's settings to allow the installation.

For cloning the project, due to Unity's large file sizes, some of the folders in the project tree are currently omitted with .gitignore. For this reason, you need to copy the Library, UserSettings and Logs folders to the cloned project from elsewhere. For example, you can make a new Unity project, and copy them from there to the project's root folder. As this is somewhat inconvenient, better options are being investigated.

## Development Diary
For **Sprint 1** the plan was to have a working camera view with rudimental objects, such as a cube or a triangle, and to be able to move, rotate and scale the object. We managed to implement the camera view and created working scripts for object rotation, as well as size manipulation.

For **Sprint 2** our focus has been on developing surface recognition and identification + user interface modification so that the user can select from multiple objects. New 3D models for furniture have also been added.

For **Sprint 3** we aim to solidify our communication skills to keep track of working progress more effectively. In regards to the development of the app, we are focusing on developing more nuanced ways to navigate the application as well as manipulate objects (deletion/duplication). We're also intending to further develop plane detection as well as object anchoring..3D
