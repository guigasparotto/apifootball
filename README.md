# Api-Football Tests

This is a demo testing project using C#, NUnit and SpecFlow.

### Prerequisites
* An api key is required. If you still don't have one, go to [Api-Football](https://www.api-football.com/) and subscribe for free to get one
* You should have [Visual Studio](https://visualstudio.microsoft.com/vs/community/) installed and up-to-date 
* Install the [Visual Studio Integration](https://docs.specflow.org/projects/specflow/en/latest/Tools/Visual-Studio-Integration.html) plugin for [SpecFlow](https://specflow.org/) via Visual Studio menu `Extensions > Manage Extensions`
* Powershell is required if running the tests via command line script. If running on MacOS, you should first install [powershell for MacOS](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-macos?view=powershell-7)

### Running the tests

Clone the repository to your local machine
```
git clone https://github.com/guigasparotto/apifootball.git
```
There are two options:
1. Open the project in Visual Studio and run the tests via Test Explorer `Test > Test Explorer`
2. Open powershell, navigate to the folder where you cloned the project and run
```
.\run_tests.ps1 -ApiKey "yourApiKey" 
```
* The script builds the solution and runs the tests
* The test output will be logged in the terminal
