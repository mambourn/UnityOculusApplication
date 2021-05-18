# UnityOculusApplication
How to use Unity Engine to create an Oculus application

# Table of Contents
- **Project Overview**	
  - Unity Setup	
- **Set Up Development Environment	**
  - Oculus Setup	
  - Enable Device for Development and Testing	
  - Import Oculus Integration Package	
  - Configure Settings	
- **Application Development**
  - Build An Application	
  - Importing a Model	
  - Controller	
      - Adding Controllers	
      - Programming Controller Actions	
  - Object Appearance or Disappearance	
    - Object Appearance	
    - Object Disappearance	
  - Lighting	
  - Build Application	
  - Debugging with ADB	
- **Resulting Experiment**
  - Study Introduction	
  - Method	
  - Results
  - Conclusions	
  - References	
- **Appendices**	
  - C# Scripts	
    - spawner.cs - Creates Objects	
    - spawner_randomized.cs - Randomized Location of Created Object	
    - updateSpawner.cs - Update Spawner Location	
    - destroyer.cs - Have an Object Disappear	
    - light.cs - Turns On and Off Lights	

# Project Overview 
  The following document outlines the steps involved in using Unity Game Engine to develop an application to use on an Oculus Quest or Oculus Quest 2 virtual reality (VR) headset. The resulting VR application was used to conduct a psychology experiment on distance perception in VR. Unity environment setup, Oculus setup, application development, and the final implementation of the psychology experiment will be detailed below.
  
# Unity Setup
The following instructions for setting up Unity Game Engine are adapted from https://developer.oculus.com/documentation/unity/unity-gs-overview/. 

# Set Up Development Environment
1. Download the Oculus app on your phone and sign in with a new or existing account
2. Download Unity Editor at https://unity3d.com/get-unity/download. Be sure to include the Android SDK and NDK Tools and OpenJDK as these will be important for debugging your application later (Fig. 1).
3. Ensure the Android tools correctly installed by going to Android Studio -> Configure -> SDK Manager -> SDK Platforms and SDK Tools tabs (Fig. 2)
4. Ensure that the Android tools are added to your Environment Variables for your computer so that you can access the tools from the command line. Example: C:\Users\user\AppData\Local\Android\sdk\platform-tools.
5. Install Android Debug Bridge (ADB): https://developer.oculus.com/downloads/package/oculus-adb-drivers/.
  - This application will allow you to debug during development (ex: send the headset data to your computer).
6. Install VLC Media Player: https://www.videolan.org/vlc/download-windows.html.
  - This application will be used for mirroring the headset view to your computer.

# Oculus Setup 
## Enable Device for Development and Testing
1. Turn on the headset (Oculus Quest or Quest 2). Connect it via usb to your computer. 
2. Open the Oculus App on your phone. Go to Settings and pair a new headset. Once paired, the application will show when your headset is connected (Fig. 4). 
3. Select your device and turn on Developer Mode. 
4. Within the headset, accept to allow USB debugging (Fig. 5). To confirm the connection, you can run adb devices on the command line or go to File -> Build Settings in your application (Fig. 6), although we won’t be creating the application until later in this tutorial. 

# Import Oculus Integration Package
1. This step will occur in any new or existing unity project. Go to Window-> Asset Store and search for Oculus Integration (Fig. 7).When prompted, update the OVRPlugin and Spatializer. Allow it to restart the application. 
2. Import to the project: Window -> Package Manager -> Packages: My Assets.
# Configure Settings
1. In a Unity project, go to File-> Build Settings
2. Under Platform, select your target platform. WIndows is the default, but Mac and Linux are also supported (Fig. 8).
3. Go to Android under Platform to ensure that Android is being used (Fig. 9).
2. Go to Edit -> Project Settings and remove Vulcan. Add Oculus as Virtual Reality SDK. Make sure the minimum API level is at least 19. 
# Application Development
## Build An Application
1. Open Unity Hub as seen in Fig.10.
2. Create a new 3D unity project (Fig. 11)
  - The drop down arrow to the right of “New” allows you to choose which version of Unity to use. This is important as some applications may not be compatible with other versions of Unity. This tutorial uses version 2019.4.15f1.
3. See here for additional documentation on development of an application: https://developer.oculus.com/downloads/package/oculus-adb-drivers/. 

# Importing a Model
## Import Model
1. The model used in this tutorial was a dae file that replicates a real classroom at ISU. The dae file was imported to Blender, a 3D computer graphics software toolset. In Blender, the default camera that gets added to the project was deleted so as not to interfere with the camera used later in Unity.
2. In Blender, the dae file gets exported as an fbx file.
3. Import the fbx file to Unity by Assets -> Import New Asset.
4. The model can then be accessed from the Project Window. Drag the model onto the scene and position it at coordinate (0,0,0).
5. Add Box Collider as a component of the classroom so that items will not fall through the floor (Fig. 12).
6. Remove the camera from the model (as this will be replaced later by a character controller so that the user has the same view as the avatar).
## Create Accurate Scale
1. Unity allows the scale of any object or model to be changed through the Inspector window. 
2. To ensure an accurate size, a 1 m^3 cube was imported from Blender. That cube was then used to compare to the model. The scale of the model was then tweaked until it was accurate in size compared to the imported cube. The ratio of the virtual to real size of the room was 0.98 virtual units to 1 meter.
## Import Materials
1. Images of real objects are used to make the classroom objects realistic. The objects are otherwise grey by default.
2. Import the materials at Assets -> Import New Asset and select all of the images you want to add to the project. Once imported, they will show up in your Project window. 
3. Select a surface to add an image to and then drag the desired image to that object surface. 

# Controller
## Adding Controllers
This section explains how to add an avatar to the project that will be controlled by the user’s movement and interaction with the Oculus hand held controllers.
1. Delete the default camera if it exists in the project. 
2. Within the Project Window, find the OVRPlayerController (Oculus/VR/Prefabs/OVRPlayerController) and update its position where you want the character to begin standing.
3. Uncheck Enable Hands within the Project Inspector to remove the avatar hands. 

# Programming Controller Actions
The controller that is connected to the headset can be set up to execute certain actions based on what buttons are clicked.
1. Default actions of the controller can be seen at Edit -> Project Settings -> Input Manager
2. Use the above list for updating controller actions. Within a C# file, the following command will trigger the event associated with the press of a certain button: if (Input.GetButtonDown(“ButtonName”)), where ButtonName is from the Input Manager.
3. The C# files used in this project are attached in the Appendices.

# Object Appearance or Disappearance
Having objects appear and disappear also uses C# files (attached in the Appendices). The placement of the C# files is very important within the project. 
## Object Appearance
1. Implement if statement logic within a C# file (spawner.cs)
2. Create an empty object called spawner in the project. Put the position of the object where you want the item to appear (although this can be updated based on logic within the updateSpawner.cs file attached in the Appendices). 
3. Create an object that you want to appear or disappear (ex: a cube for simplicity sake).  Ensure that the object has a rigidBody component so that it doesn’t fall through the floor.
4. Add the spawner script to the OVRPlayerController (or whatever camera is being used). 
5. Fill in SpawnPos as the empty spawner object that was placed somewhere in the scene in one of the previous steps.
6. Fill in Spawnee as whatever object is to appear in the scene. 
## Object Disappearance
1. Create a destroyer.cs script with logic to determine when an object should disappear. 
2. Add this script as a component of the item in the scene that should disappear. 

# Lighting 
1. The default light often casts weird shadows. To remove these, delete the light and then add that same type of light back into the project.
2. Four lights will be used for realistic lighting. 
  - Two of the four lights are directional (sun like) and the other two are point lights. The direction of the lights can be changed to ensure the whole space is realistically illuminated.
3. A light.cs script (included in Appendices) can be used to turn on and off the lights. Ensure that the light object has the light.cs script added as a component. 

# Build Application
1. Connect the headset to the PC via USB. 
2. File -> Build Settings -> ensure that Android is selected as the platform.
3. In Build Settings, ensure that your headset shows up in Run Devices. If it does not show up, refresh or reconnect the headset with a different USB cable. Sometimes the longer cables (over 10 yards) will have issues connecting to the headset. 
4. File -> Build and Run or File -> Build Settings -> Build and Run to run the application on the headset. When this step is complete, an apk file will be downloaded to the headset.
5. To re access the application in the headset from Oculus’ main page, navigate to the applications tile (will look like 9 little squares in a grid) in the bottom navigation dock. There will be an option to choose the type of application to sort by. Select Unknown Source (at the bottom of the list). Your apk file will be located here.

# Debugging with ADB
1. Open a command prompt and use the following command to see log messages from your application: adb logcat -s Unity ActivityManager PackageManager dalvikvm DEBUG
  - If you get an error saying that adb is not recognized, check your environment variables to ensure that the path to your sdk\platform-tools for Android is correct (as mentioned in the section Set Up Development Environment).
2. To mirror the view of the headset onto your VLC media player window, use the following command in your command prompt: adb exec-out "while true; do screenrecord --bit-rate=2m --output-format=h264 --time-limit 180 -; done" | "C:\Program Files (x86)\VideoLAN\VLC\vlc.exe" --demux h264 --h264-fps=60 --clock-jitter=0 -
  - Make sure you have already installed VLC Media Player as mentioned in Set Up Development Environment.

# Resulting Experiment
## Study Introduction
- Virtual environments should ideally be perceived similarly to real environments
- Research on older headsets shows that distance in virtual environments is underperceived compared to real environments [1, 2]
- Objective: This project compared perceived distance in a real environment and a virtual environment shown on two modern VR headsets: Oculus Quest and Quest 2
- Hypothesis: Distance perception will be more accurate in the real environment compared to the virtual environment
## Method
- 30 participants each in real environment, Quest, and Quest 2
- Created virtual environment in Unity Game Engine to model a real classroom
- Red square presented at 1-5 meters (repeated 3 times each)
- Participants made verbal and blind walking distance judgments
# Results
- Judgments in the real classroom were more accurate than those in the Quest and Quest 2
  - Verbal: p < 0.001, d =0.8155
  - Blind walking: p < 0.001, d = 2.1210
- Judgments in the Quest and Quest 2 did not differ from one another
  - Verbal: p = 0.182, d = 0.33999
  - Blind walking: p = 0.864, d = 0.0429

# Conclusions
- Our results support the hypothesis that distance is more accurately perceived in real environments than virtual environments
- Quest vs Quest 2: 
  - Despite higher resolution and lighter weight, perception in the Quest 2 was no more accurate than the Quest
- Limitations: 
  - Cues from the real environment did not match with the virtual environment 
  - 3D model could be more realistic
- Future research: 
  - VR experience and other demographics of participants 
  - Avatar of user[3]

# References
1. Kelly, J. W., Cherep, L. A., Siegel, Z. D. (2017). Perceived Space in the HTC Vive.  ACM Transactions on Applied Perceptions
2. Renner, R. S., Velichkovsky, B. M., Helmert, J. R. (2013). The Perception of Egocentric Distances in Virtual Environments - A Review. ACM Computing Surveys
3. Mohler, B. J., Creem-Regehr, S. H., Thompson, W. B., Bülthoff, H. H. (2010). The Effect of Viewing a Self-Avatar on Distance Judgments in an HMD-Based Virtual Environment. Presence: Teleoperators and Virtual Environments

# Appendices
## C# Scripts 
### spawner.cs - Creates Objects 
### spawner_randomized.cs - Randomized Location of Created Object
### updateSpawner.cs - Update Spawner Location
### destroyer.cs - Have an Object Disappear
### light.cs - Turns On and Off Lights




















