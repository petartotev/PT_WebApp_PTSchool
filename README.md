# PT_WebApp_PTSchool

## General Information

PT_WebApp_PTSchool is an ASP.NET Core MVC Web Application that provides an online platform for different services for Parents, Teachers and Students within a school institution.

![WebAppScreenshots](Resources/Screenshots/PTSchool_Screenshot_0.jpg)

## Technologies

- Automapper
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
- Serilog
- SignalR
- Swagger

## Contents

The solution contains 4 main directories with 6 projects:

- Console
  - PTSchool.Console
- Data
  - PTSchool.Data
  - PTSchool.Data.Models
- Services
  - PTSchool.Services
  - PTSchool.Services.Models
- Web
  - PTSchool\.Web
    - Models-Views-Controllers (MVC) application
    - ApiControllers ( : ControllerBase) to serve the purposes of a RESTful API

## User Guide

The main functionality of the web app is to facilitate the communication between the 3 main "sides" within a School Institution:

- (P)arents
- (T)eachers
- (S)tudents

### (P)arents

- check their child's marks / notes and sign them
- receive code-red notifications for a poor mark or a note concerning inappropriate behavior

### (T)eachers

- add new marks / notes to (S)tudents
- create new Clubs

### (S)tudents

- apply for a Club
- communicate with each other (S)<>(S)
- end an email to a (T)eacher or chat directly

## Additional Functionalities

### SchoolChat!

SignalR web-socket connection provides a real-time massive **chat** that everybody can join and share!

![WebAppScreenshots](Resources/Screenshots/PTSchool_Screenshot_SchoolChat.jpg)

### SchoolCanvas!

SignalR also provides a real-time **canvas** that can be used by anybody to express themselves freely.

\~If you have the urge to write an offensive statement in front of the whole school and run away - this is your chance!\~

![WebAppScreenshots](Resources/Screenshots/PTSchool_Screenshot_SchoolCanvas.jpg)

### TicTacToeGame!

Thanks to SignalR TicTacToe lets you:

- Create one by yourself and wait for your buddy to join!
- Join a TicTacToe room already created

Play TicTacToe!

![WebAppScreenshots](Resources/Screenshots/PTSchool_Screenshot_TicTacToePlay.jpg)

### PTShooterGame!!!

A mouse-click shooter with no page-reloading.  
No page reloading, vanilla JavaScript only.

Start with:

- Health = 3
- Gun Reload = 5
- Enemies = 12

You-shoot-them-all-or-they-shoot-you.  
As simple as that!

![WebAppScreenshots](Resources/Screenshots/PTSchool_Screenshot_PTShooter.jpg)

\~THE END\~
