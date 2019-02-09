Instructions for running the tests and convert the results to HTML format:

Precondition: You must have successfully builded Automation project with your Visual studio

1. Include the following path to your "Path" Environment variable 
	C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow 

2. Create the following Environment variable: 
	PROJECT_PATH = <path_to_your_Automation_project>
	Example: PROJECT_PATH = C:\Users\Dido\source\repos\Automation Framework\Automation

3. Run the "runTests.bat" file - all available TestCases will be listed in the console by name. The program will prompt you
to enter the Test Cases you want to execute. Enter the Test Case(s) name(s) (if more than 1 - separated with "," wthout whitespaces).
Hit Enter button and the execution will start. The results from the execution will be saved in TRX format in the "TestResults" folder.

4. After the test execution is completed, run the "convertTRX.bat" file - all available execution TRX reports will be listed in the console.
The program will prompt you to enter the name of the TRX file that you want to convert to HTML. Enter the correct TRX file name.
Hit Enter button and the file will be converted. The new HTML file will be saved to "TestResults" folder.