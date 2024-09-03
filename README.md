Caverns Routing Application

Module Information:

Module Number: SET09122/SET09822

Module Title: Artificial Intelligence
__________________________________________________________________________________________________________________________________________________________

Project Overview:

This project is a solution to the Caverns Routing problem as part of the Artificial Intelligence coursework. The task involves developing a program that allows a robot to navigate through a network of underground caverns connected by tunnels. The program reads cavern map files and outputs the shortest possible route from the starting cavern to the destination, or determines if no route is possible.
__________________________________________________________________________________________________________________________________________________________

Problem Description:

The caverns are represented by coordinates, and the tunnels between them are represented by a binary connectivity matrix.
The objective is to navigate from the first cavern to the last cavern using the shortest path, considering Euclidean distances between caverns.
__________________________________________________________________________________________________________________________________________________________

Input & Output:

Input - Cavern maps are provided in .cav files with coordinates and a connectivity matrix.

Output - The program outputs the sequence of caverns to a .csn file representing the route.
__________________________________________________________________________________________________________________________________________________________

File Format:

Cavern Map File - .cav files containing the number of caverns, their coordinates, and the connectivity matrix.

Solution File - .csn files containing the sequence of caverns representing the route.
__________________________________________________________________________________________________________________________________________________________

Execution Requirements:

The program is designed to run from the Windows command line with a single parameter, the name of the cavern map file (without extension). It reads the .cav file and writes the solution to a .csn file.
__________________________________________________________________________________________________________________________________________________________

Program Criteria:

  Find the shortest route or identify if no route is possible.

  Run in less than one minute for given test files.

  Produce no screen output or require user input during execution.

  Be executable via a batch file (caveroute.bat) provided.
