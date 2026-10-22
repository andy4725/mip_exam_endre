This repo contains the files to our October 22 MIP exam. I had to build the pony express app.

The project can be run simply by pressing the green play button in Visual Studio. 

The main window will appear. From here the user can manually add a recipient and choose the priority level of the delivery.
The user can also click on the generate dataset button, which will generate 120 entries. These entries will appear on grid table on the right.
There are buttons to start and stop processing the entries. Priority level 3 orders take precedence and take 300ms to complete. After 2 level 3 orders, the longer waiting lower priority order will be handled, in 600ms. If there are no low level order, the next level 3 order will be handled. Also, if there are no level 3 orders, the longest waiting orders will be handled first.

The database file is called ponyexpress.db.
The trace log file is called trace.log.

Both files are found in:
mip_exam/bin/x64/Debug
