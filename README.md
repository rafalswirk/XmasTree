# Introduction

Some time ago i bought Xmas Tree for Raspberry Pi. It's really cool gadged for this micro computer. It can be still bought in PiHut shop. Just use this link: [3D RGB Xmas Tree for Raspberry Pi](https://thepihut.com/products/3d-rgb-xmas-tree-for-raspberry-pi). 

<img src="https://github.com/rafalswirk/XmasTree/blob/master/docs/images/XmasTree-1.png" width="300" />

There is no need for any advanced knowledge to play with this toy :) You can find already prepared scripts at this github site [ThePiHut
/
rgbxmastree](https://github.com/ThePiHut/rgbxmastree#rgbxmastree). Last christmas I played with them. Raspberry Pi with Xmas Tree looks very cool but I found very annoying to change running script with light effect. Inside this repository you can find simple web api written in .NET 5 and client app in Maui. They can be used for simple remote controll of Xmas Tree :D Client app works with Windows system and Android phones. 

# Xmas Tree Web Api
Place this api project directly on your raspberry pi. I found very usefull instruction how to do this at this web page: [Deploy .NET apps to Raspberry Pi](https://learn.microsoft.com/en-us/dotnet/iot/deployment). It's very usefull to configure you Raspberry Pi to run web api automatically with system startup. With my Pi I've done this by editing rc.local file. See tutorial at this page [Run a Program On Your Raspberry Pi At Startup
](https://www.dexterindustries.com/howto/run-a-program-on-your-raspberry-pi-at-startup/). Also remember about setting up automatic configuration for your wifi connection ;) It can be simply done during preparition of SD-Card with Raspberry Pi system. There is nice tutorial for it here: [How To Configure WiFi on Raspberry Pi: Step By Step Tutorial
](https://www.seeedstudio.com/blog/2021/01/25/three-methods-to-configure-raspberry-pi-wifi/).

# Xmas Tree App

It's simple app prepared using .NET MAUI. Basic screen allows to set connection string for the api:

<img src="https://github.com/rafalswirk/XmasTree/blob/master/docs/images/ClientApp.png" width="300" />

Once you type right url press "Connect" button. Application will switch to second screen. You can select there python script to execute. 

<img src="https://github.com/rafalswirk/XmasTree/blob/master/docs/images/ClientApp2.png" width="300" />

List of scripts is automatically prepared by web api. Choose your favourite one and enjoy the show :)

![xmas-tree-gif](/docs/images/XmasTree-work.gif)