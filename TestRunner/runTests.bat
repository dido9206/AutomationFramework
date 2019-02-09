@ECHO OFF
echo The available TC are:
echo.
echo 1.Admin_User_Can_Login
echo.
echo 2.Admin_User_Can_Logout
echo.
echo 3.Base_UI_Elements_Inspection
echo.
echo 4.Can_Choose_A_Theme_By_Title
echo.
echo 5.Can_Choose_A_Theme_By_Number
echo.
echo 6.Can_Make_Review
echo.
echo 7.Can_Make_Final_Review
echo.
echo 8.Can_Set_Score
echo.
echo 9.Can_Upload_A_Document
echo.
echo 10.Can_Show_Uploaded_Document
echo.
echo 11.Uploaded_Document_Available_In_Review_Page
echo.
echo 12.Make_All_Reviews
echo.
echo Enter the list with TC names that you want to execute, separated by coma. 
echo.
echo Example: 
echo.
echo.	If you want to execute Admin_User_Can_Login enter "Admin_User_Can_Login";
echo.
echo.	If you want to execute Can_Make_Review and Make_All_Reviews enter "Can_Make_Review,Make_All_Reviews"
echo.

set /p tclist= Please enter your input: 
echo %tclist%
start VSTest.Console.exe "%PROJECT_PATH%\Tests\bin\Debug\Tests.dll" /Tests:%tclist% /Logger:trx