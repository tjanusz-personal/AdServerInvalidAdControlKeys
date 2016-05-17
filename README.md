AdServerInvalidAdControlKeys
==================

The AdServerInvalidAdControlKeys project is a simple C# console project which reads a directory of our ad server ad control error logs and outputs a dictionary of key/values to help figure out root causes of our production AdControl errors.

It will output a summary total of errors by CampId,Creative Id,Placement Id. This way we can narrow which placement/creative is probably the root cause of the errors.

Note: I've later re-written this in RUBY in a different repository since the C# restriction was raised.


## Getting Started

* Get all source from this git repo
* Connect to DC3 production environment
* Copy error logs to local machine/directory for processing

### Dependencies

* .NET
* Connection to DC3 Production environment

### Configuring the Project

* **App.config** - configure file for input directory and output file name

  ```

	<appSettings>
    	<add key="DirName" value="C:\\temp\\BadAdControlRecsLast7Days"/>
    	<add key="OutFileName" value="C:\\temp\\AdControlIdsLast7Days.csv"/>
  	</appSettings>

 ```

### Running the Project
There is a single are class (program.cs) to launch if running in IDE, if not then build the project and run the .exe.


## Testing

- NONE

## Deployment

N/A

## Getting Help

### Documentation

* None
