# AzureTimeTracker
## Overview
AzureTimeTracker is tool designed automatically to save spent time in specific Task.
## Features
At the moment allow only to save time as completed effor in hours only on the Tasks, for only one project.
In case you want to use on diffrent projects, settings.json should be changed
## Installation
* clone the git repository
* open with visual studio 2022 with minimum of .net 8
* prepare configuration file:
  - Modify settings.json
  `{"OrganizationUrl":"","PersonalAccessToken":"","DefaultProject":"","AssignedTo":""}`
* Organization URL can be found : https://learn.microsoft.com/en-us/azure/devops/organizations/accounts/rename-organization?view=azure-devops
* Creating PersonalAccessToken : https://learn.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=Windows
* Default project is project on which you want to track the time
* AssignedTo is email address to whom is assigned the task
  
## Usage
* Click on Fetch Tasks in order to get tasks assigned to you.
* Press button to start
* When you finish press button stop than Save.
* If you press Reset your time will be discard from appliction but not from azure task.
  
![image](https://github.com/user-attachments/assets/d624a64e-b0f5-48ed-ac62-23fad2ce30c1)
![image](https://github.com/user-attachments/assets/66429844-da27-49b8-abea-7edd5a459989)
![image](https://github.com/user-attachments/assets/b0b7f16e-f9a4-4478-8ea9-fb77d27c090d)
![image](https://github.com/user-attachments/assets/cc903c60-0e24-483b-bb2b-0c1b3437f2c8)
![image](https://github.com/user-attachments/assets/636f2cdc-5323-4688-9843-bcee21a0a35e)










