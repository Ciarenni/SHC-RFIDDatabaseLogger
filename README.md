# SHC-RFIDDatabaseLogger
Tool for tracking hours worked on various projects with RFID chips

This project was the biggest one created for the club, and was written near the end of my time with them when I had learned the most.  
I was tasked with creating a way for us in the club to track how many hours were put into our various projects using some RFID tags we had just gotten in.

When a tag is swiped:
-If it is not bound to a user, the dialog for adding a user will pop up. On that form, you can enter the name of the user and the default project they are on.  
-If it is bound to a user, it will hit the database to determine if the user is clocking in or out and will calculate their hours if necessary.

It was designed to be run in both of our labs concurrently, but would also log to a file if it couldn't hit the database (we had some connection issues with the school internet occasionally). I'm pretty sure I set it up so that once it did reconnect, it would reconcile the file and the database.
