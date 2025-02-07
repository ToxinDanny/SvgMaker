# Editor notes
It took me 30/40 minutes to set up the project and make the back-end side (very easy), but then I spent 5 hours trying a custom solution in React without success.
I just heard about React, but never seen it or used it (as on my CV) and I've been exclusively a back-end developer for 4 years now.
It was pretty challenging, I'd like to discuss the concepts but I'm not spending any more time on this task :) 

# SvgMaker

Task for an interview.

Create a webpage, for drawing rectangle SVG figure.
Near to the figure display the perimeter of the figure.

Requirements:

- The initial dimensions of the SVG figure need to be taken from JSON file.
- The user should be able to resize the figure by mouse.
- Need to display the perimeter of the figure.
- After resizing, the system must update the JSON file with new dimensions.
- When resizing rectangle finishes it should be validated at BackEnd level. If the rectangle
width exceeds height it should send back error to UI . The duration of validation in
BackEnd should be artificially increased to 10 seconds (To imitate long-lasting
calculations)
- User can resize rectangle while previous validation is still not completed
  
Implement by using React (frontend) and C# (for JSON taking and saving through API).
Provide the source code with a readme file.


