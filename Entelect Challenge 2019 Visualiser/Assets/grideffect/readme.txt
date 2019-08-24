
grid effect script for camera object


This post process script add a grid effect to rendered image. 



-How to use-


1.Attach "GridEffect" script to camera object.
2.Attach "gridshader" material to the material of GridEffect script of the camera object.
3.Change each value(Amount,Xstep,Ystep,Xoffset,Yoffset,Xmin,Xmax,Ymin,Ymax) of GridEffect script ,you can see the changes in "Game" window.



-About each value of GridEffect script -

"Amount" controls the transparency of lines. 
"GridType" changes grid type.
"GridColor" changes the color of grid line.
"Xstep" controls  steps of vertical lines. If "Xstep" value is "1" the vertical lines disappear.
"Ystep" controls  steps of horizontal lines. If "Ystep" value is "1" the horizontal lines disappear.
"Xmin" and "Xmax" control a size of area of drawing grid lines. 
"Ymin" and "Ymax" control a size of area of drawing grid lines.
"Flasing"    If "Flasing" is 1,flicker appears in play mode.





-About "controlsc" script-

Attach this script to the camera object attached GridEffect script ,then you can control the value of "Xstep" and "Ystep" and "Amount" of GridEffect script by keyboard when running a program.

Arrow key(vertical) of keyboard      decrease and increase Xstep value.
Arrow key(horizontal)of keyboard    decrease and increase Ystep value.


"I"and"K" key of keyboard  decrease and increase Amount value. 


 